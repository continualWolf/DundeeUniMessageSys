
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityMessagingSystem.Entities;

namespace CMSmk1.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> Get();

        User Get(int id);

        void Add(User user);

        void Update(User user);
    }
}
