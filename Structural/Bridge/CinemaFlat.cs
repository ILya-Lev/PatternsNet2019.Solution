using System.Text;

namespace Structural.Bridge
{
    class CinemaFlat : ICinema
    {
        private IRelay lightInRoom;
        private IRelay projector;
        private IEngine windowBlinds;

        public CinemaFlat(IRelay lr,IRelay p, IEngine wb)
        {
            lightInRoom = lr;
            projector = p;
            windowBlinds = wb;
        }
        public string Show()
        {
            var sb = new StringBuilder();
            sb.AppendLine(lightInRoom.Off());
            sb.AppendLine(windowBlinds.turnBack());
            sb.AppendLine(projector.On());
            return sb.ToString();
        }

        public string Stop() => projector.Off();

        public string Off()
        {
            var sb = new StringBuilder();
            sb.AppendLine(lightInRoom.On());
            sb.AppendLine(windowBlinds.turnForward());
            sb.AppendLine(projector.Off());
            return sb.ToString();
        }
    }
}
