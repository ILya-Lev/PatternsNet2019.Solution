using System.Text;

namespace Behavioral.Visitor
{
    public class InventoryVisitor : IEquipmentVisitor
    {
        private readonly StringBuilder _collector = new StringBuilder();
        public string EquipmentNames => _collector.ToString();
        public void Reset() => _collector.Clear();

        public void VisitEquipment(Equipment e) => _collector.AppendLine(e.Name);

        public void VisitFloppyDisk(FloppyDisk fd) => _collector.AppendLine(fd.Name);

        public void VisitCard(Card c) => _collector.AppendLine(c.Name);

        public void VisitMonitor(Monitor monitor)
        {
            _collector.AppendLine(monitor.Name);
        }

        public void VisitBus(Bus b) => _collector.AppendLine(b.Name);
    }
}