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

        public Task<List<Team>> GetTeams()
        {
            return Teams.ToListAsync();
        }

        public Task<List<Team>> GetDemos()
        {
            return Teams.Where(x => x.GetCurrentWeek()%2 == 1).ToListAsync();
        }

        public Task<Team> GetTeam(int id)
        {
            return Teams.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Student>> GetStudentsFromTeam(int id)
        {
            Team t = await Teams.Where(x => x.Id == id).FirstAsync();
            return t.Students.ToList();
        }

        public async Task<Team> AddTeam(Team team, int studentId)
        {
            Teams.Add(team);
            team.AddStudent(Students.Where(x =>x.ID == studentId).First());
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
            Teams.Remove(Teams.First(x => x.Id == id));
            await SaveChangesAsync();
        }
    }
}
