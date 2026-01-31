/*
* Minecraft: 1.21+
* CheatUtils: 3.3.0+
* This script is for Status Overlay module. It displays current state of Villager Roller module
*/

if (villagerRoller.isActive()) {
    overlay.center();
    overlay.middle();
    overlay.add(villagerRoller.getState());
}