using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ElevatorKata.Tests
{
    [TestFixture]
    public partial class AcceptanceTest
    {
        [Test]
        public void FirstAcceptanceTest()
        {
            GivenConditions.Given()
                           .the_elevator_is_on_floor(0)
                           .And()
                           .person_wants_to_take_elevator("Matt", 0, 3)
                           .And()
                           .person_wants_to_take_elevator("Emily", 2, -1)
                           .When()
                           .the_elevator_operates()
                           .Then()
                           .the_elevator_opens_doors_on_floors(new int[] {0, 2, 3, -1});
        }

        private class GivenConditions
        {
            public int ElevatorFloor { get; private set; }

            public List<ElevatorRequest> ElevatorRequests { get; private set; }

            public GivenConditions()
            {
                ElevatorRequests = new List<ElevatorRequest>();
            }

            public static GivenConditions Given()
            {
                return new GivenConditions();
            }

            public GivenConditions the_elevator_is_on_floor(int floor)
            {
                ElevatorFloor = floor;

                return this;
            }

            public GivenConditions And()
            {
                return this;
            }

            public GivenConditions person_wants_to_take_elevator(string person, int floorStart, int floorEnd)
            {
                this.ElevatorRequests.Add(new ElevatorRequest
                {
                    Person = person,
                    FloorStart = floorStart,
                    FloorEnd = floorEnd
                });

                return this;
            }

            public WhenConditions When()
            {
                return new WhenConditions(this.ElevatorFloor, this.ElevatorRequests);
            }
        }

        private class WhenConditions
        {
            private readonly int _elevatorFloor;
            private readonly List<ElevatorRequest> _elevatorRequests;
            private Elevator _elevator;

            public WhenConditions(int elevatorFloor, List<ElevatorRequest> elevatorRequests)
            {
                _elevatorFloor = elevatorFloor;
                _elevatorRequests = elevatorRequests;
            }

            public WhenConditions the_elevator_operates()
            {
                _elevator = new Elevator(_elevatorFloor);
                _elevator.Operate(this._elevatorRequests);

                return this;
            }

            public ThenConditions Then()
            {
                return new ThenConditions(_elevator);
            }
        }

        private class ThenConditions
        {
            private readonly Elevator _elevator;

            public ThenConditions(Elevator elevator)
            {
                _elevator = elevator;
            }

            public ThenConditions the_elevator_opens_doors_on_floors(int[] floorList)
            {
                Assert.AreEqual(floorList, this._elevator.GetElevatorStops());

                return this;
            }
        }
    }
}
