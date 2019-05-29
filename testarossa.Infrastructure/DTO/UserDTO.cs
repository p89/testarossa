using System;

namespace testarossa.Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid Id { get;  set;}
        public string Email { get;  set;}
        public string UserName { get;  set;}
        public string FullName { get;  set;}
        public DateTime CreatedOn { get;  set;}
    }
}