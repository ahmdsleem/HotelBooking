using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.DBContext
{
    // the deferint between this calss and ReservoomDesignTimeDbContextFactory,
    // is that we are not going to be hard coding the connection string in this DbContextFactory.
    public class ReservoomDbContextFactory
    {
        private readonly string _connectionsString;

        public ReservoomDbContextFactory(string connectionsString)
        {
            _connectionsString = connectionsString;
        }
        public ReservoomDBContext CreateDbContext()
        {
            // import our DbContexto ption stuff
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionsString).Options;

            return new ReservoomDBContext(options);
        }
    }
}
