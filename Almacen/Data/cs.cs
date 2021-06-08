using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Almacen.Models;

namespace Almacen.Areas.Identity.Data.AlmacenContext
{
    public class cs : DbContext
    {
        public cs (DbContextOptions<cs> options)
            : base(options)
        {
        }

        public DbSet<Almacen.Models.Producto> Producto { get; set; }
    }
}
