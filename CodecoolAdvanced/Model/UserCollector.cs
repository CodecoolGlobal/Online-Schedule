using CodecoolAvence.Model;

namespace CodecoolAdvanced.Model
{
	public class UserCollector
	{
		private static UserCollector instance = null;

		private HashSet<User> _students;
		private UserCollector()
		{
			_students = new HashSet<User>();
		}

		public static UserCollector Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new UserCollector();
				}
				return instance;
			}
		}

		public bool AddToStudents(User user)
		{
			if (user == null)
			{
				return false;
			}
			else return _students.Add(user);
		}

		public bool RemoveFromStudents(User user)
		{
			if (user == null)
			{
				return false;
			}
			else return _students.Remove(user);
		}

		public User? GetStudentById(int Id)
        {
			User user = _students.FirstOrDefault(s => s.Id == Id);
			return user;
        }
	}
}
