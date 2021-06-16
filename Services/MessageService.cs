using LifewayMessage.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Serilog;

namespace LifewayMessage.Services
{
    public static class MessageService
    {
        static List<Message> Messages {get;}
        static NumWords WordCount{get; set;}

        static MessageService()
        {
            Messages = new List<Message>{};
            WordCount = new NumWords{Count = 0};
        }

        public static List<Message> Get() 
        {
            return Messages;
        }

        public static NumWords Add(Message msg) {
            // If message is not provided, then return existing word count.
            // If id provided but no message, then return existing word count.
            // If message and id provided, then return previous word count plus
            // the given message's word count.
            if (msg != null && !String.IsNullOrEmpty(msg.Id) &&
                    !String.IsNullOrEmpty(msg.Msg)) {
                var match = Messages.Where(m => m.Id == msg.Id);
                // Ignores messages with duplicate ids.
                if (!match.Any()) {
                    Messages.Add(msg);
                    var wc = msg.Msg.Split(' ').Length;
                    WordCount.Count = WordCount.Count + wc;
                }
            }

            return WordCount;

        }
    }
}