using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.AdapterPattern
{
    class DogTeamToTransportAdapter : ITransport
    {
        DogTeam dogTeam;
        public DogTeamToTransportAdapter(DogTeam dogTeam) {
            this.dogTeam = dogTeam;
        }
        public void Drive()
        {
            dogTeam.Move();
        }
    }
}
