using Rest_ASP_Net.Model;
using Rest_ASP_Net.Model.Base;
using System.Collections.Generic;

namespace Rest_ASP_Net.Repository
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);

        bool Exists(long id);
    }
}
