using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade {

    /// <summary>
    /// Represents the base rarity of an item.
    /// </summary>
    [QueryComponent("rarity")]
    public enum ItemRarity {
        [QueryComponent("", true)]
        Any,
        [QueryComponent("normal")]
        Normal,
        [QueryComponent("magic")]
        Magic,
        [QueryComponent("rare")]
        Rare,
        [QueryComponent("unique")]
        Unique,
        [QueryComponent("uniquefoil")]
        Relic,
        [QueryComponent("nonunique")]
        Non_Unique,
    }
}
