using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade.Search {
    
    /// <summary>
    /// Represents a sorting option. If no stat is defined, price will be used.
    /// </summary>
    public class SortOption {

        public SortDirection Direction { get; protected set; }

        public string Stat { get; protected set; }

        public SortOption(string stat = "price", SortDirection dir = SortDirection.Ascending) {
            Direction = dir;
            Stat = stat;
        }
    }

    public enum SortDirection {
        Ascending,
        Descending
    }
}
