using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ManyConsole;
using NLog;
using VkApi;
using VkApi.Capcha;

namespace VkShell
{
    public class InviteFriends : ConsoleCommand
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private string _app;
        private string _login;
        private string _pas;
        private string _out;
        private string _in;
        private IVkApi _api;
        private string _antigate;
        private int _count = 40;
        private string _message;
        private const int SyncPartSize = 1000;

        public InviteFriends()
        {
            IsCommand("if", "invite friends");
            HasOption("app=", "application number", _ => _app = _);
            HasOption<int>("c|count=", string.Format("count of user to invite. Default:{0}", _count), _ => _count = _);
            HasOption("l|login=", "vk login", _ => _login = _);
            HasOption("p|pass=", "vk password", _ => _pas =_);
            HasOption("m|mesage=", "message to invite", _ => _message = _);
            HasOption("an=", "antigate key", _ => _antigate = _);
            HasOption("in=", "file with users. Format: |Gid|GidScreenName|UserId|State|Comment", _ => _in = _);
            HasOption("out=", "output file with all friends", _ => _out = _);
        }

        public override int Run(string[] remainingArguments)
        {
            RunAsync().Wait();
            return 0;
        }

        private async Task RunAsync()
        {
            
            _api = await VkLogin.SimpleLoginAndGetApi(_app, _login, _pas, VkScope.Friends);
            var resolver = new Antigate(_antigate);
            var items = new List<GroupFriendsFileLine>(File.ReadAllLines(_in).Select(_=>new GroupFriendsFileLine(_)));
            var current = 0;
            foreach (var item in items.Where(_=>_.State == State.Wait))
            {
                
                try
                {
                    var res = await _api.Friends.Add(resolver, item.UserId, _message);
                    switch (res)
                    {
                        case VkAddFriendsResultEnum.SuccessRequest:
                            item.State = State.SuccessRequest;
                            current++;
                            break;
                        case VkAddFriendsResultEnum.SucessAdd:
                            item.State = State.SuccessAdd;
                            current++;
                            break;
                        case VkAddFriendsResultEnum.AlreadyRequest:
                            item.State = State.AlreadyExist;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception ex)
                {
                    Logger.ErrorException("add friend exception",ex);
                    item.Comment = ex.Message.Replace('\n', ' ').Replace('|', ' ');
                    item.State = State.Error;
                }
                item.Comment += " Complete:" + DateTime.Now.ToLongDateString();
                if (current >= _count) break;
            }


            if (File.Exists(_out)) File.Delete(_out);
            using (var outFile = new StreamWriter(File.OpenWrite(_out)))
            {
                foreach (var item in items)
                {
                    outFile.WriteLine(item.Serialize());
                }
            }
        }
        
    }
}