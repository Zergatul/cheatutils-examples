/*
* Minecraft: 1.21.11+
* CheatUtils: 3.15.1+
* This script automatically equips the best armor in corresponding inventory slot once it appears in your inventory.
*/

class ArmorInfo {
    string slot;
    float armor;
    int protection;

    constructor(string slot, float armor, int protection) {
        this.slot = slot;
        this.armor = armor;
        this.protection = protection;
    }

    // probably not the best logic for selecting best armor, but it is simple
    boolean isBetterThan(ArmorInfo other) {
        if (other.armor < this.armor) {
            return true;
        }
        if (other.armor > this.armor) {
            return false;
        }
        // armor value is equal
        if (other.protection < this.protection) {
            return true;
        }
        if (other.protection > this.protection) {
            return false;
        }
        // protection value is equal, thus items are equal
        return false;
    }
}

int getProtection(ItemStack itemstack) {
    foreach (let enchantment in itemstack.enchantments) {
        if (enchantment.id == "minecraft:protection") {
            return enchantment.level;
        }
    }
    return 0;
}

ArmorInfo getArmorInfo(ItemStack itemstack) {
    foreach (let modifier in itemstack.attributeModifiers) {
        if (modifier.attribute == "minecraft:armor") {
            return new ArmorInfo(modifier.slot, modifier.value, getProtection(itemstack));
        }
    }

    return new ArmorInfo("", 0, 0);
}

events.onTickEnd(() => {
    let head = getArmorInfo(inventory.getHead());
    let chest = getArmorInfo(inventory.getChest());
    let legs = getArmorInfo(inventory.getLegs());
    let feet = getArmorInfo(inventory.getFeet());

    for (int i = 0; i < 36; i++) {
        let itemstack = inventory.getItem(i);
        let info = getArmorInfo(itemstack);
        if (info is null) {
            continue;
        }

        boolean equip;
        if (info.slot == "HEAD" && info.isBetterThan(head)) {
            equip = true;
        }
        if (info.slot == "CHEST" && info.isBetterThan(chest)) {
            equip = true;
        }
        if (info.slot == "LEGS" && info.isBetterThan(legs)) {
            equip = true;
        }
        if (info.slot == "FEET" && info.isBetterThan(feet)) {
            equip = true;
        }

        if (equip) {
            ui.systemMessage("Equipping: " + itemstack.item.id);
            inventory.equip(i);
            return; // don't equip multiple items per tick
        }
    }
});