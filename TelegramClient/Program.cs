using System;
using System.Configuration;
using Telegram.Bot;

namespace TelegramClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramBotClient bot = new TelegramBotClient(getToken());
            var me = bot.GetMeAsync().Result;

            Console.Title = me.Username;

            bot.StartReceiving();
            var result = bot.SendTextMessageAsync(args[0], args[1]).Result;
            bot.StopReceiving();
        }

        static string getToken()
        {
            string _token = ConfigurationManager.AppSettings["token"];
            if (_token == null)
            {
                throw new NullReferenceException("token invalido");
            }
            return _token;
        }

    }
}
