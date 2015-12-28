using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lesson18_4_finish;
using lesson18_4_finish.Controllers;
using Moq;
using lesson18_4_finish.Models;

namespace lesson18_4_finish.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeControllerInstanseNotNull()
        { 
            // Arrange, Act
            HomeController controller = new HomeController();

            // Assert
            Assert.IsNotNull(controller);
        }
        [TestMethod]
        public void CreatePostAction_SaveModel()
        { 
            // Arrange 
            var mock = new Mock<IRepository>();
            HomeController controller = new HomeController(mock.Object);
            Computer comp = new Computer();

            // Act
            RedirectToRouteResult result = controller.Create(comp) as RedirectToRouteResult;
            //RedirectToRouteResult result2 = controller.Create() as RedirectToRouteResult;

            // Assert
            mock.Verify(a => a.Create(comp), Times.Exactly(1));
            mock.Verify(a => a.Save());
            mock.Verify(a => a.Create2(It.IsRegex("^1001")));
        }
        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            // arrange
            string expected = "Index";
            var mock = new Mock<IRepository>();
            Computer comp = new Computer();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToRouteResult result = controller.Create(comp) as RedirectToRouteResult;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }
        
        [TestMethod]
        public void CreatePostAction_ModelError()
        {
            // arrange
            string expected = "Create";
            var mock = new Mock<IRepository>();
            Computer comp = new Computer();
            HomeController controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");
            // act
            ViewResult result = controller.Create(comp) as ViewResult;
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }
        
        [TestMethod]
        public void IndexViewModelNotNull()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>());
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexViewBagMessage()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>() { new Computer() });
            HomeController controller = new HomeController(mock.Object);
            string expected = "В базе данных 1 объект";

            // Act
            ViewResult result = controller.Index() as ViewResult;
            string actual = result.ViewBag.Message as string;

            // Assert
            Assert.AreEqual(expected, actual);
        } 

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
