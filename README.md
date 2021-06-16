# lifeway-code-challenge

## Message Word Count

### Description
A REST service that accepts a json message with two fields: `id` and `message`.
The endpoint returns a json document called `count.json` with a single field `count`
that contains the total number of words in all the messages received to that point.

Messages with duplicate ids are ignored.

Programming language: C#

### Build project
Run `dotnet build`

### Run project
Run `dotnet run`

Run a POST to `http://localhost:5000/api/messages`
with the following json format

`{"id": "messageId", "msg": "Message"}`

### Output
Json document called `count.json` is returned.
