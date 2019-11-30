using System.Text;

namespace Structural.Bridge
{
    class CinemaCottadge : ICinema
    {
        private IRelay projector;
        private IRelay lampInRoom, lampInHall;
        private IEngine wall, windowBlindes;
        public CinemaCottadge(IRelay p, IRelay lr,
            IRelay lh, IEngine w, IEngine wb)
        {
            projector = p;
            lampInRoom = lr;
            lampInHall = lh;
            wall = w;
            windowBlindes = wb;
        }
        public string Show()
        {
            var sb = new StringBuilder();
            sb.AppendLine(lampInHall.Off());
            sb.AppendLine(lampInRoom.On());
            sb.AppendLine(wall.turnForward());
            sb.AppendLine(windowBlindes.turnForward());
            return sb.ToString();
        }

        public string Stop()
        {
            var sb = new StringBuilder();
            sb.AppendLine(lampInHall.On());
            sb.AppendLine(windowBlindes.turnBack());
            return sb.ToString();
        }

        public string Off()
        {
            var sb = new StringBuilder();
            sb.AppendLine(projector.Off());
            sb.AppendLine(lampInHall.On());
            sb.AppendLine(lampInRoom.On());
            sb.AppendLine(wall.turnBack());
            sb.AppendLine(windowBlindes.turnBack());
            return sb.ToString();
        }
    }
}
