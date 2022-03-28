using System;
using System.Configuration;
using Telegram.Bot;

namespace TelegramClient
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                try
                {
                    TelegramBotClient bot = new TelegramBotClient(getToken());
                    var me = bot.GetMeAsync().Result;

                    Console.Title = me.Username;

                    var result = bot.SendTextMessageAsync(args[0], args[1]).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}"
                                + $"TelegramClient: {Environment.NewLine}"
                                + $"Um client para enviar mensagens para o Telegram. {Environment.NewLine}");
                Console.WriteLine($"Modo de Uso:"
                                + $"{Environment.NewLine}"
                                + $"TelegramClient <CHATID>  <MSG>"
                                + $"{Environment.NewLine}"
                                + $"\t CHATID: Numero identificador do grupo ou usuario no telegram."
                                + $"{Environment.NewLine}"
                                + $"\t MSG: O texto no qual deseja enviar."
                                + $"{Environment.NewLine}" + $"{Environment.NewLine}"
                                + $"Configuração:{Environment.NewLine}"
                                + $"Altere o arquivo de configuração incluindo o token do seu bot.");
            }
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
