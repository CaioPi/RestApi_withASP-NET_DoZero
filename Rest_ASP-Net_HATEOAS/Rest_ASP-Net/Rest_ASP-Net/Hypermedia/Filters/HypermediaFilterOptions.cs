using Rest_ASP_Net.Hypermidia.Abstract;
using System.Collections.Generic;

namespace Rest_ASP_Net.Hypermedia.Filters
{
    public class HypermediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; }=new List<IResponseEnricher>();
    }
}
