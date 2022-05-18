using Microsoft.VisualStudio.TestTools.UnitTesting;
using Books.Services;

namespace BookTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var serv = new TestService();
            int a = 1;
            int b = 2;

            var x = serv.MagicThing(a, b, "a");

            Assert.AreEqual(a + b, x, "ашибка!!!1!!!1");

        }

        [TestMethod]
        public void TestMethod2()
        {
            var serv = new TestService();
            int a = 1;
            int b = 2;

            var x = serv.MagicThing(a, b, null);

            Assert.AreEqual(a + b, x, "ашибка!!!1!!!1");
        }
    }
}
