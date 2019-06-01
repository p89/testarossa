using System;
using System.Collections.Generic;

namespace testarossa.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set;}
        public Vehicle Vehicle {get; protected set;}
        public IEnumerable<Route> Routes {get; protected set;}
        public IEnumerable<Trip> Trips {get; protected set;}

        protected Driver() 
        {
        }

        public Driver (Guid userId)
        {
            UserId = userId;
        }
    }
}