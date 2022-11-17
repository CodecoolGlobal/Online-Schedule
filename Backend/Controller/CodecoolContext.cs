using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodecoolAdvanced.Model;
using Microsoft.EntityFrameworkCore;

namespace CodecoolAdvanced.Controller
{
    public class CodecoolContext : DbContext
    {
        public CodecoolContext(DbContextOptions<CodecoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<EducationalMaterial> EducationalMaterials { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchProgress> Progresses { get; set; }
        public DbSet<Demo> Demos { get; set; }
        public DbSet<Material> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Mentor>().ToTable("Mentor");
            modelBuilder.Entity<EducationalMaterial>().ToTable("EducationalMaterial");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Branch>().ToTable("Branch");
            modelBuilder.Entity<BranchProgress>().ToTable("BranchProgress");
            modelBuilder.Entity<Demo>().ToTable("Demo");
            modelBuilder.Entity<Material>().ToTable("Material");
        }
    }
}
