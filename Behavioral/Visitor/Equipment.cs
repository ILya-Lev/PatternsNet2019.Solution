using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Visitor
{
    public class Equipment
    {
        public Equipment(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public virtual int NetPrice() => 100;
        public virtual int DiscountedPrice() => 85;

        public virtual void Accept(IEquipmentVisitor visitor) => visitor.VisitEquipment(this);

        #region equiality
        public override int GetHashCode()
        {
            unchecked
            {
                const int magic = 159 * 357 * 1681 * 3489;
                return magic ^ Name.GetHashCode();
            }
        }

        public override bool Equals(object obj) => obj is Equipment e && e?.Name == Name;
        #endregion equiality
    }

    public class Card : Equipment
    {
        public Card(string name) : base(name) {}
        public override void Accept(IEquipmentVisitor visitor) => visitor.VisitCard(this);
        public override int NetPrice() => 15;
        public override int DiscountedPrice() => 11;
    }

    public class Bus : Equipment
    {
        private readonly HashSet<Equipment> _devices = new HashSet<Equipment>();
        public Bus(string name) : base(name) { }
        public void AddDevice(Equipment e) => _devices.Add(e);
        
        public override void Accept(IEquipmentVisitor visitor)
        {
            foreach (var device in _devices)
            {
                device.Accept(visitor);
            }
            
            visitor.VisitBus(this);
        }

        public override int NetPrice() => 3;
        public override int DiscountedPrice() => 1;
    }

    public class FloppyDisk : Equipment
    {
        public FloppyDisk(string name) : base(name){}
        public override void Accept(IEquipmentVisitor visitor) => visitor.VisitFloppyDisk(this);
        public override int NetPrice() => 17;
        public override int DiscountedPrice() => 12;
    }

    public class Monitor : Equipment
    {
        public Monitor(string name) : base(name){}
        public override void Accept(IEquipmentVisitor visitor)
        {
            visitor.VisitMonitor(this);
        }
    }


}
