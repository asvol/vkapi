using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ManyConsole;
using NLog;
using VkApi;

namespace VkShell
{
    


    public class GetGroupFriends:ConsoleCommand
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private string _app;
        private string _login;
        private string _pas;
        private string _out;
        private string _in;
        private IVkApi _api;
        private const int SyncPartSize = 1000;

        public GetGroupFriends()
        {
            IsCommand("ggf","get list of group from file, get all friends and put it into file");
            HasOption("app=", "application number", _ => _app = _);
            HasOption("l|login=", "vk login", _ => _login = _);
            HasOption("p|pass=", "vk password", _ => _pas = _);
            HasOption("in=", "file with group screenNames or group id. One line - one group", _ => _in = _);
            HasOption("out=", "output file with all friends. Format: |Gid|GidScreenName|UserId|State|Comment", _ => _out = _);
        }

        public override int Run(string[] remainingArguments)
        {
            RunAsync().Wait();
            return 0;
        }

        private async Task RunAsync()
        {
            var groups = File.ReadAllLines(_in);
            _api = await VkLogin.SimpleLoginAndGetApi(_app, _login, _pas, VkScope.Friends);
            var items = new List<GroupFriendsFileLine>();

            foreach (var gr in groups)
            {
                var arr = await GetFriends(gr);
                items.AddRange(arr);
                //может вызываться слишком быстро
                Thread.Sleep(500);
            }

            if (File.Exists(_out)) File.Delete(_out);

            using (var outFile = new StreamWriter( File.OpenWrite(_out)))
            {
                foreach (var item in items)
                {
                    outFile.WriteLine(item.Serialize());
                }
            }
        }

        private async Task<GroupFriendsFileLine[]> GetFriends(string grStr)
        {
            int gid;

            if (int.TryParse(grStr, out gid))
            {
                return (await _api.Groups.GetAllMembers(gid)).Select(_=>new GroupFriendsFileLine{Gid = gid,UserId = _}).ToArray();
                
            }
            else
            {
                return (await _api.Groups.GetAllMembers(grStr)).Select(_=>new GroupFriendsFileLine{GidScreenName = grStr,UserId = _}).ToArray();
            }
            
        }
    }
}