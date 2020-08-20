using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the Prototype pattern in which new 
/// Color objects are created by copying pre-existing, user-defined
/// Colors of the same type.
/// </summary>
namespace Prototype_WK
{
    /// <summary>
    /// Prototype Design Pattern.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // TODO
            //Define Colorcontroller
            ColorController colorController = new ColorController();

            //Inititialize wth standard colors
            colorController["yellow"] = new Color(255, 255, 0); //<-- find on color website
            colorController["orange"] = new Color(255, 128, 0);
            colorController["purple"] = new Color(128, 0, 255);

            //User adds personalize colors
            colorController["sunny"] = new Color(255, 54, 0); //<-- personalized colors
            colorController["tasty"] = new Color(255, 153, 51);
            colorController["rainy"] = new Color(255, 0, 255);

            //User Clones selected colors
            Color c1 = colorController["yellow"].Clone() as Color; //<- specify type : as
            Color c2 = colorController["tasty"].Clone() as Color;
            Color c3 = colorController["rainy"].Clone() as Color;

        }
    }

    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    class Color : ColorPrototype
    {
        private int _yellow;
        private int _orange;
        private int _purple;

        // Constructor
        public Color(int yellow, int orange, int purple)
        {
            this._yellow = yellow;
            this._orange = orange;
            this._purple = purple;
        }

        // Create a shallow copy
        // INFORMATION:
        //  Shallow Copy: a bitwise copy, new object created that has an exact
        //   copy of the values in the original objects.. if any fields are reference jsut the 
        //   reference ADDRESSES are copied
        //  Deep Copy: copies all fields, and makes copies of the dynamically allocated memory
        //   pointed to by the fields, object is copied along with reference
        //  
        //  Clone is a C# .NET method that uses a shallow copy
        //
        public override ColorPrototype Clone()
        {
            Console.WriteLine(
              "RGB color is cloned to: {0,3},{1,3},{2,3}",
              _yellow, _orange, _purple);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    /// <summary>
    /// Prototype manager
    /// </summary>
    class ColorController
    {
        private Dictionary<string, ColorPrototype> _colors =
          new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}