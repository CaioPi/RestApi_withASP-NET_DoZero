using Rest_ASP_Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_ASP_Net.Business
{
    public interface IBookBusiness
    {
        Book Create(Book person);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(long id);
    }
}
