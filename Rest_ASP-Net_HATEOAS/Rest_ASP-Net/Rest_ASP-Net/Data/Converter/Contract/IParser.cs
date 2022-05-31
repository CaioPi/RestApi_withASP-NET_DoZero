using System.Collections.Generic;

namespace Rest_ASP_Net.Data.Converter.Contract
{
    public interface IParser<O,D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
