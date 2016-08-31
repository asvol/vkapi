using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApi
{
    public interface IVkApi
    {
        IVkFriendsApi Friends { get; }
        IVkUsersApi Users { get; }
        IVkGroupsApi Groups { get; }
        IVkBoardsApi Boards { get; }
        IVkMessages Messages { get; }
    }
}
