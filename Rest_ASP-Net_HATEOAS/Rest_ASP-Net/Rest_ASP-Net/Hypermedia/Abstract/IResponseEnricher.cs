using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Rest_ASP_Net.Hypermidia.Abstract
{
    public interface IResponseEnricher
    {

        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);

    }
}
