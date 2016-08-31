namespace VkApi
{
    public class VkApi : IVkApi
    {
        private readonly string _accessToken;
        private IVkFriendsApi _friends;
        private IVkGroupsApi _groups;
        private IVkUsersApi _users;
        private IVkBoardsApi _boards;
        private IVkMessages _messages;

        public VkApi(string accessToken)
        {
            _accessToken = accessToken;
        }

        public IVkFriendsApi Friends { get { return _friends ?? (_friends = new VkFriendsApi(_accessToken)); } }
        public IVkUsersApi Users { get { return _users ?? (_users = new VkUsersApi(_accessToken)); } }
        public IVkGroupsApi Groups { get { return _groups ?? (_groups = new VkGroupsApi(_accessToken)); } }
        public IVkBoardsApi Boards { get { return _boards ?? (_boards = new VkBoardsApi(_accessToken)); } }
        public IVkMessages Messages { get { return _messages ?? (_messages = new VkMessages(_accessToken)); } }
    }
}