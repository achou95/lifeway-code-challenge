using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using LifewayMessage.Models;
using LifewayMessage.Services;

// Controller has a post function to return the word count
// of the user inputted message that includes both id and message.
// Id's cannot be repeated. If repeated, the messages are
// ignored.
// Id's cannot be empty.
// Id's with empty messages are ignored.
// Returns a json file with the word count.
namespace LifewayMessage.Controllers
{
    [Produces("application/json")]
    [Route("api/messages")]
    public class MessageController: Controller
    {
        [HttpGet]
        public ActionResult<List<Message>> Get() =>
            MessageService.Get();
        
        [HttpPost]
        public void Post(Message m)
        {
            var resp = MessageService.Add(m);
            var jsonString = JsonSerializer.Serialize(resp);
            System.IO.File.WriteAllText("count.json", jsonString);
        }
    }
}