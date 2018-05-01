using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ConfigKeyAttribute : Attribute
    {
        public string Key { get; private set; }
        public bool IsBoolean { get; private set; }
        public ConfigKeyAttribute(string key, bool isBoolean = false)
        {
            Key = "/" + key;
            IsBoolean = isBoolean;
        }
    }
}
