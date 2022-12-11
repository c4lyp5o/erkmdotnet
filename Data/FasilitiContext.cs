using Microsoft.EntityFrameworkCore;

namespace FasilitiContext
{
    public class FasilitiStore : DbContext
    {
        public FasilitiStore(DbContextOptions<FasilitiStore> options)
            : base(options)
        {
        }

        public DbSet<FasilitiModel.FasilitiItems> FasilitiItems { get; set; }
    }
}