using Rest_ASP_Net.Data.VO;
using Rest_ASP_Net.Model;
using System.Collections.Generic;

namespace Rest_ASP_Net.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
