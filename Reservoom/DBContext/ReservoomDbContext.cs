using Microsoft.EntityFrameworkCore;
using Reservoom.DTOs;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.DBContext
{
    public class ReservoomDBContext : DbContext
    {
        // at first we generate the constructor,
        // then we goto Pakage Manager Console and write (add-migration Initial) in the console,
        // to migrating our database
        public ReservoomDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
