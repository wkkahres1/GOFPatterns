using Decorator.Component;
using Decorator.ConcreteComponent;
using Decorator.ConcreteDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Car theCar = new CompactCar();  // create new instance of compact car
            theCar = new Navigation(theCar);
            theCar = new Sunroof(theCar);
            theCar = new LeatherSeats(theCar);

            Console.WriteLine(theCar.GetDescription());
            Console.WriteLine($"{theCar.GetCarPrice():C2}"); // not sure why C2
            Console.ReadKey();
        }
    }
}
