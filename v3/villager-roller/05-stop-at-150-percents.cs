/*
* Minecraft: 1.21+
* CheatUtils: 3.3.0+
* Villager Roller script that stops when price is at most 150% of the best possible price.
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

string[] wanted = new string[] {
    "minecraft:protection",
    "minecraft:sharpness",
    "minecraft:feather_falling",
    "minecraft:unbreaking"
};

boolean found = false;
foreach (string id in wanted) {
    if (villagerRoller.getEnchantmentId() == id) {
        found = true;
        break;
    }
}

if (!found) {
    return;
}

if (percents < 150 && villagerRoller.isMaxLevel()) {
    ui.systemMessage("#22FD5C", "Trade found!");
    villagerRoller.stop();
}