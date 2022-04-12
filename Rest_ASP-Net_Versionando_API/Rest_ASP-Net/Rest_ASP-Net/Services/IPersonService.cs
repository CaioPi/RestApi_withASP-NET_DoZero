﻿using Rest_ASP_Net.Model;
using System.Collections.Generic;

namespace Rest_ASP_Net.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
