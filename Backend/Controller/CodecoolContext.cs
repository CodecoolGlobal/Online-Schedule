using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public Task<List<Team>> GetTeams()
        {
            return Teams.Include(team => team.Students).Include(team => team.Progress).ToListAsync();
        }

        public async Task<List<Team>> GetDemos()
        {
            return (await Teams.Include(team => team.Students).Include(team => team.Progress).ToListAsync()).Where(x => x.GetIfTw()).ToList();
        }

        public Task<Team> GetTeam(int id)
        {
            return Teams.Include(team => team.Students).Include(team => team.Progress).ThenInclude(p => p.Progress).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Student>> GetStudentsFromTeam(int id)
        {
            Team t = await Teams.Include(team => team.Students).Where(x => x.Id == id).FirstAsync();
            return t.Students.ToList();
        }

        public async Task<Team> AddTeam(Team team)
        {
            Teams.Add(team);
            await SaveChangesAsync();
            return team;
        }

        public async Task RenameTeamById( int id, string NewName)
        {
            Team t = Teams.FirstOrDefault(x => x.Id == id);
            if (t != null)
            t.Name = NewName;
            await SaveChangesAsync();
        }

        public async Task ChangeReviewTime(int id, string reviewTime, string type)
        {
            Team team = Teams.FirstOrDefault(x => x.Id == id);
            if (team != null)
            {
                if (type == "siStart")
                    team.SiReviewStart = reviewTime;
                else if (type == "siFinish")
                    team.SiReviewFinish = reviewTime;
                else if (type == "twStart")
                    team.TwReviewStart = reviewTime;
                else
                    team.TwReviewFinish = reviewTime;
            }
            await SaveChangesAsync();
        }

        public async Task AddStudentToTeam(int id, int studentid)
        {
            Teams.First(x => x.Id == id).AddStudent(Students.First(x => x.ID == studentid));
            await SaveChangesAsync();
        }

        public async Task RemoveStudentFromTeam(int id, int studentid)
        {
            Teams.First(x => x.Id == id).RemoveStudent(Students.First(x => x.ID == studentid));
            await SaveChangesAsync();
        }

        public async Task DeleteTeam(int id)
        {
            Teams.Remove(Teams.Include(t => t.Students).First(x => x.Id == id));
            await SaveChangesAsync();
        }
    }
}
