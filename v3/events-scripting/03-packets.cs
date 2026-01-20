/*
* cheatutils 3.11.2+, Advanced Scripting must be ON
* below code works only in Forge/NeoForge
* fabric still uses obfuscated class/method names at runtime
*/

events.onServerToClientPacket(event => {
    if (event.packet is Java<net.minecraft.network.protocol.game.ClientboundSoundPacket>) {
        let s = event.packet as Java<net.minecraft.network.protocol.game.ClientboundSoundPacket>;
        ui.systemMessage(s.getSound().getRegisteredName());
    }
});