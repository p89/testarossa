using System;
using System.Collections.Generic;

namespace testarossa.Core.Domain
{
    public class Passenger
    {
        public Guid Id { get; protected set;}
        public Guid UserId { get; protected set;}
        public Node Address {get; protected set;}
    }
}