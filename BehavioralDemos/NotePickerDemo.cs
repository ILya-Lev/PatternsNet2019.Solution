using Behavioral.ChainOfResponsibilityATM;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace BehavioralDemos
{
    public class NotePickerDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        public NotePickerDemo(TestOutputHelper output) { _output = output; }

        [InlineData(837)]
        [InlineData(10_000)]
        [Theory]
        public void GetNumberOfNotes_TotalAmount_FindSolution(int totalAmount)
        {
            var picker1 = new NotePicker(1);
            var picker2 = new NotePicker(2, picker1);
            var picker5 = new NotePicker(5, picker2);
            var picker10 = new NotePicker(10, picker5);
            var picker20 = new NotePicker(20, picker10);
            var picker50 = new NotePicker(50, picker20);
            var picker100 = new NotePicker(100, picker50);
            var picker200 = new NotePicker(200, picker100);
            var picker500 = new NotePicker(500, picker200);

            var theList = picker500.GetNumberOfNotes(totalAmount);

            theList.Should().NotContain(pair => pair.Item1 == 0);
            foreach (var item in theList)
            {
                _output.WriteLine($"Need {item.Item2} notes of {item.Item1} values.");
            }
        }
    }
}