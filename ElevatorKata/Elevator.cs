﻿using System;
using System.Collections.Generic;

namespace ElevatorKata
{
    public class Elevator
    {
        public Elevator(int floor)
        {
            Floor = floor;
        }

        public int Floor { get; private set; }

        public void Operate(List<ElevatorRequest> elevatorRequests)
        {
            throw new NotImplementedException();
        }

        public object GetElevatorStops()
        {
            throw new NotImplementedException();
        }
    }
}