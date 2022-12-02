using Source.Models;
using Source.Repositories.Abstract;
using Source.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Repositories.Concretes
{
    public class FakeUserRepository : IUserRepository
    {
        public void Add(User entity)
            => FakeDbContext.Users?.Add(entity);

        public User? Get(Func<User, bool> predicate)
            => FakeDbContext.Users?.FirstOrDefault(predicate!);
        public List<User>? GetList(Func<User, bool>? predicate = null)
            => (predicate is null) switch
                {
                    true => FakeDbContext.Users,
                    false => FakeDbContext.Users.Where(predicate).ToList(),
                };


        public void Remove(User entity)
            => FakeDbContext.Users?.Remove(entity);

        public void Update(User entity)
        {
            var index = FakeDbContext.Users.IndexOf(entity);
            FakeDbContext.Users[index] = entity;
        }
    }
}
