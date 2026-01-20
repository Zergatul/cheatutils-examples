/*
* Basic Villager Roller script
* It stops on Mending book
*/

if (villagerRoller.getEnchantmentId() == "minecraft:mending") {
    villagerRoller.stop();
}