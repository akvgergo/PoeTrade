using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoeTrade.Search;

namespace PoeTrade {
    class Program {

        const string tradeEP = "https://www.pathofexile.com/api/trade/search/Standard";
        const string fetchEP = "https://www.pathofexile.com/api/trade/fetch/";

        const string req = "{\"query\": {\"status\": {\"option\": \"online\"},\"name\": \"The Pariah\",\"type\": \"Unset Ring\",\"stats\": [{\"type\": \"and\",\"filters\": []}]},\"sort\": {\"price\": \"asc\"}}";

        static void Main(string[] args) {

            ItemFilter filter = new ItemFilter();
            filter.Base = new Filtering.TypeFilter();
            filter.Offense = new Filtering.OffenseFilter(aps: 2);
            OfficialSiteSearch.Query(filter);

            Console.ReadKey();

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Amateur price checker | akvgergo%40gmail.com");
            client.DefaultRequestHeaders.Add("Accept", @"text/html");

            var res = client.PostAsync(tradeEP, new StringContent(req, Encoding.UTF8, "application/json"));

            res.Wait();

            var content = res.Result.Content.ReadAsStringAsync();
            content.Wait();

            var itemsIDs = JObject.Parse(content.Result).GetValue("result").ToObject<string[]>();

            res = client.GetAsync(fetchEP + string.Join(",", itemsIDs.Take(10).ToArray()));

            res.Wait();

            content = res.Result.Content.ReadAsStringAsync();
            content.Wait();

            Console.WriteLine(content.Result);

            Console.ReadKey();
        }
    }
}
