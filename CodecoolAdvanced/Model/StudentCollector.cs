using CodecoolAvence.Model;

namespace CodecoolAdvanced.Model
{
	public class StudentCollector
	{
		private static StudentCollector instance = null;

		private HashSet<Student> _students;
		private StudentCollector()
		{
			_students = new HashSet<Student>();
		}

		public static StudentCollector Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new StudentCollector();
				}
				return instance;
			}
		}

		public bool AddToStudents(Student student)
		{
			if (student == null)
			{
				return false;
			}
			else return _students.Add(student);
		}

		public bool RemoveFromStudents(Student student)
		{
			if (student == null)
			{
				return false;
			}
			else return _students.Remove(student);
		}

		public Student? GetStudentById(int Id)
        {
			Student student = _students.FirstOrDefault(s => s.Id == Id);
			return student;
        }
	}
}
