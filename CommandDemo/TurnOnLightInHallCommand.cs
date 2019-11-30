using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class TurnOnLightInHallCommand : Command
    {
        public TurnOnLightInHallCommand(IRelay relay) :
            base(new TurnOnLightInHall(relay))
        {

        }
    }
}
