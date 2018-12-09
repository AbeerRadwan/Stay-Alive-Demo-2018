using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;




namespace nunit_test
{
    [TestFixture]
    public class  TestClass
    {


        [Test]
        public static void testNunitName()
        {
            var p = new stayAliveNameTest();
            bool result = stayAliveNameTest.testName("");
            Assert.AreEqual(true, result);
        }

       
       



    }
}
