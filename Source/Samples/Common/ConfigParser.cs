using System;

namespace Common
{
    public static class ConfigParser
    {
        public static T Parse<T>(string[] args) where T:new()
        {
            T result = new T();
            foreach (var item in args)
            {
                var values = item.Split(':');
                switch (values.Length)
                {
                    case 1:
                        setConfigValueByKey(result, values[0], true);
                        break;
                    case 2:
                        setConfigValueByKey(result, values[0], values[1]);
                        break;
                    default:
                        throw new ArgumentException($"invalid parameter {item}");
                }

            }
            return result;
        }

        private static void setConfigValueByKey<T>(T target, string propertyKey, object value)
        {
            var properties = target.GetType().GetProperties();
            foreach (var item in properties)
            {
                foreach (ConfigKeyAttribute configKey in item.GetCustomAttributes(typeof(ConfigKeyAttribute), false))
                {
                    if (string.Compare(configKey?.Key, propertyKey, true) == 0)
                    {
                        if (configKey.IsBoolean && value.GetType() != typeof(Boolean))
                        {
                            throw new ArgumentException($"{propertyKey} switch cannot assign value");
                        }
                        item.SetValue(target, value);
                        return;
                    }
                }
            }
        }
    }
}
