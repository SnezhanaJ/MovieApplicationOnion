using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieApplication.Domain.Domain;
using MovieApplication.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;

        public  Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(Guid? id)
        {
            if (typeof(Ticket)==typeof(T))
            {
                return entities.Include("Movie").SingleOrDefault(u => u.Id == id);

            }
            return entities.SingleOrDefault(u => u.Id == id);
          
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(Ticket) == typeof(T))
            {
                return entities.Include("Movie").AsEnumerable(); ;

            }
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
