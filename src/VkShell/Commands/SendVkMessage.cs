using System;
using System.Threading.Tasks;
using ManyConsole;
using NLog;
using VkApi;
using VkApi.Capcha;

namespace VkShell
{
    public class SendVkMessage : ConsoleCommand
    {
        private string _app;
        private string _login;
        private string _pas;
        private string _msg;
        private string _uid;
        private string _antigate;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();  

        public SendVkMessage()
        {
            IsCommand("msg","send vk message");
            HasOption("app=", "application number", _ => _app = _);
            HasOption("l|login=", "vk login", _ => _login = _);
            HasOption("p|pass=", "vk password", _ => _pas = _);

            HasOption("an=", "antigate key", _ => _antigate = _);

            HasOption("uid=", "vk user id", _ => _uid = _);
            HasOption("msg=", "text message", _ => _msg = _);
        }

        public override int Run(string[] remainingArguments)
        {
            RunAsync().Wait();
            return 0;
        }

        private async Task RunAsync()
        {
            try
            {
                var api = await VkLogin.SimpleLoginAndGetApi(_app, _login, _pas, VkScope.Messages);
                var resolver = new Antigate(_antigate);

                await api.Messages.Send(resolver, _msg,int.Parse(_uid));
            }
            catch (Exception ex)
            {
                
                Logger.ErrorException("Error send message",ex);
            }

            


        }

    }
}