using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ManyConsole;
using Newtonsoft.Json;
using NLog;
using VkApi;

namespace VkShell
{
    public class GetFriends:ConsoleCommand
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private string _app;
        private string _login;
        private string _pas;
        private string _file;
        private const int SyncPartSize = 1000;
        private readonly List<VkUserResult> _data = new List<VkUserResult>();
        private string _format;

        public GetFriends()
        {
            IsCommand("gmf","get all friends current user and put it into file");
            HasOption("app=", "application number", _ => _app = _);
            HasOption("l|login=", "vk login", _ => _login = _);
            HasOption("p|pass=", "vk password", _ => _pas = _);
            HasOption("out=", "output file", _ => _file = _);
            HasOption("format=", "format of file:UID(default),FULL", _ => _format = _);
        }

        public override int Run(string[] remainingArguments)
        {
            RunAsync().Wait();
            return 0;
        }

        private async Task RunAsync()
        {
            _data.Clear();
            try
            {
                var api = await VkLogin.SimpleLoginAndGetApi(_app, _login, _pas, VkScope.Friends);

                var offset = 0;
                var success = 0;
                var errors = 0;
                while (true)
                {
                    Logger.Trace("Request {0} - {1} users", offset, offset + SyncPartSize);
                    var vkUserInfo = await api.Friends.GetAllInfo(offset: offset, count: SyncPartSize);
                    if (vkUserInfo.Length == 0) break;
                    foreach (var vkFriendsResult in vkUserInfo)
                    {
                        Write(vkFriendsResult, ref success, ref errors);
                    }
                    offset += SyncPartSize;
                }

                Logger.Info("Complete. Success: {0}, Errors: {1}", success, errors);
                Logger.Info("Write to file");

                Save(_file,_format);
                
                
                

                

            }
            catch (Exception ex)
            {
                Logger.ErrorException("Something wrong!", ex);

            }

            
        }

        private void Save(string path,string format)
        {
            if (File.Exists(path)) File.Delete(path);
            using (var file = File.OpenWrite(path))
            {
                switch (format)
                {
                    case "FULL":
                        File.WriteAllText(path, JsonConvert.SerializeObject(_data));
                        break;
                    default:
                        File.WriteAllText(path,JsonConvert.SerializeObject(_data.Select(_ => _.Uid)));
                        break;
                }
                
            }
            
        }

        private void Write(VkUserResult vkFriendsResult, ref int success, ref int errors)
        {
            _data.Add(vkFriendsResult);
            success++;

        }
    }
}