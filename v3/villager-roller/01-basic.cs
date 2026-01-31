/*
* Minecraft: 1.21+
* CheatUtils: 3.3.0+
* Basic Villager Roller script. It stops on Mending book.
*/

if (villagerRoller.getEnchantmentId() == "minecraft:mending") {
    villagerRoller.stop();
}