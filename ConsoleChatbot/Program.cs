using Newtonsoft.Json;
using System;
using System.Linq;

namespace ZezinhoBot
{
    public class Program
    {
        private BotService _bot;
        
        public static void Main(string[] args)
        {
            var program = new Program();
            var msgSend = "";

            program.BotInitilization();
            Console.WriteLine("Welcome");
            Console.WriteLine("Say END to exit.");

            while (msgSend != "END")
            {
                msgSend = Console.ReadLine();
                program.Bot(msgSend);
            }
        }

        private void BotInitilization()
        {
            _bot = new BotService("YOUR GUID WORKSPACE", "IBM USER", "PASSWORD");
        }

        private void Bot(string msgSend)
        {
            var chatResponse = new BotResponseModel();
            var jsonReturn = _bot.ChatService(msgSend).GetAwaiter().GetResult();

            chatResponse = JsonConvert.DeserializeObject<BotResponseModel>(jsonReturn);

            var chatReturn = chatResponse.output.text.FirstOrDefault();
            Console.WriteLine("<< " + chatReturn);
        }
    }
}
