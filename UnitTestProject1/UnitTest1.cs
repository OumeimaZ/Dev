using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevOps.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var controller = new ValuesController();

            //Act
          var  result = controller.BMI(1, 1);

            //Assert(verifier output)
            Assert.AreEqual(1,result);

        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            var controller = new ValuesController();

            //Act
            var result = controller.BMI(2, 2);

            //Assert(verifier output)
            Assert.AreEqual(0.5, result);

        }
      
    }
}
