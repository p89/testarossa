using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testarossa.Core.Domain;
using testarossa.Core.Repositories;

namespace testarossa.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("mail1@gmail.com","Tony Hawk","pass1", "salt1"),
            new User("mail2@gmail.com","Marian Pazdzioch","pass2", "salt2"),
            new User("mail3@gmail.com","Eva Longoria","pass3", "salt3"),
            new User("mail4@gmail.com","Andrzej Duda","pass4", "salt4"),
        };
        public async Task Add(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> Get(Guid id)        
            => _users.SingleOrDefault(x => x.Id == id);
        

        public async Task<User> Get(string email) 
        {
            return _users.SingleOrDefault(x => x.Email == email.ToLowerInvariant());
        }
           

        public async Task<IEnumerable<User>> GetAll()
            => _users;

        public async Task Remove(Guid id)
        {
            var user = await Get(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task Update(User user)
        {
            await Task.CompletedTask;
        }
    }
}