using Rest_ASP_Net.Hypermedia;
using Rest_ASP_Net.Hypermidia.Abstract;
using System.Collections.Generic;

namespace Rest_ASP_Net.Data.VO
{

    public class PersonVO : ISupportHypermedia
    {

        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
