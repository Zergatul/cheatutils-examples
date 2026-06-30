/*
* This script shows example how to use NBT API
*/

let id = player.target.getEntityId();
if (id <= 0) {
    return;
}

// get NBT object for entity in the crosshair
let nbt = game.entities.getNbt(id);
debug.write(nbt.toString());

// reading some values from root of NBT object
ui.systemMessage("Age = " + nbt["Age"].getIntOr(-999));
ui.systemMessage("Health = " + nbt["Health"].getIntOr(-999));

// reading nested object
let pos = nbt["Pos"];
if (pos is ListTag list) {
    ui.systemMessage("Pos: " + 
        "X=" + list[0].getFloatOr(-1) + " " +
        "Y=" + list[1].getFloatOr(-1) + " " +
        "Z=" + list[2].getFloatOr(-1) + " ");
} else {
    // report typename if something went wrong
    ui.systemMessage(#typeof(pos).name);
}

// convert to UUID object -> toString
let uuid = (nbt["UUID"] as IntArrayTag).asUUID().toString();
ui.systemMessage(uuid);