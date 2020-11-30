using System.Collections.Generic;

namespace AppointmentScheduler.Core.Interface
{
    public interface IRepository<T> where T : Entity.Entity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
