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
        // TEAM
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

        // USERS
        //get users
        public async Task<Mentor> GetMentor(int id)
        {
            return Mentors.FirstOrDefault(x => x.ID == id);
        }
        public async Task<Student> GetStudent(int id)
        {
            return Students.FirstOrDefault(x => x.ID == id);
        }
        //add users
        public async Task<Mentor> AddMentor(Mentor mentor)
        {
            Mentors.Add(mentor);
            await SaveChangesAsync();
            return mentor;
        }
        public async Task<Student> AddStudent(Student student)
        {
            Students.Add(student);
            await SaveChangesAsync();
            return student;
        }
        //delete users
        public async Task DeleteStudent(long id)
        {
            Students.Remove(Students.FirstOrDefault(s => s.ID == id));
            await SaveChangesAsync();
        }
        public async Task DeleteMentor(long id)
        {
            Mentors.Remove(Mentors.FirstOrDefault(s => s.ID == id));
            await SaveChangesAsync();
        }
        //rename users
        public async Task RenameMentor(int id, string newName)
        {
            Mentor mentor = Mentors.FirstOrDefault(s => s.ID == id);
            if (mentor != null)
            {
                mentor.Name = newName;
            }
            await SaveChangesAsync();
        }
        public async Task RenameStudent(int id, string newName)
        {
            Student student = Students.FirstOrDefault(s => s.ID == id);
            if (student != null)
            {
                student.Name = newName;
            }
            await SaveChangesAsync();
        }
        //MATERIAL
        public async Task<List<EducationalMaterial>> GetMaterial()
        {
            return await EducationalMaterials.Include(m => m.Materials).ToListAsync();
        }
        public async Task<EducationalMaterial> GetMaterialById(int id)
        {
            return await EducationalMaterials.Include(m => m.Materials).FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<EducationalMaterial> CreateEMaterial(EducationalMaterial EM)
        {
            EducationalMaterials.Add(EM);
            await SaveChangesAsync();
            return EM;
        }
        public async Task<EducationalMaterial> AddMaterial(string M, int EMID)
        {
            if (EducationalMaterials.FirstOrDefault(x=> x.ID == EMID)== null)
            {
                return null;
            }
            else 
            {
                Material material = new() { Name = M };
                Materials.Add(material);
                EducationalMaterials.Include(em => em.Materials).FirstOrDefault(x => x.ID == EMID).Materials.Add(material);
                EducationalMaterial edu = EducationalMaterials.Include(em => em.Materials).FirstOrDefault(x => x.ID == EMID);
                await SaveChangesAsync();
                return edu;
            }
            
        }
        public async Task RemoveMaterial(int id)
        {
            Materials.Remove(Materials.FirstOrDefault(x => x.ID == id));
            await SaveChangesAsync();
        }
        public async Task RemoveEm(int id)
        {
            EducationalMaterial EM = EducationalMaterials.Include(em => em.Materials).FirstOrDefault(x => x.ID == id);
            Materials.RemoveRange(EM.Materials.ToList());
            EducationalMaterials.Remove(EM);
            await SaveChangesAsync();
        }
    }
}
