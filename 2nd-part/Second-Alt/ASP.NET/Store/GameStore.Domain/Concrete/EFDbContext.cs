using MobileStore.Domain.Entities;
using System.Data.Entity;

namespace MobileStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Mobile> Mobiles { get; set; }

        public EFDbContext(string connectionString) : base(nameOrConnectionString: connectionString)
        { }
    }
}