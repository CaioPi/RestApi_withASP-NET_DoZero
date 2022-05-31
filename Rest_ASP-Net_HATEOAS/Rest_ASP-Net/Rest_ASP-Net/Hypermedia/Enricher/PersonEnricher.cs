using Microsoft.AspNetCore.Mvc;
using Rest_ASP_Net.Data.VO;
using Rest_ASP_Net.Hypermedia.Constants;
using System.Text;
using System.Threading.Tasks;

namespace Rest_ASP_Net.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/persons/v1";
            string link = getLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = Relationtype.self,
                Type = RespondeTypeFormat.DefaultGet
            }
                );
                        content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = Relationtype.self,
                Type = RespondeTypeFormat.DefaultPut
            }
                );
                        content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = Relationtype.self,
                Type = RespondeTypeFormat.DefaultPost
            }
                );
                        content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = Relationtype.self,
                Type = "int"
            }
                );

            return null;
        }

        private string getLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { Controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString;


            }
        }
    }
}
