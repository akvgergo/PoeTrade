using PoeTrade.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade {

    /// <summary>
    /// Represents a filter that can be used to match items against, or to construct a search query.
    /// </summary>
    public class ItemFilter {

        public TypeFilter Base { get; set; }

        public OffenseFilter Offense { get; set; }

        public DefenseFilter Defense { get; set; }


    }
}
