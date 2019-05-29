using System;

namespace testarossa.Core.Domain
{
    public class Stop
    {
        public Guid Id { get; protected set;}
        public Node Node {get; protected set;}
        public Passenger Passenger {get; protected set;}
    }
}