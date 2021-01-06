using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade.Filtering {

    /// <summary>
    /// Represents the different attack values for an item.
    /// </summary>
    [QueryComponent("weapon_filters")]
    public class OffenseFilter : IFilterComponent {

        [QueryComponent("damage")]
        public RangeFilter Damage { get; set; }

        [QueryComponent("aps")]
        public RangeFilter APS { get; set; }
        
        [QueryComponent("dps")]
        public RangeFilter DPS { get; set; }

        [QueryComponent("pdps")]
        public RangeFilter P_DPS { get; set; }

        [QueryComponent("edps")]
        public RangeFilter E_DPS { get; set; }

        [QueryComponent("crit")]
        public RangeFilter CritChance { get; set; }

        public OffenseFilter(
            RangeFilter damage = null,
            RangeFilter aps = null,
            RangeFilter dps = null,
            RangeFilter p_dps = null,
            RangeFilter e_dps = null,
            RangeFilter critChance = null
        )
        {
            Damage = damage;
            APS = aps;
            DPS = dps;
            P_DPS = p_dps;
            E_DPS = e_dps;
            CritChance = critChance;
        }
    }
}
