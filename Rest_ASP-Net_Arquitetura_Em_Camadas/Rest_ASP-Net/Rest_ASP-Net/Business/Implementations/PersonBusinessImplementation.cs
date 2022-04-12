using Rest_ASP_Net.Model;
using Rest_ASP_Net.Model.Context;
using Rest_ASP_Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rest_ASP_Net.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }



        public Person FindById(long id)
        {
            return (_repository.FindById(id));
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
