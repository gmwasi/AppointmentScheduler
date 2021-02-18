using System.Collections.Generic;
using AppointmentScheduler.Core.Entity;

namespace AppointmentScheduler.Core.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(string id);
        User GetByUserName(string username);
        User Insert(User entity);
        void Update(User entity);
        void Delete(string id);
    }
}
