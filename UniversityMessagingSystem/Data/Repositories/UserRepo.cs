
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityMessagingSystem.Data;
using UniversityMessagingSystem.Entities;

namespace CMSmk1.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly dbContext _context;

        public UserRepo(dbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> Get()
        {
            return _context.user.ToList();
        }

        public User Get(int id)
        {
            return _context.user.FirstOrDefault(i => i.Id == id);
        }

        public void Add(User user)
        {
            _context.user.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
