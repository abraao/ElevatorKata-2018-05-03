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
            foreach (var elevatorRequest in elevatorRequests)
            {
                this._elevatorStops.Add(elevatorRequest.FloorEnd);
            }            
        }

        public int [] GetElevatorStops()
        {
            return this._elevatorStops.ToArray();
        }
    }
}