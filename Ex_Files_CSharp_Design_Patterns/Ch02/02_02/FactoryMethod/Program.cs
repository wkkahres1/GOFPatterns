using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //1) create instance of factory and set as a type of ICreditUnionFactory 
            var factory = new SavingsAcctFactory() as ICreditUnionFactory; //<-- learn this... still works if removed

            //2) pass in acct number to allow the program to choose which acct to grab.
            var citiAcct = factory.GetSavingsAccount("CITI-321");
            var nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

            Console.WriteLine($"My citi balance is ${citiAcct.Balance}" +
                $" and national balance is ${nationalAcct.Balance}");
        }

    }

    // Product
    /* added one property for balance */
    public abstract class ISavingsAccount
    {
        public decimal Balance { get; set; }
    }

    // Concrete Product
    /*Inherits from ISavings acct*/
    public class CitiSavingsAcct : ISavingsAccount
    {
        public CitiSavingsAcct()
        {
            Balance = 5000;
        }
    }

    // Concrete Product
    /*Inherits from ISavings acct*/
    public class NationalSavingsAcct : ISavingsAccount
    {
        public NationalSavingsAcct()
        {
            Balance = 2000;
        }
    }

    // Creator
    /*creates savings acct with acct number*/
    interface ICreditUnionFactory
    {
        ISavingsAccount GetSavingsAccount(string acctNo);
    }

    // Concrete Creators
    /*implements ICreditUnion factory*/
    public class SavingsAcctFactory : ICreditUnionFactory
    {
        public ISavingsAccount GetSavingsAccount(string acctNo) //contains logic to be sent back
        {
            if (acctNo.Contains("CITI")) { return new CitiSavingsAcct(); }
            else
            if (acctNo.Contains("NATIONAL")) { return new NationalSavingsAcct(); }
            else
                throw new ArgumentException("Invalid Account Number");
        }
    }


}
