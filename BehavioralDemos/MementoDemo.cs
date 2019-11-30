using System;
using Behavioral.Memento;
using Xunit;
using Xunit.Sdk;

namespace BehavioralDemos
{
    public class MementoDemo : IClassFixture<TestOutputHelper>
    {
        private readonly TestOutputHelper _output;
        public MementoDemo(TestOutputHelper output) { _output = output; }

        [Fact]
        public void CommandWorkflow_TheSameRectangleMoveFewTimesAndUndo_RestoresInitialState()
        {
            var topLeft = new Point(1.0, 4.0);
            var bottomRight = new Point(3.0, 2.0);

            var rectangle = new Rectangle(15614, topLeft, bottomRight);
            Print(rectangle);

            var moveCommand = new MoveCommand(rectangle);

            moveCommand.Execute(1);
            Print(rectangle);
            moveCommand.Execute(dy: 2);
            Print(rectangle);
            moveCommand.Execute(1, 1);
            Print(rectangle);
            moveCommand.Execute();
            Print(rectangle);

            moveCommand.Undo();
            Print(rectangle);
            moveCommand.Undo();
            Print(rectangle);
            moveCommand.Undo();
            Print(rectangle);
            try
            {
                moveCommand.Undo();
            }
            catch (Exception exc)
            {
                _output.WriteLine(exc.Message);
                Print(rectangle);
            }
        }

        private void Print(Rectangle r)
        {
            _output.WriteLine($"TL_X={r.TopLeft.X} TL_Y={r.TopLeft.Y} BR_X={r.BottomRight.X} BR_Y={r.BottomRight.Y}");
        }
    }
}