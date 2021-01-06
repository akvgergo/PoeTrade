using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeTrade.Filtering {

    public class SocketFilter : IFilterComponent {

        public SocketValues Sockets { get; set; }

        public SocketValues Links { get; set; }

    }
}
