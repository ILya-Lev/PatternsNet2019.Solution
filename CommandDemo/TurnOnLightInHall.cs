using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class TurnOnLightInHall : IUseCase
    {
        private IRelay hallLamp;
        public TurnOnLightInHall(IRelay hl)
        {
            hallLamp = hl;
        }
        public void Action()
        {
            hallLamp.On();
        }
    }
}
