using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)        
            => _users.Single(x => x.Id == id);
        

        public User Get(string email)
            => _users.Single(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}