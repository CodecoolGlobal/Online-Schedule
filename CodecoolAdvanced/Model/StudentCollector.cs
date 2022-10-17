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
	}
}
