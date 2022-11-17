using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public HashSet<Student> Students { get; set; } = new HashSet<Student>();
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public Branch Progress { get; set; }
        public int WeekChanged { get; set; }

        public string Repo { get; set; }
        public string? SiReviewStart { get; set; }
        public string? SiReviewFinish { get; set; }
        public string? TwReviewStart { get; set; }
        public string? TwReviewFinish { get; set; }

        public bool AddStudent(Student student)
        {
            if (Students == null)
            {
                Students = new HashSet<Student>();
            }
            return Students.Add(student);
        }
        public bool RemoveStudent(Student student)
        {
            return Students.Remove(student);
        }
        public int GetCurrentWeek()
        {
            return (int)((StartDate - DateTime.Now).TotalDays / 7) + WeekChanged;
        }
        public bool GetIfTw()
        {
            return (int)((StartDate - DateTime.Now).TotalDays / 7) + WeekChanged % 2 == 0;
        }
    }

}
