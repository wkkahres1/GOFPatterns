using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            // var policy = new Policy(); to create one instance commnet this line.. NO new needed
            // var insuredName = policy.GetInsuranceName(); update this line

            var insuredName = Policy.Instance.GetInsuredName();
            //must update Policy class to include Instance.

            Console.WriteLine(insuredName);
        }
    }
}
