using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Command
{
    public partial class Form1 : Form
    {
        private ICommand cmdTurnLightOnInHall;
        private ICommand cmdSetLightForCinema;
        private ICommand LastCommand = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IRelay lampInHall = new Relay(checkBox1);
            IRelay lampInRoom = new Relay(checkBox2);
            IRelay NightLamp = new Relay(checkBox3);

            cmdTurnLightOnInHall = new TurnOnLightInHallCommand(lampInHall);
            cmdSetLightForCinema = new SetLightForCinemaCommand(lampInHall, lampInRoom, NightLamp);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            ICommand cmd = (trackBar1.Value == 1) 
                ? cmdSetLightForCinema
                : cmdTurnLightOnInHall;
            cmd.Execute();
            LastCommand = cmd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmdTurnLightOnInHall.Execute();
            LastCommand = cmdTurnLightOnInHall;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmdSetLightForCinema.Execute();
            LastCommand = cmdSetLightForCinema;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LastCommand != null)
            {
                LastCommand.Undo();
                LastCommand = null;
            }
        }
    }
}
