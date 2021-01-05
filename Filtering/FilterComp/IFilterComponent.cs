using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PoeTrade.Filtering {
    
    /// <summary>
    /// Indicates that this object can be parsed as a filter into a search query.
    /// </summary>
    public interface IFilterComponent {

        /// <summary>
        /// Matches a given item against this filter.
        /// </summary>
        /// <returns>True if the item satisfies all the defined constraints.</returns>
        //bool Match(Item item);
    }
}
