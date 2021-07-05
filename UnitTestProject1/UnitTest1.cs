using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using МДК_02.Критический;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
        oKrit o = new oKrit();
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(o.str);

        }
        [TestMethod]
        public void TestMethod2()
        {
            var t = o.Vvod();
            Assert.AreEqual(o.Dl(t), 43);
            
        }        
        [TestMethod]
        public void TestMethod3()
        {
            var t = o.Vvod();
            Assert.AreEqual(o.MinElem(t), 2);
            
        }
    }
}
