using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Application.Space;

namespace ToyRobot.UnitTests.Space 
{
    [TestClass]
    public class LocationTests 
    {
        [TestMethod]
        public void Location_GetLocation_Success()
        {
            var location = new Location(0.0, 0.0);

            Assert.AreEqual((0.0, 0.0), location.GetLocation());
        }

        [TestMethod]
        public void Location_Transform_Success()
        {
            var location = new Location(0.0, 0.0);

            Assert.AreEqual(new Location(0.0, 1.0).GetLocation(), location.Transform(1, 0).GetLocation());
            Assert.AreEqual(new Location(1.0, 0.0).GetLocation(), location.Transform(1, 90).GetLocation());
            Assert.AreEqual(new Location(0.0, -1.0).GetLocation(), location.Transform(1, 180).GetLocation());
            Assert.AreEqual(new Location(-1.0, 0.0).GetLocation(), location.Transform(1, 270).GetLocation());
        }

        [TestMethod]
        public void Location_Transform_NonCardinal()
        {
            var location = new Location(0.0, 0.0);

            var ex = Assert.ThrowsException<ArgumentException>(() => location.Transform(1, 45));
            Assert.AreEqual("Direction must be a multiple of 90 (Parameter 'direction')", ex.Message);
        }
    }
}