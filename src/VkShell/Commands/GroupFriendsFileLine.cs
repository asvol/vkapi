using System;

namespace VkShell
{
    public enum State
    {
        Wait,
        SuccessRequest,
        SuccessAdd,
        AlreadyExist,
        Error
    }

    public class GroupFriendsFileLine
    {
        public GroupFriendsFileLine(string line)
        {
            Deserialize(line);
        }

        public GroupFriendsFileLine()
        {
            
        }

        public int Gid { get; set; }
        public string GidScreenName { get; set; }
        public int UserId { get; set; }
        public State State { get; set; }
        public string Comment { get; set; }

        public string Serialize()
        {
            return string.Format(" {0,12} | {1,12} | {2,12} | {3,3} | {4}", Gid, GidScreenName, UserId, State.ToString(),Comment);
        }

        public void Deserialize(string src)
        {
            var args = src.Split('|');

            if (!string.IsNullOrWhiteSpace(args[0])) Gid = int.Parse(args[0]);
            if (!string.IsNullOrWhiteSpace(args[1])) GidScreenName = args[1];
            if (!string.IsNullOrWhiteSpace(args[2])) UserId = int.Parse(args[2]);
            if (!string.IsNullOrWhiteSpace(args[3])) State = (State)Enum.Parse(typeof(State),args[3]);
            if (!string.IsNullOrWhiteSpace(args[4])) Comment = args[4];

        }
    }
}