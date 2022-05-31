using Microsoft.EntityFrameworkCore;
using Rest_ASP_Net.Model.Base;
using Rest_ASP_Net.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rest_ASP_Net.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MysqlContext _context;

        private DbSet<T> dataset;
        public GenericRepository(MysqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }



        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
