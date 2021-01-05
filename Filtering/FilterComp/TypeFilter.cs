using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade.Filtering {
    
    /// <summary>
    /// Represents the basic stats of an item.
    /// </summary>
    [QueryComponent("type_filters")]
    public class TypeFilter : IFilterComponent {

        /// <summary>
        /// The category of the item.
        /// </summary>
        [QueryComponent("category")]
        public ItemCategory Category { get; set; }

        /// <summary>
        /// The rarity of the item.
        /// </summary>
        [QueryComponent("rarity")]
        public ItemRarity Rarity { get; set; }

        public TypeFilter(
            ItemCategory category = ItemCategory.Any,
            ItemRarity rarity = ItemRarity.Any
        )
        {
            Category = category;
            Rarity = rarity;
        }
    }
}
