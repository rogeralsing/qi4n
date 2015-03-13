namespace CompositeDiagrammer
{
    using System.Collections.Generic;

    using QI4N.Framework;

    public interface DrawingService : Drawing, TransientComposite
    {
    }

    [Mixins(typeof(DrawingMixin))]
    public interface Drawing
    {
        T Create<T>() where T : Shape;

        void Remove(Shape shape);

        GroupShape Group(params IsContainable[] isContainables);

        string SayHello();
    }

    public class DrawingMixin : Drawing
    {
        private readonly IList<Shape> elements = new List<Shape>();

        [Structure]
        private TransientBuilderFactory tbf;

        public T Create<T>() where T : Shape
        {
            var element = this.tbf.NewTransient<T>();
            this.elements.Add(element);
            return element;
        }

        public GroupShape Group(params IsContainable[] isContainables)
        {
            var group = this.Create<GroupShape>();
            foreach (IsContainable containable in isContainables)
            {
                group.AddChild(containable);
            }

            return group;
        }

        public void Remove(Shape shape)
        {
            this.elements.Remove(shape);
        }

        public string SayHello()
        {
            return "hej";
        }
    }
}