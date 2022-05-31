using System.ComponentModel.DataAnnotations.Schema;

namespace Rest_ASP_Net.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }

    
    }
}
