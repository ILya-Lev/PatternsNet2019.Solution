using System;
using System.Collections.Generic;

namespace Behavioral.Memento
{
    class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y) { X = x; Y = y; }
    }

    static class PointExtensions
    {
        public static Point ShiftX(this Point p, double dx) => new Point(p.X + dx, p.Y);
        public static Point ShiftY(this Point p, double dy) => new Point(p.X, p.Y + dy);
    }

    class Rectangle
    {
        public int Id { get; }
        public Point TopLeft { get; private set; }
        public Point BottomRight { get; private set; }

        public Rectangle(int id, Point topLeft, Point bottomRight)
        {
            Id = id;
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public void SetTopLeft(Point newTopLeft) => TopLeft = newTopLeft;
        public void SetBottomRight(Point newBottomRight) => BottomRight = newBottomRight;

        public RectangleMemento CreateMemento() => new RectangleMemento(TopLeft, BottomRight);
    }

    internal class RectangleMemento
    {
        private readonly Point _topLeft;
        private readonly Point _bottomRight;

        public RectangleMemento(Point topLeft, Point bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }

        public void RestoreState(Rectangle originator)
        {
            if (_topLeft != null) originator.SetTopLeft(_topLeft);
            if (_bottomRight != null) originator.SetBottomRight(_bottomRight);
        }
    }

    class MoveCommand
    {
        private readonly Rectangle _rectangle;
        private readonly Stack<RectangleMemento> _states = new Stack<RectangleMemento>();

        public MoveCommand(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public void Execute(double? dx = null, double? dy = null)
        {
            if (dx is null && dy is null) return;

            _states.Push(_rectangle.CreateMemento());

            if (dx != null)
            {
                _rectangle.SetTopLeft(_rectangle.TopLeft.ShiftX(dx.Value));
                _rectangle.SetBottomRight(_rectangle.BottomRight.ShiftX(dx.Value));
            }

            if (dy != null)
            {
                _rectangle.SetTopLeft(_rectangle.TopLeft.ShiftY(dy.Value));
                _rectangle.SetBottomRight(_rectangle.BottomRight.ShiftY(dy.Value));
            }
        }

        public void Undo()
        {
            if (_states.Count == 0)
                throw new Exception($"No state was stored for rectangle {_rectangle.Id}");

            _states.Pop().RestoreState(_rectangle);
        }
    }
}
