using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FaurDanielProiectMedii.Models;

    public class FaurDanielProjectContext : DbContext
    {
        public FaurDanielProjectContext (DbContextOptions<FaurDanielProjectContext> options)
            : base(options)
        {
        }

        public DbSet<FaurDanielProiectMedii.Models.Clasa> Clasa { get; set; }

        public DbSet<FaurDanielProiectMedii.Models.Antrenor> Antrenor { get; set; }

        public DbSet<FaurDanielProiectMedii.Models.Intensitate> Intensitate { get; set; }

        public DbSet<FaurDanielProiectMedii.Models.Nivel> Nivel { get; set; }
    }
