using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorKata
{
    public class Elevator
    {
        private HashSet<int> _elevatorStops;

        public Elevator(int floor)
        {
            _elevatorStops = new HashSet<int>();
            Floor = floor;
        }

        public int Floor { get; private set; }

        public void Operate(List<ElevatorRequest> elevatorRequests)
        {
            int lastFloor = Floor;
            foreach (var elevatorRequest in elevatorRequests)
            {
                this._elevatorStops.Add(elevatorRequest.FloorStart);
                this._elevatorStops.Add(elevatorRequest.FloorEnd);
                lastFloor = elevatorRequest.FloorEnd;
            }

            Floor = lastFloor;
        }

        public int [] GetElevatorStops()
        {
            return this._elevatorStops.ToArray();
        }
    }
}