using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppointmentsContext Context;
        private readonly DbSet<T> _entities;
        public Repository(AppointmentsContext context)
        {
            this.Context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }
        public T Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _entities.Add(entity);
            Context.SaveChanges();
            return entity;
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            if (id == 0) throw new ArgumentNullException("entity");

            T entity = _entities.SingleOrDefault(s => s.Id == id);
            _entities.Remove(entity);
            Context.SaveChanges();
        }

    }
}
