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

            for (int floorCounter = Floor; floorCounter <= 6; floorCounter++)
            {
                if (elevatorRequests.Any(r => r.FloorStart == floorCounter || r.FloorEnd == floorCounter))
                {
                    this._elevatorStops.Add(floorCounter);
                    lastFloor = floorCounter;
                }
            }

            bool isGoingDownNeeded = elevatorRequests.Any(r => r.FloorEnd < r.FloorStart);

            if (isGoingDownNeeded)
            {
                for (int floorCounter = 6; floorCounter >= -1; floorCounter--)
                {
                    if (elevatorRequests.Any(r => r.FloorEnd == floorCounter))
                    {
                        this._elevatorStops.Add(floorCounter);
                        lastFloor = floorCounter;
                    }
                }
            }

            Floor = lastFloor;
        }

        public int [] GetElevatorStops()
        {
            return this._elevatorStops.ToArray();
        }
    }
}