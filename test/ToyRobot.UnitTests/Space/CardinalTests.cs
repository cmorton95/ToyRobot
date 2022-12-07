using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Application.Space;

namespace ToyRobot.UnitTests.Space 
{
    [TestClass]
    public class CardinalTests 
    {
        [TestMethod]
        public void CardinalExtensions_ToDegrees_Success()
        {
            Assert.AreEqual(0, Cardinal.NORTH.ToDegrees());            
            Assert.AreEqual(90, Cardinal.EAST.ToDegrees());
            Assert.AreEqual(180, Cardinal.SOUTH.ToDegrees());
            Assert.AreEqual(270, Cardinal.WEST.ToDegrees());
        }

        [TestMethod]
        public void CardinalHelper_ToCardinal_Success()
        {
            Assert.AreEqual(Cardinal.NORTH, CardinalHelper.GetCardinalByDegrees(0));            
            Assert.AreEqual(Cardinal.EAST, CardinalHelper.GetCardinalByDegrees(90));
            Assert.AreEqual(Cardinal.SOUTH, CardinalHelper.GetCardinalByDegrees(180));
            Assert.AreEqual(Cardinal.WEST, CardinalHelper.GetCardinalByDegrees(270));
        }
    }
}