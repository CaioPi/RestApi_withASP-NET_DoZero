using Microsoft.EntityFrameworkCore;

namespace Rest_ASP_Net.Model.Context
{
    public class MysqlContext:DbContext

    {
        public MysqlContext()
        {

        }
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        

        


    }
}
