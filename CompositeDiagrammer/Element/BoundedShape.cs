﻿namespace CompositeDiagrammer
{
    using System.Collections.Generic;

    using QI4N.Framework;

    public interface BoundedShapeComposite : BoundedShape, ShapeComposite
    {
    }

    [Mixins(typeof(BoundedShapeMixin))]
    public interface BoundedShape : HasDragHandles
    {
        void SetLocation(int left, int top);

        void Move(int offsetX, int offsetY);

        void SetSize(int width, int height);

        void SetBounds(int left, int top, int with, int height);

        void Rotate(double angle);
    }

    public interface BoundedShapeState
    {
        int Left { get; set; }

        int Top { get; set; }

        int Width { get; set; }

        int Height { get; set; }

        double Angle { get; set; }
    }

    public class BoundedShapeMixin : BoundedShape
    {
        private readonly IList<DragHandle> dragHandles = new List<DragHandle>();

        [This]
        private BoundedShapeState state;

        public void Move(int offsetX, int offsetY)
        {
            this.state.Left += offsetX;
            this.state.Top += offsetY;
        }

        public void Rotate(double angle)
        {
            this.state.Angle += angle;
        }

        public void SetBounds(int left, int top, int with, int height)
        {
            this.SetLocation(left, top);
            this.SetSize(with, height);
        }

        public void SetLocation(int left, int top)
        {
            this.state.Left = left;
            this.state.Top = top;
        }

        public void SetSize(int width, int height)
        {
            this.state.Width = width;
            this.state.Height = height;
        }

        public IEnumerable<DragHandle> GetDragHandles()
        {
            return dragHandles; 
        }
    }
}