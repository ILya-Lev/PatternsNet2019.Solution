using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using Structural.Composite;
using Xunit;
using Xunit.Sdk;

namespace StructuralDemos
{
    public class CompositeDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        public CompositeDemo(TestOutputHelper output) => _output = output;

        private static readonly Func<IViewObject, bool> _identity = v => true;
        private static readonly Func<IViewObject, bool> _oddViews = v =>
        {
            var message = v.Draw();
            var match = Regex.Match(message, @"\d+");
            if (match.Success && int.TryParse(match.Value, out var number))
                return number % 2 == 1;
            return false;
        };

        [Fact]
        public void Composite_3Levels_CollectAllMessages()
        {
            var expectedToBeTheLast = "the very first light";

            IViewObject flat = new GroupView("this is a flat", _identity);
            IViewObject dinnerRoom = new GroupView("this is a dinner room", _identity);
            flat.Add(dinnerRoom);
            flat.Add(new LightView(expectedToBeTheLast));
            dinnerRoom.Add(new LightView("this light helps you cooking"));
            dinnerRoom.Add(new LightView("this light makes your food looks better in Insta"));
            dinnerRoom.Add(new LightView("neon lamp"));
            

            var overallMessage = flat.Draw();


            _output.WriteLine(overallMessage);
            overallMessage.Should().NotBeEmpty();
            overallMessage.Trim().Should().EndWith(expectedToBeTheLast);
        }

        [Fact]
        public void Composite_DinnerWithRandomAmountOfLamps_CollectAllMessages()
        {
            var expectedToBeTheLast = "the very first light";

            IViewObject flat = new GroupView("this is a flat", _identity);
            IViewObject dinnerRoom = new GroupView("this is a dinner room", _oddViews);
            flat.Add(dinnerRoom);
            flat.Add(new LightView(expectedToBeTheLast));
           
            
            var randomGen = new Random(DateTime.UtcNow.Millisecond);
            var amount = randomGen.Next(1, 10);
            for (int i = 0; i < amount; i++)
            {
                dinnerRoom.Add(new LightView($"lamp #{i+1}"));
            }
            

            var overallMessage = flat.Draw();


            _output.WriteLine(overallMessage);
            overallMessage.Should().NotBeEmpty();
            overallMessage.Trim().Should().EndWith(expectedToBeTheLast);
        }
    }
}
