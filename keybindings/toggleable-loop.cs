/*
* This keybinding script allows you to run something in a loop and use single key as toggle for this loop.
*/

static boolean active = false;

async void loop() {
    while (active) {
        ui.systemMessage(game.getTick().toString());
        await delay.ticks(10);
    }
}

active = !active;
if (active) {
    loop();
}