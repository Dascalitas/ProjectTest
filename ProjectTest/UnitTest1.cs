using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTest.Configurations;
using System;

namespace ProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            new Browser().Init();
        }
    }
}
