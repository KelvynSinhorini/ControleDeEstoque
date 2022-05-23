using Newtonsoft.Json;
using System.ComponentModel;

namespace ControleEstoque.Models
{
    public enum MessageType
    {
        [Description("Informação")]
        Information,
        [Description("Erro")]
        Error
    }

    public class Message
    {
        public Message(string text, MessageType type = MessageType.Information)
        {
            Text = text;
            Type = type;
        }

        public MessageType Type { get; set; }
        public string Text { get; set; }

        public static string Serialize(string text, MessageType type = MessageType.Information)
        {
            var message = new Message(text, type);
            return JsonConvert.SerializeObject(message);
        }

        public static Message Deserialize(string messageJson)
        {
            var message = JsonConvert.DeserializeObject<Message>(messageJson);
            return message;
        }
    }
}
