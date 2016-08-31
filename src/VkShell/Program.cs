using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ManyConsole;

namespace VkShell
{
    class Program
    {
        private static readonly string ProgramName = Assembly.GetExecutingAssembly().GetName().Name;



        private static int Main(string[] args)
        {
            Console.WriteLine($"{ProgramName} {CurrentVersion}");

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            HandleExceptions();

            var commands = new ConsoleCommand[]
            {
                new GetFriends(),
                new GetGroupFriends(),
                new InviteFriends(),
                new SendVkMessage(),
            };

            try
            {
                return ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Unhandled exception: {0}", ex.Message);
                return -1;
            }

        }

        private static void HandleExceptions()
        {
            AppDomain.CurrentDomain.UnhandledException +=
                (sender, eventArgs) =>
                {
                    Console.WriteLine(
                        $"Unhandled AppDomain exception. Sender '{sender}'. Args: {eventArgs.ExceptionObject}");
                };
        }

        private static string CurrentVersion
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;
            }
        }
    }
}
