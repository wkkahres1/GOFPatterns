using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    //high level abstractions

    // Abstract Factory
    public abstract class ICreditUnionFactory
    {
        public abstract ISavingsAccount CreateSavingsAccount();
        public abstract ILoanAccount CreateLoanAccount();
    }

    // Abstract Product A
    public interface ILoanAccount { }

    // Abstract Product B
    public interface ISavingsAccount { }
}
