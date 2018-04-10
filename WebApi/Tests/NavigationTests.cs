using WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebApi.Models;

namespace Tests
{
    [TestClass]
    public class NavigationTests
    {
        private NavigationController m_controller;

        [TestInitialize]
        public void Init()
        {
            m_controller = new NavigationController();
        }


        [TestMethod]
        public void CalculateDistance_WithNull()
        {
            DirectionsModel model = new DirectionsModel();
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = -1 }));
        }

        [TestMethod]
        public void CalculateDistance_WithEmptyString()
        {
            DirectionsModel model = new DirectionsModel();
            model.Directions = "";
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = -1 }));
        }

        [TestMethod]
        public void CalculateDistance_WithInValidString()
        {
            DirectionsModel model = new DirectionsModel();
            model.Directions = "W9";
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = -1 }));
        }

        [TestMethod]
        public void CalculateDistance_WithValidString()
        {
            DirectionsModel model = new DirectionsModel();
            model.Directions = "L3, R2, L5, R1, L1, L2";
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = 10 }));
        }

        [TestMethod]
        public void CalculateDistance_WithLongString()
        {
            DirectionsModel model = new DirectionsModel();
            model.Directions = "L3, R2, L5, R1, L1, L2, L2, R1, R5, R1, L1, L2, R2, R4, L4, L3, L3, R5, L1, R3, L5, L2, R4, L5, R4, R2, L2, L1, R1, L3, L3, R2, R1, L4, L1, L1, R4, R5, R1, L2, L1, R188, R4, L3, R54, L4, R4, R74, R2, L4, R185, R1, R3, R5, L2, L3, R1, L1, L3, R3, R2, L3, L4, R1, L3, L5, L2, R2, L1, R2, R1, L4, R5, R4, L5, L5, L4, R5, R4, L5, L3, R4, R1, L5, L4, L3, R5, L5, L2, L4, R4, R4, R2, L1, L3, L2, R5, R4, L5, R1, R2, R5, L2, R4, R5, L2, L3, R3, L4, R3, L2, R1, R4, L5, R1, L5, L3, R4, L2, L2, L5, L5, R5, R2, L5, R1, L3, L2, L2, R3, L3, L4, R2, R3, L1, R2, L5, L3, R4, L4, R4, R3, L3, R1, L3, R5, L5, R1, R5, R3, L1";
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = 209 }));
        }

        [TestMethod]
        public void CalculateDistance_WithLoop()
        {
            DirectionsModel model = new DirectionsModel();
            model.Directions = "L3, R2, L5, r1, L1, L2";
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = 10 }));
        }

        [TestMethod]
        public void CalculateDistance_WithLowercase()
        {
            DirectionsModel model = new DirectionsModel();
            model.Directions = "R2, R2, R2, R2, L5";
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = 5 }));
        }

        [TestMethod]
        public void CalculateDistance_WithZero()
        {
            DirectionsModel model = new DirectionsModel();
            model.Directions = "R2, L0";
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = -1 }));
        }

        [TestMethod]
        public void CalculateDistance_WithNegative()
        {
            DirectionsModel model = new DirectionsModel();
            model.Directions = "R2, L-12";
            ActionResult result = m_controller.GetDistance(model);
            Assert.IsTrue(CompareResult(result, new { result = -1 }));
        }

        private bool CompareResult(ActionResult result, object data)
        {
            return ((JsonResult)result).Data.ToString() == data.ToString();
        }
    }
}