using System;

namespace VkApi
{
    [Serializable]
    public class VkRequestErrorException : Exception
    {
        public VkResultError Error { get; private set; }

        public VkRequestErrorException(string message, VkResultError error)
            : base(message)
        {
            Error = error;
        }
    }
}