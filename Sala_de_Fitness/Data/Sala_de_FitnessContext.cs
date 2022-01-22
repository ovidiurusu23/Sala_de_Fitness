using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sala_de_Fitness.Models;

namespace Sala_de_Fitness.Data
{
    public class Sala_de_FitnessContext : DbContext
    {
        public Sala_de_FitnessContext (DbContextOptions<Sala_de_FitnessContext> options)
            : base(options)
        {
        }

        public DbSet<Sala_de_Fitness.Models.Instructor> Instructor { get; set; }

        public DbSet<Sala_de_Fitness.Models.Sala> Sala { get; set; }

        public DbSet<Sala_de_Fitness.Models.Client> Client { get; set; }
    }
}
