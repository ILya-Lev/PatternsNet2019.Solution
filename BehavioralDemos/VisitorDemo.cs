using System;
using Behavioral.Visitor;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace BehavioralDemos
{
    public class VisitorDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        private readonly Equipment[] _equipments;
        private Bus _bus;

        public VisitorDemo(TestOutputHelper output)
        {
            _output = output;

            _bus = new Bus("device bus");
            _bus.AddDevice(new Equipment("floppy disk controller"));
            _bus.AddDevice(new Equipment("keyboard controller"));
            _bus.AddDevice(new Equipment("mouse controller"));

            _equipments = new[]
            {
                new Equipment("Light Bulb"),
                new FloppyDisk("3.5' old one"),
                new Card("ancient card"),
                _bus,
                new Monitor("the monitor!"), 
            };
        }

        [Fact]
        public void InventoryVisitor_TraverseEquipment_CollectAllNames()
        {
            var visitor = new InventoryVisitor();
            foreach (var e in _equipments)
            {
                e.Accept(visitor);
            }

            _output.WriteLine(visitor.EquipmentNames);
            //5 eq in the array and e[3] contains 3 items inside => 5+3 = 8
            visitor.EquipmentNames.Trim().Split(Environment.NewLine).Should().HaveCount(8);
        }

        [Fact]
        public void PriceVisitor_TraverseEquipment_CollectTotalPrice()
        {
            var visitor = new PriceVisitor(3);
            foreach (var e in _equipments)
            {
                e.Accept(visitor);
            }

            _output.WriteLine($"total price is: {visitor.TotalPrice()}");
            //the visitor in its current impl takes net price of equipment and there are 4 instances in the list => 4*100
            visitor.TotalPrice().Should().BeGreaterThan(400);

            visitor.Reset();
            _bus.Accept(visitor);

            _output.WriteLine($"bus and its devices price is: {visitor.TotalPrice()}");
        }
    }
}