using System;

namespace VkApi
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumValueAttribute:Attribute
    {
        public string Value { get; private set; }

        public EnumValueAttribute(string value)
        {
            Value = value;
        }
    }
}