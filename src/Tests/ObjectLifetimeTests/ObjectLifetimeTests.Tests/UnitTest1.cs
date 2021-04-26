using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectLifetimeTests.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var button = new Microsoft.UI.Xaml.Controls.Button();
            Assert.IsNull(button);
            Assert.IsTrue(true);
        }
    }
}
