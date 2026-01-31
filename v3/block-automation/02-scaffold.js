/*
* Minecraft: 1.21+
* CheatUtils: 3.3.0+
* This script shows an example how you can code custom Scaffold.
* For example Scaffold module does not allow you to use gravity blocks.
*/

let pos = player.getPosition();
// if current block is block below us
if (math.floor(pos.x) == x && math.floor(pos.y) - 1 == y && math.floor(pos.z) == z) {
    if (game.blocks.canBeReplaced(x, y, z)) {
        blockAutomation.useItem("sand");
    }
}