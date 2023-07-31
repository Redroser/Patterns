using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.AdapterPattern
{
    class Driver
    {
        public void Travel(ITransport transport) {
            transport.Drive();
        }
    }
}
