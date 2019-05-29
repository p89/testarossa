using System;
using System.Collections.Generic;
using testarossa.Core.Domain;

namespace testarossa.Core.Repositories
{
    public interface IUserRepository
    {
         User Get(Guid guid);
         User Get(string email);
         IEnumerable<User>GetAll();
         void Add(User user);
         void Update(User user);
         void Remove(Guid id);
    }
}