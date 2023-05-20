using Microsoft.EntityFrameworkCore;

namespace Xaero_EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }



    }
}
