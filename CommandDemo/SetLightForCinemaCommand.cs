using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class SetLightForCinemaCommand : Command
    {
        public SetLightForCinemaCommand(IRelay r1,IRelay r2,IRelay r3) 
            : base(new SetLightForCinema(r1,r2,r3))
        {

        }
        public override void Undo()
        {
            SetLightForCinema uc = (SetLightForCinema)useCase;
            uc.EmergencyStop();
        }
    }
}
