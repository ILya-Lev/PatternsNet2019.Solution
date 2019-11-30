using System;

namespace Behavioral.Visitor
{
    public class PriceVisitor : IEquipmentVisitor
    {
        private readonly int _haveToVisitAtLeast;
        private int _totalPrice = 0;
        private int _amountOfVisitedObjects = 0;

        public PriceVisitor(int haveToVisitAtLeast) { _haveToVisitAtLeast = haveToVisitAtLeast;}
        
        public int TotalPrice() =>
            _amountOfVisitedObjects > _haveToVisitAtLeast 
                ? _totalPrice
                : throw new Exception($"{nameof(PriceVisitor)} have to visit" +
                                      $" at least {_haveToVisitAtLeast} objects," +
                                      $" but visited only {_amountOfVisitedObjects}");

        public void Reset()
        {
            _totalPrice = 0;
            _amountOfVisitedObjects = 0;
        }

        public void VisitEquipment(Equipment e)
        {
            _totalPrice += e.NetPrice();
            _amountOfVisitedObjects++;
        }

        public void VisitFloppyDisk(FloppyDisk fd)
        {
            _totalPrice += fd.DiscountedPrice();
            _amountOfVisitedObjects++;
        }

        public void VisitCard(Card c)
        {
            _totalPrice += c.NetPrice();
            _amountOfVisitedObjects++;
        }

        public void VisitBus(Bus b)
        {
            _totalPrice += b.DiscountedPrice();
            _amountOfVisitedObjects++;
        }

        public void VisitMonitor(Monitor monitor)
        {
            _totalPrice += monitor.DiscountedPrice();
            _amountOfVisitedObjects++;
        }
    }
}