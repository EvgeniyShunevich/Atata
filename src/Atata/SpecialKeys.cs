﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Atata
{
    public static class SpecialKeys
    {
        static SpecialKeys()
        {
            ValueNameMap = ResolveValueNameMap();
        }

        public static Dictionary<char, string> ValueNameMap { get; }

        private static Dictionary<char, string> ResolveValueNameMap()
        {
            try
            {
                FieldInfo[] fields = typeof(OpenQA.Selenium.Keys).GetFields(BindingFlags.Static | BindingFlags.Public);
                return fields.
                    Select(x => new NameValuePair(x.Name, ((string)x.GetValue(null))[0])).
                    Distinct(new NameValuePairComparer()).
                    ToDictionary(x => x.Value, x => x.Name);
            }
            catch
            {
                // For the case when something will change in <c>OpenQA.Selenium.Keys</c> class.
                return new Dictionary<char, string>();
            }
        }

        public static string Replace(string keys)
        {
            StringBuilder builder = new StringBuilder();

            string specialKeyName;

            foreach (char key in keys)
            {
                if (ValueNameMap.TryGetValue(key, out specialKeyName))
                    builder.Append($"<{specialKeyName}>");
                else
                    builder.Append(key);
            }

            return builder.ToString();
        }

        private class NameValuePair
        {
            public NameValuePair(string name, char value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; }

            public char Value { get; }
        }

        private class NameValuePairComparer : IEqualityComparer<NameValuePair>
        {
            public bool Equals(NameValuePair x, NameValuePair y)
            {
                return Equals(x.Value, y.Value);
            }

            public int GetHashCode(NameValuePair obj)
            {
                return obj.Value.GetHashCode();
            }
        }
    }
}
