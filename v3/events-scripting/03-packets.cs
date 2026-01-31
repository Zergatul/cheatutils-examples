/*
* Minecraft: 1.21.7+
* CheatUtils: 3.11.2+
* Advanced Scripting: ON
* This script shows example how to work with packets.
* Doesn't work in Fabric prior to 26.1 because obfuscation is still ON.
*/

events.onServerToClientPacket(event => {
    if (event.packet is Java<net.minecraft.network.protocol.game.ClientboundSoundPacket>) {
        let s = event.packet as Java<net.minecraft.network.protocol.game.ClientboundSoundPacket>;
        ui.systemMessage(s.getSound().getRegisteredName());
    }
});