using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class SetLightForCinema : IUseCase
    {
        private IRelay lampInHall, lampInRoom, NightLamp;
        public SetLightForCinema(IRelay lh,IRelay lr, IRelay nl)
        {
            lampInHall = lh;
            lampInRoom = lr;
            NightLamp = nl;
        }
        public void Action()
        {
            lampInRoom.Off();
            lampInHall.Off();
            NightLamp.On();
        }
        public void EmergencyStop()
        {
            lampInHall.On();
            lampInRoom.On();
            NightLamp.Off();
        }
    }
}
