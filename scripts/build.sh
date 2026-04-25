#!/bin/bash
# ────────────────────────────────────────────────────────
# GlazeUI Build Script
# Builds all projects or specific ones via arguments.
#
# Usage:
#   ./scripts/build.sh              # Build all projects
#   ./scripts/build.sh main         # Build main project only
#   ./scripts/build.sh rcl          # Build RCL only
#   ./scripts/build.sh cli          # Build CLI only
#   ./scripts/build.sh tests        # Build & run tests
#   ./scripts/build.sh main rcl     # Build main + RCL
#   ./scripts/build.sh all          # Build all (same as no args)
#   ./scripts/build.sh -r / release # Build in Release mode
# ────────────────────────────────────────────────────────

set -euo pipefail

ROOT="$(cd "$(dirname "$0")/.." && pwd)"
CONFIG="Debug"
TARGETS=()

# Parse arguments
for arg in "$@"; do
    case "$arg" in
        -r|release|Release) CONFIG="Release" ;;
        main)   TARGETS+=("main") ;;
        rcl)    TARGETS+=("rcl") ;;
        cli)    TARGETS+=("cli") ;;
        tests)  TARGETS+=("tests") ;;
        all)    TARGETS=("main" "rcl" "cli" "tests") ;;
        *)      echo "Unknown argument: $arg"; echo "Usage: build.sh [main|rcl|cli|tests|all] [-r|release]"; exit 1 ;;
    esac
done

# Default: build all if no targets specified
if [ ${#TARGETS[@]} -eq 0 ]; then
    TARGETS=("main" "rcl" "cli")
fi

echo "🔨 GlazeUI Build — $CONFIG"
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
echo ""

FAILED=0

build_project() {
    local name="$1"
    local path="$2"
    
    echo "  Building $name..."
    if dotnet build "$path" -c "$CONFIG" --nologo -v q 2>&1 | tail -3; then
        echo "  ✓ $name"
    else
        echo "  ✗ $name — FAILED"
        FAILED=1
        return 1
    fi
    echo ""
}

run_tests() {
    echo "  Running tests..."
    if dotnet test "$ROOT/tests/GlazeUI.Tests" -c "$CONFIG" --nologo -v q 2>&1 | tail -5; then
        echo "  ✓ Tests"
    else
        echo "  ✗ Tests — FAILED"
        FAILED=1
        return 1
    fi
    echo ""
}

for target in "${TARGETS[@]}"; do
    case "$target" in
        main)  build_project "GlazeUI (main)"           "$ROOT/src/GlazeUI" ;;
        rcl)   build_project "GlazeUI.Components (RCL)"  "$ROOT/src/GlazeUI.Components" ;;
        cli)   build_project "GlazeUI.CLI"               "$ROOT/src/GlazeUI.CLI" ;;
        tests) run_tests ;;
    esac
done

echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
if [ $FAILED -eq 0 ]; then
    echo "✅ All builds succeeded ($CONFIG)"
else
    echo "❌ Some builds failed"
    exit 1
fi
