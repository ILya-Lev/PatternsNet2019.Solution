using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Command
{
    class Relay : IRelay
    {
        private CheckBox checkBox;
        public Relay(CheckBox cb)
        {
            checkBox = cb;
        }
        public bool State { get; private set; }
        public void On()
        {
            State = true;
            checkBox.Checked = State;
        }

        public void Off()
        {
            State = false;
            checkBox.Checked = State;
        }
    }
}
