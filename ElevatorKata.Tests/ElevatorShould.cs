using NUnit.Framework;

namespace ElevatorKata.Tests
{
    [TestFixture]
    class ElevatorShould
    {
        [Test]
        public void StartAtAFloor()
        {
            int floor = 0;

            Elevator elevator = new Elevator(floor);

            Assert.AreEqual(floor, elevator.Floor);
        }
    }
}
