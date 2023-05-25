using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eye_nobat.Models;

namespace eye_nobat.Data
{
    public class eye_nobatContext : DbContext
    {
        public eye_nobatContext(DbContextOptions<eye_nobatContext> options)
            : base(options)
        {
        }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            modelBuilder.Entity<v_bakhsh_g>()
            .ToView(nameof(v_bakhsh_g))
            .HasNoKey();

            modelBuilder.Entity<v_nemudar_never_uni>()
            .ToView(nameof(v_nemudar_never_uni))
            .HasNoKey();

            modelBuilder.Entity<v_nemudar_never_hos>()
           .ToView(nameof(v_nemudar_never_hos))
           .HasNoKey();


            modelBuilder.Entity<v_nemudar_never_bakhsh>()
           .ToView(nameof(v_nemudar_never_bakhsh))
           .HasNoKey();

            modelBuilder.Entity<v_nemudar_jensiat>()
           .ToView(nameof(v_nemudar_jensiat))
           .HasNoKey();

            modelBuilder.Entity<v_ertebat_marakez>()
           .ToView(nameof(v_ertebat_marakez))
           .HasNoKey();

            modelBuilder.Entity<v_tedad_bakhsh>()
           .ToView(nameof(v_tedad_bakhsh))
           .HasNoKey();

            modelBuilder.Entity<v_count_never>()
           .ToView(nameof(v_count_never))
           .HasNoKey();

            modelBuilder.Entity<v_count_uni>()
           .ToView(nameof(v_count_uni))
           .HasNoKey();

            modelBuilder.Entity<v_count_hos>()
           .ToView(nameof(v_count_hos))
           .HasNoKey();

            modelBuilder.Entity<v_count_bakhsh>()
            .ToView(nameof(v_count_bakhsh))
            .HasNoKey();



        }



        //public DbSet<eye_nobat.Models.v_bakhsh_g? v_bakhsh_g { get; set; }


        public DbSet<eye_nobat.Models.user>? user { get; set; }






        public DbSet<eye_nobat.Models.uni>? uni { get; set; }






        public DbSet<eye_nobat.Models.code>? code { get; set; }






        public DbSet<eye_nobat.Models.hos>? hos { get; set; }






        public DbSet<eye_nobat.Models.bakhsh>? bakhsh { get; set; }






        public DbSet<eye_nobat.Models.never>? never { get; set; }
        public DbSet<eye_nobat.Models.jensiat>? jensiat { get; set; }
        public DbSet<eye_nobat.Models.peyvast>? peyvast { get; set; }
        public DbSet<eye_nobat.Models.admin>? admin { get; set; }
        public DbSet<eye_nobat.Models.v_uni_hos_bakhsh1>? v_uni_hos_bakhsh1 { get; set; }
        public DbSet<eye_nobat.Models.v_uni_hos1>? v_uni_hos1 { get; set; }
        public DbSet<eye_nobat.Models.v_koli_detail>? v_koli_detail { get; set; }
        public DbSet<eye_nobat.Models.v_bakhsh_g>? v_bakhsh_g { get; set; }
        public DbSet<eye_nobat.Models.v_nemudar_never_uni>? v_nemudar_never_uni { get; set; }
        public DbSet<eye_nobat.Models.v_nemudar_never_hos>? v_nemudar_never_hos { get; set; }
        public DbSet<eye_nobat.Models.v_nemudar_never_bakhsh>? v_nemudar_never_bakhsh { get; set; }
        public DbSet<eye_nobat.Models.v_nemudar_jensiat>? v_nemudar_jensiat { get; set; }
        public DbSet<eye_nobat.Models.v_ertebat_marakez>? v_ertebat_marakez { get; set; }
        public DbSet<eye_nobat.Models.mobile>? mobile { get; set; }
        public DbSet<eye_nobat.Models.v_tedad_bakhsh>? v_tedad_bakhsh { get; set; }
        public DbSet<eye_nobat.Models.v_count_never>? v_count_never { get; set; }
        public DbSet<eye_nobat.Models.v_count_uni>? v_count_uni { get; set; }
        public DbSet<eye_nobat.Models.v_count_hos>? v_count_hos { get; set; }
        public DbSet<eye_nobat.Models.v_count_bakhsh>? v_count_bakhsh { get; set; }
        public DbSet<eye_nobat.Models.koli>? koli { get; set; }











    }
}
