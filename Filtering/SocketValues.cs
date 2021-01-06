using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade.Filtering {
    /// <summary>
    /// Represents sockets or links for an item.
    /// </summary>
    public class SocketValues {

        public RangeFilter Count { get; set; }
        
        public (int? r, int? g, int? b, int? w) Colors { get; set; }


    }
}
