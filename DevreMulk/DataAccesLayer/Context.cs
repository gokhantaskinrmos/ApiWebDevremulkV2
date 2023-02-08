using Microsoft.EntityFrameworkCore;

namespace DevreMulk.DataAccesLayer
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DHVOIQK;Initial Catalog=ErzinDevre;User ID=sa;Password=19830126;TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Data Source=193.53.103.51;Initial Catalog=IsTakip;User ID=sa;Password=V@r1@0721n+;TrustServerCertificate=True");
        }
    }
}
