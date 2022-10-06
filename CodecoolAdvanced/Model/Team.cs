using System;

namespace CodecoolAvence.Model {
	public abstract class Team {
		private HashSet<Student> _students;
		private Mentor _mentor;
		private string _name;
		private DateTime _startDate;
		private BranchProgress _branchProgress;

		public void CourentWeek() {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool AddStudent(Student student) {
			return _students.Add(student);
		}
		public bool RemoveStudent() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void SetMentor() {
			throw new System.NotImplementedException("Not implemented");
		}
	}

}
