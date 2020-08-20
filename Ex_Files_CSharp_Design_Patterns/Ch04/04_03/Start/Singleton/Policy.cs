using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Policy
    {
        //use this to make thread safe using method 1
        //private static readonly object _lock = new object();

        //1
        //private static Policy _instance;

        //2
        private static readonly Policy _instance = new Policy();


        public static Policy Instance {
            get {
                /* use this only if using method 1
                lock (_lock) //create this to make instance threadsafe
                {

                    if (_instance == null) //<-- will not be ran at the same time
                    {
                        _instance = new Policy();
                    }
                 */
                    return _instance;
                //1
                //}
            }
        }

        public Policy()
        {

        }
        private int Id { get; set; } = 123;
        private string Insured { get; set; } = "John Roy";

        public string GetInsuredName() => Insured;
    }
}
