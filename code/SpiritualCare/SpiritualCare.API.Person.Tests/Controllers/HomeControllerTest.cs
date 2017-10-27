using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiritualCare.API.Person;
using SpiritualCare.API.Person.Controllers;

namespace SpiritualCare.API.Person.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
