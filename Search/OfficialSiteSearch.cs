using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoeTrade.Utility;

namespace PoeTrade.Search {

    public static class OfficialSiteSearch {

        const string tradeEP = "https://www.pathofexile.com/api/trade/search/Standard";
        const string fetchEP = "https://www.pathofexile.com/api/trade/fetch/";

        static HttpClient _client;

        /// <summary>
        /// Sets the user agent header for the <see cref="HttpClient"/>. This shoud ideally be information that can be used to contact you.
        /// </summary>
        /// <remarks>
        /// Querying the official trade site is technically not supported, but as long as you don't query too much
        /// and support can contact you if they have a problem it's fine, many tools do it.
        /// </remarks>
        public static ProductInfoHeaderValue UserAgent {
            get { return _client.DefaultRequestHeaders.UserAgent.First(); }
            set {
                _client.DefaultRequestHeaders.UserAgent.Clear();
                _client.DefaultRequestHeaders.UserAgent.Add(value);
            }
        }

        /// <summary>
        /// The League you would like to query.
        /// </summary>
        public static string LeagueID { get; set; } = "Standard";

        static OfficialSiteSearch() {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent","akvgergo%40gmail.com");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
        }

        public static void Query(ItemFilter filter) {
            JObject obj = new JObject();
            var query = obj["query"] = new JObject();
            var filters = query["filters"] = new JObject(JsonParser.CreateQueryComponent(filter.Base));
            
            Console.WriteLine(
            _client.PostAsync(tradeEP, new StringContent(obj.ToString(), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result
            );
        }
    }
}
