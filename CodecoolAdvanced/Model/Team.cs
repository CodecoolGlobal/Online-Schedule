using System;

namespace CodecoolAvence.Model {
	public class Team {
		private HashSet<Student> _students;
		public Mentor? Mentor { get; set; }
		public string Name { get; }
		public DateTime StartDate { get; }
		public BranchProgress _branchProgress { get; }

        public Team(Student student, string name)
        {
			_students = new HashSet<Student>();
            _students.Add(student);
            Name = name;
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
