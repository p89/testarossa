using System;

namespace testarossa.Core.Domain
{
    public class Route
    {
        public Guid Id { get; protected set;}
        public Node StartNode {get; protected set;}
        public Node EndNode {get; protected set;}
    }
}