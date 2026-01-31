/*
* Minecraft: 1.21+
* CheatUtils: 3.3.0+
* This script automatically harvest wheat and replants seeds
*/

// uncomment below condition if you need delay
/*if (game.getTick() % 5 != 0) {
    return;
}*/
// checking blocks not more than 1 block difference on Y level
if (math.abs(player.getY() - y) > 1) {
    return;
}
if (game.blocks.canBeReplaced(x, y, z)) {
    if (game.blocks.getId(x, y - 1, z) == "minecraft:farmland") {
        blockAutomation.useItem("wheat_seeds", "from-top");
    }
}

if (game.blocks.getId(x, y, z) == "minecraft:wheat") {
    if (game.blocks.getIntegerTag(x, y, z, "age") == 7) {
        blockAutomation.breakBlock();
    }
}