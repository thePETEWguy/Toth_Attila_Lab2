using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Toth_Attila_Lab2.Models;

namespace Toth_Attila_Lab2.Data
{
    public class Toth_Attila_Lab2Context : DbContext
    {
        public Toth_Attila_Lab2Context (DbContextOptions<Toth_Attila_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Toth_Attila_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Toth_Attila_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Toth_Attila_Lab2.Models.Category> Category { get; set; }

        public DbSet<Toth_Attila_Lab2.Models.Author> Author { get; set; }
    }
}
