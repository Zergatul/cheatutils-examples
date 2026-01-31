/*
* Minecraft: 1.21+
* CheatUtils: 3.3.0+
* This script automatically disables Auto Criticals if you hold a mace.
* It reenabled Auto Criticals back if you hold something else.
*/

events.onTickEnd(() => {
    autoCriticals.setEnabled(inventory.getMainHand().item.id != "minecraft:mace");
});