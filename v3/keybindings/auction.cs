/*
* Minecraft: 1.21+
* CheatUtils: 3.3.0+
* This script shows example how you can automate custom ingame auction
* and automatically buy item based on your conditions.
*/

while (!input.isAltDown()) {
    player.command("/auction");
    await containers.waitForOpen();

    while (containers.getItemAtSlot(44).item.id == "minecraft:air") {
        await delay.ticks(1);
    }

    debug.write("Slots: " + containers.getSlotsSize());

    for (int i = 0; i < 45; i++) {
        debug.write("-----------------------------");

        let stack = containers.getItemAtSlot(i);
        debug.write("Slot #" + i + ": " + stack.item.name + " x" + stack.count);

        foreach (let ench in stack.enchantments) {
            debug.write(ench.name + " " + ench.level);
        }

        long rubles = -1;
        long dollars = -1;
        foreach (let line in stack.tooltip) {
            string[] matches = line.getMatches("Price: ([0-9,]+)rub.");
            if (matches.length == 2) {
                long price;
                if (long.tryParse(matches[1].replace(",", ""), ref price)) {
                    rubles = price;
                }
            }
            matches = line.getMatches("Price: ([0-9,]+)\\$");
            if (matches.length == 2) {
                long price;
                if (long.tryParse(matches[1].replace(",", ""), ref price)) {
                    dollars = price;
                }
            }
        }
        if (rubles >= 0) {
            debug.write("Price = " + rubles + " rubles");
        } else if (dollars >= 0) {
            debug.write("Price = " + dollars + " dollars");
        } else {
            debug.write("Failed to parse price");
            foreach (let line in stack.tooltip) debug.write(line);
        }

        if (stack.item.id == "minecraft:honey_bottle" && dollars == 777) {
            debug.write("Buying item...");
            // click on item
            containers.click(i, 0, "PICKUP");
            await containers.waitForNewId();
            await delay.ticks(10);
            // click on confirm
            containers.click(11, 0, "PICKUP");
            return;
        }
    }

    await delay.ticks(10);
    containers.close();
    await delay.ticks(10);
}

ui.overlayMessage("Auction script stopped");