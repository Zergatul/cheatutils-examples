/*
* This script shows example how to work with packets.
*/

events.onServerToClientPacket(event => {
    if (event.packet is Java<net.minecraft.network.protocol.game.ClientboundSoundPacket>) {
        let s = event.packet as Java<net.minecraft.network.protocol.game.ClientboundSoundPacket>;
        ui.systemMessage(s.getSound().getRegisteredName());
    }
});