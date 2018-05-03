using System;
using System.Collections.Generic;

namespace ElevatorKata
{
    public class Elevator
    {
        private List<int> _elevatorStops;

        public Elevator(int floor)
        {
            _elevatorStops = new List<int>();
            Floor = floor;
        }

        public int Floor { get; private set; }

        public void Operate(List<ElevatorRequest> elevatorRequests)
        {
            this._elevatorStops.Add(elevatorRequests[0].FloorEnd);
        }

        public int [] GetElevatorStops()
        {
            return this._elevatorStops.ToArray();
        }
    }
}