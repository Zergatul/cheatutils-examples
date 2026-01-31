/*
* Minecraft: 1.21+
* CheatUtils: 3.3.0+
* Villager Roller script that stops on any book with best price and max level.
* Excluding enchantments from skip list.
*/

float percents = 100.0 * villagerRoller.getPrice() / villagerRoller.getMinPrice();

string textcolor = "#FFFFFF";
if (!villagerRoller.isMaxLevel()) {
    textcolor = "#A0A0A0";
} else if (percents == 100) {
    textcolor = "#00FF1D";
} else {
    textcolor = color.gradient("#7FFF8E", "#FF7F7F", (percents - 100) / 100);
}

ui.systemMessage("#0094FF", "[Roller]",
    textcolor,
    villagerRoller.getEnchantmentName() + " " +
    villagerRoller.getLevel().toString() + " @ " +
    villagerRoller.getPrice().toString() + " --- " +
    percents.toStandardString(0) + "%");

string[] skip = new string[] {
    "minecraft:binding_curse",
    "minecraft:aqua_affinity"
};

foreach (string id in skip) {
    if (villagerRoller.getEnchantmentId() == id) {
        return;
    }
}

if (villagerRoller.isBestPrice() && villagerRoller.isMaxLevel()) {
    ui.systemMessage("#22FD5C", "Trade found!");
    villagerRoller.stop();
}