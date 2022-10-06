using System;

namespace CodecoolAvence.Model {
	public abstract class Team {
		private HashSet<Student> _students;
		public Mentor _mentor { get; set; }
		private string _name;
		public DateTime StartDate { get; }
		public BranchProgress _branchProgress { get; }

        protected Team(Student student, string name)
        {
            _students.Add(student);
            _name = name;
            StartDate = DateTime.Now;
            _branchProgress = new BranchProgress(student.BranchProgress.Branch);
        }
		public bool AddStudent(Student student) {
			return _students.Add(student);
		}
		public bool RemoveStudent(Student student) {
			return _students.Remove(student);
		}
	}

}
