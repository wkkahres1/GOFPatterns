using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Policy
    {
        //add constructor and Static Instance for Singleton
        private static Policy _instance;
        public static Policy Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Policy(); //include new
                }
                return _instance;
            }
        }
        public Policy()
        {

        }
        private int Id { get; set; } = 123; //Id
        private string Insured { get; set; } = "John Roy"; //name

        public string GetInsuredName() => Insured; //gets Insured?
    }
}
