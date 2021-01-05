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

        static void Main(string[] args) {

            ItemFilter filter = new ItemFilter();
            filter.Base = new Filtering.TypeFilter();
            filter.Offense = new Filtering.OffenseFilter(aps: 2);
            OfficialSiteSearch.Query(new Query(filter));

            Console.ReadKey();
        }
    }
}
