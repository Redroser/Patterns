using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.AdapterPattern
{
    class Bus : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Путешественник едет на автобусе");
        }
    }
}
