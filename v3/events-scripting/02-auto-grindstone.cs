// this script automatically disenchants bows (for example from skeleton farm)
// you have to open grindstone menu, and script manipulates with items automatically

events.onTickEnd(() => {
    // attempt to disenchant once per 5 ticks
    if (game.getTick() % 5 != 0) {
        return;
    }
    if (containers.getMenuClass().endsWith("GrindstoneMenu")) {
        // find slot
        int slot = -1;
        // we loop over 27 slots of player inventory, skipping hotbar slots
        for (int i = 3; i < 30; i++) {
            let stack = containers.getItemAtSlot(i);
            if (stack.enchantments.length == 0) {
                // if not enchantments we skip this item stack
                continue;
            }
            // disenchant bows only
            if (stack.item.id == "minecraft:bow") {
                slot = i;
                break;
            }
        }
        // if slot found simulate clicks
        if (slot > 0) {
            containers.click(slot, 0, "PICKUP");  // click on item in your inventory
            containers.click(0, 0, "PICKUP");     // click on Grindstone first slot
            containers.click(2, 0, "QUICK_MOVE"); // shift+click on Grindstone result slot
        }
    }
});