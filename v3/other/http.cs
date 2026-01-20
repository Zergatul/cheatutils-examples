/*
* This script shows examples how to send HTTP requests
*/

void httpGetExample() {
    let request = HttpRequest.createBuilder()
        .get()
        .url("http://example.com")
        .header("X-API-Key", "abc")
        .build();
    let response = await http.send(request);
    ui.systemMessage(response.body);
}

void httpPostExample() {
    let request = HttpRequest.createBuilder()
        .post("post-data")
        .url("http://example.com")
        .header("X-API-Key", "abc")
        .build();
    let response = await http.send(request);
    ui.systemMessage(response.body);
}