using Rest_ASP_Net.Data.VO;
using System.Collections.Generic;

namespace Rest_ASP_Net.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO person);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO person);
        void Delete(long id);
    }
}
