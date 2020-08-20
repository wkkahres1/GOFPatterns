using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the Flyweight pattern in which a relatively 
/// small number of shape objects is shared several times.
/// </summary>
namespace Flyweight_WK
{
    /// <summary>
    /// Flyweight Design Pattern.
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            // TODO
            //Create ShapeObjectFactory
            ShapeObjectFactory sof = new ShapeObjectFactory();

            //Get shapes
            //triangle created only once
            IShape shape = sof.GetShape("Triangle");
            shape.Print();

            shape = sof.GetShape("Triangle");
            shape.Print();

            shape = sof.GetShape("Triangle");
            shape.Print();

            //square created only once
            shape = sof.GetShape("Square");
            shape.Print();

            shape = sof.GetShape("Square");
            shape.Print();

            shape = sof.GetShape("Square");
            shape.Print();

            int total = sof.TotalObjectsCreated;
            Console.WriteLine($"\n Number of objects created = {total}");
            //only 2
           

        }
    }
    /// <summary>
    /// The 'Flyweight' interface
    /// </summary>
    interface IShape
    {
        void Print();
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class Triangle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Triangle");
        }
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class Square : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Square");
        }
    }

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    class ShapeObjectFactory
    {
        Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public int TotalObjectsCreated
        {
            get { return shapes.Count; }
        }

        public IShape GetShape(string ShapeName)
        {
            IShape shape = null;
            if (shapes.ContainsKey(ShapeName))
            {
                shape = shapes[ShapeName];
            }
            else
            {
                switch (ShapeName)
                {
                    case "Triangle":
                        shape = new Triangle();
                        shapes.Add("Triangle", shape);
                        break;
                    case "Square":
                        shape = new Square();
                        shapes.Add("Square", shape);
                        break;
                    default:
                        throw new Exception("The factory cannot " +
                            "create the object specified");
                }
            }
            return shape;
        }
    }
}
