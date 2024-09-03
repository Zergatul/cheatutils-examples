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

if (villagerRoller.getEnchantmentId() == "minecraft:mending") {
    ui.systemMessage("#22FD5C", "Trade found!");
    villagerRoller.stop();
}