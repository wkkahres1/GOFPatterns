using Decorator.Component;
using Decorator.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.ConcreteDecorator
{
    public class LeatherSeats : CarDecorator
    {
        //constructor
        public LeatherSeats(Car car) : base(car) //Permits wrapping of decorators 
            //takes in car paramter and passes it to decorator
        {
            Description = "Leather Seats";
        }

        //concatonate description passed in with current descritpion 
        public override string GetDescription() => 
                               $"{_car.GetDescription()},  {Description}";


        public override double GetCarPrice() => _car.GetCarPrice() + 2500;
    }
}
