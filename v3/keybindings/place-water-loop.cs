// 1.21.7+
// Automatically places water source and removes it 1 second later
// Requires water bucket on the hotbar
// Requires 1 block below target coordinates, and visibility

static int x = 8;
static int y = -61;
static int z = -5;
static boolean active = false;

async void loop() {
    while (active) {
        let blockstate = game.blocks.get(x, y, z);
        if (blockstate.block.id == "minecraft:water" && blockstate.isFluidSource()) {
            player.lookAt(x + 0.5, y, z + 0.5);
            inventory.equipMainHand("bucket");
            keys.use.click();
        } else if (blockstate.canBeReplaced()) {
            player.lookAt(x + 0.5, y, z + 0.5);
            inventory.equipMainHand("water_bucket");
            keys.use.click();
        }
        await delay.ticks(20);
    }
    ui.systemMessage("Stopped");
}

active = !active;
if (active) {
    ui.systemMessage("Activated");
    loop();
}