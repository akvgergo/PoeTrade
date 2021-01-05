using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade {
    
    //TODO
    [QueryComponent("category")]
    public enum ItemCategory {
        [QueryComponent("", true)]
        Any
    }
}
