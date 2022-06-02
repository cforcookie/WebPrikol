using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPrikol.Controllers.BuyersController;


namespace TestWP
{
    [TestClass]
    public class TestBuyers
    {
        [TestMethod]
        public void Post_Buyers_Test()
        {
            // Arrange
            var guid = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");
            var buyer = new Buyer(guid, "Platonov I. S.", null);

            // Act

            

            // Assert
        Assert.AreEqual(expected, actual, 0.001, "");
        }
    }
}
