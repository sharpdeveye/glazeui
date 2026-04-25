#!/bin/bash
# ────────────────────────────────────────────────────────
# GlazeUI Auto-Sync Script
# Syncs components, models, utilities from the main project
# to the RCL (GlazeUI.Components) and updates the CLI registry.
# ────────────────────────────────────────────────────────

set -euo pipefail

ROOT="$(cd "$(dirname "$0")/.." && pwd)"
SRC="$ROOT/src/GlazeUI/Components/UI"
RCL="$ROOT/src/GlazeUI.Components/UI"
MODELS_SRC="$ROOT/src/GlazeUI/Models"
MODELS_RCL="$ROOT/src/GlazeUI.Components/Models"
UTILS_SRC="$ROOT/src/GlazeUI/Utilities"
UTILS_RCL="$ROOT/src/GlazeUI.Components/Utilities"

echo "🔄 GlazeUI Auto-Sync"
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"

# ─── Sync Components ────────────────────────────────
echo ""
echo "📦 Syncing components..."
for dir in Atoms Molecules Organisms; do
    if [ -d "$SRC/$dir" ]; then
        mkdir -p "$RCL/$dir"
        count=0
        for file in "$SRC/$dir"/*.razor; do
            [ -f "$file" ] || continue
            basename="$(basename "$file")"
            if ! diff -q "$file" "$RCL/$dir/$basename" >/dev/null 2>&1; then
                cp "$file" "$RCL/$dir/$basename"
                echo "  ✓ $dir/$basename"
                count=$((count + 1))
            fi
            # Sync companion .razor.css if it exists (Blazor CSS isolation)
            cssfile="${file}.css"
            if [ -f "$cssfile" ]; then
                cssbasename="$(basename "$cssfile")"
                if ! diff -q "$cssfile" "$RCL/$dir/$cssbasename" >/dev/null 2>&1; then
                    cp "$cssfile" "$RCL/$dir/$cssbasename"
                    echo "  ✓ $dir/$cssbasename"
                    count=$((count + 1))
                fi
            fi
        done
        if [ $count -eq 0 ]; then
            echo "  · $dir — up to date"
        fi
    fi
done

# ─── Sync Models ────────────────────────────────────
echo ""
echo "📋 Syncing models..."
mkdir -p "$MODELS_RCL"
model_count=0
for file in "$MODELS_SRC"/*.cs; do
    [ -f "$file" ] || continue
    basename="$(basename "$file")"
    if ! diff -q "$file" "$MODELS_RCL/$basename" >/dev/null 2>&1; then
        cp "$file" "$MODELS_RCL/$basename"
        echo "  ✓ $basename"
        model_count=$((model_count + 1))
    fi
done
if [ $model_count -eq 0 ]; then
    echo "  · Models — up to date"
fi

# ─── Sync Utilities ─────────────────────────────────
echo ""
echo "🔧 Syncing utilities..."
mkdir -p "$UTILS_RCL"
util_count=0
for file in "$UTILS_SRC"/*.cs; do
    [ -f "$file" ] || continue
    basename="$(basename "$file")"
    if ! diff -q "$file" "$UTILS_RCL/$basename" >/dev/null 2>&1; then
        cp "$file" "$UTILS_RCL/$basename"
        echo "  ✓ $basename"
        util_count=$((util_count + 1))
    fi
done
if [ $util_count -eq 0 ]; then
    echo "  · Utilities — up to date"
fi

# ─── Summary ────────────────────────────────────────
echo ""
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"

# Count components
atom_count=$(find "$SRC/Atoms" -name "*.razor" 2>/dev/null | wc -l | tr -d ' ')
mol_count=$(find "$SRC/Molecules" -name "*.razor" 2>/dev/null | wc -l | tr -d ' ')
org_count=$(find "$SRC/Organisms" -name "*.razor" 2>/dev/null | wc -l | tr -d ' ')
total=$((atom_count + mol_count + org_count))

echo "📊 Component inventory:"
echo "   Atoms:     $atom_count"
echo "   Molecules: $mol_count"
echo "   Organisms: $org_count"
echo "   Total:     $total"

# ─── Build Verification ─────────────────────────────
echo ""
echo "🔨 Verifying builds..."
echo ""

"$ROOT/scripts/build.sh"
