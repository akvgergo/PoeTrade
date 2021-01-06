using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoeTrade.Utility;

namespace PoeTrade.Search {

    /// <summary>
    /// Represents a search query that can be used to obtain a list of items from the official site.
    /// </summary>
    public class Query {

        public JObject QueryJson { get; protected set; }

        /// <summary>
        /// Creates a new query from an <see cref="ItemFilter"/>.
        /// </summary>
        public Query(ItemFilter filter, PlayerStatus status = PlayerStatus.Online, SortOption sort = null) {
            QueryJson = new JObject();
            var query = QueryJson["query"] = new JObject();

            QueryJson["sort"] = JsonParser.ParseSort(sort ?? new SortOption());

            query["status"] = new JObject(JsonParser.ParseOption(status));

            var filters = query["filters"] = new JObject();

            filters.Children().Append(filter.Base.CreateQueryComponent());
            filters.Children().Append(filter.Defense.CreateQueryComponent());
            filters.Children().Append(filter.Offense.CreateQueryComponent());
        }
    }

    [QueryComponent("status")]
    public enum PlayerStatus {
        [QueryComponent("any")]
        Any,
        [QueryComponent("online")]
        Online
    }
}
