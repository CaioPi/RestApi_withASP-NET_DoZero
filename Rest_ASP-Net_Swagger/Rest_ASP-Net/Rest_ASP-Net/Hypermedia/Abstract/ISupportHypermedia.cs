using Rest_ASP_Net.Hypermedia;
using System.Collections.Generic;

namespace Rest_ASP_Net.Hypermidia.Abstract
{
    public interface ISupportHypermedia
    {
           List<HyperMediaLink> Links { get; set; }
    }
}
