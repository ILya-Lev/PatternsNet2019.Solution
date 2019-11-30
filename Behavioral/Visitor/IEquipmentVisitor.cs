namespace Behavioral.Visitor
{
    public interface IEquipmentVisitor
    {
        void VisitEquipment(Equipment e);
        void VisitFloppyDisk(FloppyDisk fd);
        void VisitCard(Card c);
        void VisitBus(Bus b);
        void VisitMonitor(Monitor monitor);
    }
}