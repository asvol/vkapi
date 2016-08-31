namespace VkApi
{
    public class VkRequestCapchaNeededException:VkRequestErrorException
    {
        public VkRequestCapchaNeededException(string message, VkResultError error) : base(message, error)
        {

        }

    }
}