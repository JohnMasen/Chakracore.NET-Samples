using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextFileProcessor
{
    public class DictionaryWrapper
    {
        IDictionary<string, string> dict;
        public DictionaryWrapper(IDictionary<string, string> source)
        {
            dict = source;
        }
        public IEnumerable<string> GetKeys()
        {
            return from item in dict.Keys
                   select item;
        }

        public string GetItem(string key)
        {
            return dict[key];
        }

        public bool ContainsKey(string key)
        {
            return dict.ContainsKey(key);
        }

        public void SetItem(string key, string value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }


    }
}
