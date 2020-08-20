using Iterator.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Aggregate
{
    // Aggregate  CREATES iterator of interface type IIterator
    public interface INewspaper
    {
        IIterator CreateIterator();
    }
}
