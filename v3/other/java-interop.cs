/*
* Minecraft: 1.21.11+
* CheatUtils: 3.14.12+
* Advanced Scripting: ON
* This script shows example of using Java Interop to pull command suggestions from the server.
* Doesn't work in Fabric prior to 26.1 because obfuscation is still ON.
*/

typealias Minecraft = Java<net.minecraft.client.Minecraft>;
typealias Suggestions = Java<com.mojang.brigadier.suggestion.Suggestions>;
typealias Suggestion = Java<com.mojang.brigadier.suggestion.Suggestion>;

let prefix = "a";

ui.systemMessage("§e[Lookup] Querying server for: '§f" + prefix + "§e'...");

// get vanilla objects
let mc = Minecraft.getInstance();
let connection = mc.getConnection();

if (connection is null) {
    ui.systemMessage("§cError: No connection.");
    return;
}

// use vanilla classes to get command suggestions from the server
let dispatcher = connection.getCommands();
let provider = connection.getSuggestionsProvider();
let parseResults = dispatcher.parse(prefix, provider);
let suggestionsFuture = dispatcher.getCompletionSuggestions(parseResults);

let ticks = 0;
while (!suggestionsFuture.isDone()) {
    await delay.ticks(1);
    ticks++;
    // wait for future completion no more than 60 ticks
    if (ticks > 60) {
        ui.systemMessage("§c[Lookup] Timeout.");
        return;
    }
}

let suggestions = await suggestionsFuture;
let list = suggestions.getList();

if (list.isEmpty()) {
    ui.systemMessage("§7[Lookup] No matches.");
    return;
}

// display results as system chat messages
for (let i = 0; i < list.size(); i++) {
    let suggestion = #cast(list.get(i), Suggestion);
    if (suggestion.getText().length > 1) {
        ui.systemMessage("§a[Lookup] Found: " + suggestion.getText());
    }
}