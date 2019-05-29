using System;
using System.Collections.Generic;

namespace testarossa.Core.Domain
{
    public class Trip
    {
        public Guid Id { get; protected set;}
        public Route Route {get; protected set;}
        public IEnumerable<Stop> Stops {get; protected set;}
    }
}