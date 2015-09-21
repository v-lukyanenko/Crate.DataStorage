using System;
using System.Collections.Generic;

namespace Crate.Core
{
    public class Tools
    {
        public static bool CheckProperyType(IReadOnlyDictionary<string, string> data, KeyValuePair<string, string> param)
        {
            var result = true;

            switch (param.Value)
            {
                case "Int32":
                    int number;
                    if (data.ContainsKey(param.Key))
                        result = int.TryParse(data[param.Key], out number);
                    break;
                case "Guid":
                    Guid guid;
                    if (data.ContainsKey(param.Key))
                        result = Guid.TryParse(data[param.Key], out guid);
                    break;
                case "DateTime":
                    DateTime dateTime;
                    if (data.ContainsKey(param.Key))
                        result = DateTime.TryParse(data[param.Key], out dateTime);
                    break;
            }

            return result;
        }
    }
}
