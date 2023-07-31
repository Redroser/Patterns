using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.AdapterPattern
{
    class DogTeam : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Путешественник передвигается на собачей упряжке");
        }
    }
}
