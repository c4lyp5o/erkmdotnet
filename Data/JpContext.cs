using Microsoft.EntityFrameworkCore;

namespace JpContext
{
    public class JpContext2 : DbContext
    {
        public JpContext2(DbContextOptions<JpContext2> options)
            : base(options)
        {
        }

        public DbSet<JpModel.JpItems> JpItems { get; set; }
    }
}