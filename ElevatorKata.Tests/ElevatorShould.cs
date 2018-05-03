using System.Collections.Generic;
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

        [Test]
        public void Open_Doors_On_Floor_1_When_Moving_From_Floor_0_to_Floor_1()
        {
            Elevator elevator = new Elevator(0);
            elevator.Operate(new List<ElevatorRequest>
            {
                new ElevatorRequest
                {
                    FloorStart = 0,
                    FloorEnd = 1
                }
            });

            Assert.AreEqual(new int[] { 1 }, elevator.GetElevatorStops());
        }

        [Test]
        public void Open_Doors_On_Floor_minus1_When_Moving_From_Floor_0_to_Floor_minus1()
        {
            Elevator elevator = new Elevator(0);
            elevator.Operate(new List<ElevatorRequest>
            {
                new ElevatorRequest
                {
                    FloorStart = 0,
                    FloorEnd = -1
                }
            });

            Assert.AreEqual(new int[] { -1 }, elevator.GetElevatorStops());
        }

        [Test]
        public void Open_Doors_On_Floors_1_and_2_When_Moving_From_Floor_0_to_Floor_2()
        {
            Elevator elevator = new Elevator(0);
            elevator.Operate(new List<ElevatorRequest>
            {
                new ElevatorRequest
                {
                    FloorStart = 0,
                    FloorEnd = 1
                },
                new ElevatorRequest
                {
                    FloorStart = 1,
                    FloorEnd = 2
                }
            });

            Assert.AreEqual(new int[] { 1, 2 }, elevator.GetElevatorStops());
        }

        [Test]
        public void EndAtAFloor()
        {
            Elevator elevator = new Elevator(0);
            const int expectedFinalFloor = 2;
            elevator.Operate(new List<ElevatorRequest>
            {
                new ElevatorRequest
                {
                    FloorStart = 0,
                    FloorEnd = 1
                },
                new ElevatorRequest
                {
                    FloorStart = 1,
                    FloorEnd = expectedFinalFloor
                }
            });

            Assert.AreEqual(expectedFinalFloor, elevator.Floor);
        }
    }
}
