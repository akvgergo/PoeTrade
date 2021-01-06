using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade.Filtering {
    
    /// <summary>
    /// Represents the different defense values for an item.
    /// </summary>
    [QueryComponent("armour_filters")]
    public class DefenseFilter : IFilterComponent {

        [QueryComponent("ar")]
        public RangeFilter Armor { get; set; }

        [QueryComponent("es")]
        public RangeFilter EnergyShield { get; set; }

        [QueryComponent("ev")]
        public RangeFilter Evasion { get; set; }

        [QueryComponent("block")]
        public RangeFilter Block { get; set; }

        public DefenseFilter(
            RangeFilter ar = null,
            RangeFilter es = null,
            RangeFilter ev = null,
            RangeFilter b = null
        )
        {
            Armor = ar;
            EnergyShield = es;
            Evasion = ev;
            Block = b;
        }
    }
}
