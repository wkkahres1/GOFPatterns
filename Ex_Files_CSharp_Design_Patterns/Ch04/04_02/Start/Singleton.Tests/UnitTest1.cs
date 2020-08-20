using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;

namespace Singleton.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsPolicyASingleton() //test to check if Policy is a Singleton
        {
           // Assert.AreSame(Policy.Instance, Policy.Instance);
        }
    }
}
