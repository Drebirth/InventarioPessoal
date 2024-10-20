using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Context
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options)
        {

        }

        public DbSet<Item> Itens{ get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }
    }

    
}