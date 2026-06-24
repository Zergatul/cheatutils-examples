/*
* Minecraft: 1.21.11+
* CheatUtils: 3.15.5+
* This script shows structure coordinates stored in different maps:
* burried treasure, ocean monument, woodland mansion, etc
* It add an entry to Status Overlay only when you hold map in the main hand.
*/

let stack = inventory.getMainHand();
if (stack.item.id == "minecraft:filled_map") {
    if (stack.nbt.get("components") is CompoundTag components) {
        if (components.get("minecraft:map_decorations") is CompoundTag decorations) {
            if (decorations["+"] is CompoundTag mark) {
                let x = mark["x"].getFloatOr(0);
                let z = mark["z"].getFloatOr(0);
                let type = mark["type"].getStringOr("?");
                overlay.add("Map Marker: " + type + " at " + x + "; " + z);
            }
        }
    }
}