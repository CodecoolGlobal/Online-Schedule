using System;

namespace CodecoolAdvanced.Model
{
    public class Team
    {
        private static int teamCounter = 0;
        public int Id { get; private set; }
        public HashSet<Student> Students { get; }
        public Mentor? Mentor { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; }
        public BranchProgress _branchProgress { get; }

        public string Repo { get; }
        public string SiReviewStart { get; set; }
        public string SiReviewFinish { get; set; }
        public string TwReviewStart { get; set; }
        public string TwReviewFinish { get; set; }


        public Team(Student student, string name, string repo)
        {
            Repo = repo;
            Id = teamCounter;
            Students = new HashSet<Student>();
            Students.Add(student);
            Name = name;
            StartDate = DateTime.Now;
            _branchProgress = new BranchProgress(student.BranchProgress.Branch);
            teamCounter++;
        }
        public bool AddStudent(Student student)
        {
            return Students.Add(student);
        }
        public bool RemoveStudent(Student student)
        {
            return Students.Remove(student);
        }
    }

}
