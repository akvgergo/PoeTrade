using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoeTrade.Filtering;
using PoeTrade.Search;

namespace PoeTrade.Utility {

    /// <summary>
    /// Handles dirty json parsing.
    /// </summary>
    /// <remarks>
    /// The official querries have some.. quirks
    /// Aside from redundant wrapping and questionable naming, where the naming isn't questionable the names are too short to create
    /// convenient classes that can just be thrown at a json parser and call it done. The querry building is instead handled using 
    /// Attributes, and creating a custom newtonsoft based parser for that is way more work that just throwing this together.
    /// </remarks>
    public static class JsonParser {

        public static JProperty CreateQueryComponent(this IFilterComponent comp) {
            var type = comp.GetType();
            var props = type.GetProperties();

            JObject filterGroup = new JObject();
            JObject filters = new JObject();

            foreach (var prop in props) {
                var value = prop.GetValue(comp);
                if (value == null) continue;
                
                var attr = prop.CustomAttributes.OfType<QueryComponentAttribute>().FirstOrDefault();
                if (attr == null || attr.Ignore) continue;

                var filter = new JObject();

                if (prop.PropertyType == typeof(RangeFilter)) {
                    filter[attr.Name] = ParseRange((RangeFilter)value);
                } else if (prop.PropertyType.IsEnum) {
                    filter[attr.Name] = ParseOption((Enum)value);
                } else {
                    filter[attr.Name] = new JValue(value);
                }

                filters.Add(filter);
            }

            filterGroup["filters"] = filters;
            
            return new JProperty(type.GetCustomAttributes(false).OfType<QueryComponentAttribute>().First().Name, filterGroup);
        }

        public static JObject ParseRange(RangeFilter range) {
            JObject obj = new JObject();
            if (range.Min.HasValue) obj["min"] = range.Min;
            if (range.Max.HasValue) obj["max"] = range.Max;
            return obj;
        }

        public static JProperty ParseOption(Enum value) {
            var option = value.GetType().GetMember(value.ToString()).First();

            return new JProperty("option", option.GetCustomAttributes(false).OfType<QueryComponentAttribute>().First().Name);
        }

        public static JProperty ParseSortOption(this SortOption so) {
            return new JProperty(so.Stat, so.Direction);
        }
    }
}
