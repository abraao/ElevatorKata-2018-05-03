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
            Open_Door_On_Specified_Floors(0, new[] { new[] { 0, 1 } }, new[] { 0, 1 });
        }

        [Test]
        public void Open_Doors_On_Floor_minus1_When_Moving_From_Floor_0_to_Floor_minus1()
        {
            Open_Door_On_Specified_Floors(0, new[] { new[] { 0, -1 } }, new[] { 0, -1 });
        }

        [Test]
        public void Open_Doors_On_Floors_1_and_2_When_Moving_From_Floor_0_to_Floor_2()
        {
            Open_Door_On_Specified_Floors(0, new[] { new[] { 0, 1 }, new[] { 1, 2 } }, new[] { 0, 1, 2 });
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

        [Test]
        public void Open_Door_On_Floors_2_and_3_When_Moving_From_Floor_0_to_Floor_3_With_Request_2_to_3()
        {
            Open_Door_On_Specified_Floors(0, new[] {new[] {2, 3}}, new[] {2, 3});
        }

        private void Open_Door_On_Specified_Floors(
            int elevatorInitialFloor,
            int[][] elevatorRequestsArrays,
            int[] expectedStops)
        {
            List<ElevatorRequest> elevatorRequests = new List<ElevatorRequest>();

            foreach (int[] elevatorRequest in elevatorRequestsArrays)
            {
                elevatorRequests.Add(new ElevatorRequest
                {
                    FloorStart = elevatorRequest[0],
                    FloorEnd = elevatorRequest[1]
                });
            }

            Elevator elevator = new Elevator(elevatorInitialFloor);
            elevator.Operate(elevatorRequests);

            Assert.AreEqual(expectedStops, elevator.GetElevatorStops());
        }
    }
}
