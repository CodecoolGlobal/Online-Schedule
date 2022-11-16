using CodecoolAdvanced.Controller;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodecoolAdvanced.Model
{
    public class DBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CodecoolContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CodecoolContext>>()))
                
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                if (context.Branches.Any())
                {
                    return;
                }
                context.Branches.AddRange(
                    new Branch
                    {
                        Name="DevOps"
                    },
                    new Branch
                    {
                        Name = "Test"
                    },
                    new Branch
                    {
                        Name = "Java"
                    },
                    new Branch
                    {
                        Name = "C#"
                    }
                );
                context.SaveChanges();
                context.Progresses.AddRange(
                    new BranchProgress
                    {
                        PBranch = context.Branches.Where(x => x.Name == "C#").First(), 
                        MaterialContent="1", 
                        Week=1
                    },
                    new BranchProgress
                    {
                        PBranch = context.Branches.Where(x => x.Name == "C#").First(),
                        MaterialContent = "2",
                        Week = 2
                    },
                    new BranchProgress
                    {
                        PBranch = context.Branches.Where(x => x.Name == "C#").First(),
                        MaterialContent = "3",
                        Week = 3
                    }
                );
                context.SaveChanges();
                context.Demos.AddRange(
                    new Demo
                    {
                    }
                );
                context.SaveChanges();
                context.Materials.AddRange(
                    new Material
                    {
                        Name = "https://www.codewars.com/kata/555615a77ebc7c2c8a0000b8"
                    },
                    new Material
                    {
                        Name = "https://www.codewars.com/kata/5f799eb13e8a260015f58944"
                    }
                );
                context.SaveChanges();
                context.EducationalMaterials.AddRange(
                    new EducationalMaterial
                    {
                        Name= "Homework history",
                        Materials=context.Materials.ToHashSet()
                    }
                );
                context.SaveChanges();
                context.Students.AddRange(
                    new Student
                    {
                        Name = "Student1", 
                        SBranch=context.Branches.Where(x => x.Name == "C#").First(),
                        Email="student@s.s",
                        Password="Password",
                        WeekChanged=0
                    },
                    new Student
                    {
                        Name = "Student2",
                        SBranch = context.Branches.Where(x => x.Name == "C#").First(),
                        Email = "s2@s.s",
                        Password = "Password2",
                        WeekChanged = 0
                    },
                    new Student
                    {
                        Name = "Student3",
                        SBranch = context.Branches.Where(x => x.Name == "Test").First(),
                        Email = "TS@s.s",
                        Password = "PasswordT",
                        WeekChanged = 0
                    }
                );
                context.SaveChanges();
                context.Teams.AddRange(
                    new Team
                    {
                        Name = "TC1",
                        Students = new HashSet<Student>() { context.Students.ToList()[0], context.Students.ToList()[1] },
                        Progress = context.Students.ToList()[0].SBranch,
                        Repo = "https://github.com/CodecoolGlobal/el-proyecte-grande-sprint-1-csharp-nagyD88",
                        SiReviewStart = "0",
                        SiReviewFinish = "0",
                        TwReviewStart = "0",
                        TwReviewFinish = "0"
                    }
                ); ;
                context.SaveChanges();
                context.Mentors.AddRange(
                    new Mentor
                    {
                        Name = "Mentor1",
                        Specialisation = new HashSet<Branch>() { context.Branches.ToList()[0], context.Branches.ToList()[2] },
                        Teams = context.Teams.ToHashSet(),
                        Email = "mentor@mentor.m",
                        Password = "password"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
