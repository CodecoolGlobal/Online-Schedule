using System;

namespace CodecoolAvence.Model {
	public abstract class Team {
		private HashSet<Student> _students;
		public Mentor _mentor { get; set; }
		private string _name;
		private DateTime _startDate;
		private BranchProgress _branchProgress;

        protected Team(Student student, string name)
        {
            _students.Add(student);
            _name = name;
            _startDate = DateTime.Now;
            _branchProgress = new BranchProgress(student.BranchProgress.Branch);
        }

        public void CourentWeek() {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool AddStudent(Student student) {
			return _students.Add(student);
		}
		public bool RemoveStudent(Student student) {
			return _students.Remove(student);
		}
	}

}
