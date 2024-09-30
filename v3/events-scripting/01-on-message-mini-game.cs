// this script automatically solves ingame chat game
// server sends message like this:
// "[Chat game] Solve: 325 + 976"
// and you are supposed to send result in the chat

events.onChatMessage(text => {
    string[] matches = text.getMatches("\\[Chat game\\] Solve: (\\d+) \\+ (\\d+)");
    if (matches.length == 3) {
        int num1;
        int num2;
        if (int.tryParse(matches[1], ref num1) && int.tryParse(matches[2], ref num2)) {
            player.chat((num1 + num2).toString());
        }
    }
});