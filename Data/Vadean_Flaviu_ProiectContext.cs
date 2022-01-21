using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vadean_Flaviu_Proiect.Models;

namespace Vadean_Flaviu_Proiect.Data
{
    public class Vadean_Flaviu_ProiectContext : DbContext
    {
        public Vadean_Flaviu_ProiectContext (DbContextOptions<Vadean_Flaviu_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Vadean_Flaviu_Proiect.Models.Judet> Judet { get; set; }

        public DbSet<Vadean_Flaviu_Proiect.Models.Localitate> Localitate { get; set; }

        public DbSet<Vadean_Flaviu_Proiect.Models.SectieVotare> SectieVotare { get; set; }

        public DbSet<Vadean_Flaviu_Proiect.Models.Persoana> Persoana { get; set; }
    }
}
