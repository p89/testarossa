using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testarossa.Core.Domain;

namespace testarossa.Core.Repositories 
{
    public interface IUserRepository : IRepository
    {
         Task<User> Get(Guid guid);
         Task<User> Get(string email);
         Task<IEnumerable<User>>GetAll();
         Task Add(User user);
         Task Update(User user);
         Task Remove(Guid id);
    }
}