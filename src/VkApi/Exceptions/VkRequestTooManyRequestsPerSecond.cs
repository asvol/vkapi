namespace VkApi
{
    public class VkRequestTooManyRequestsPerSecond : VkRequestErrorException
    {
        public VkRequestTooManyRequestsPerSecond(string errorMsg, VkResultError error)
            : base(errorMsg, error)
        {
            
        }
    }
}