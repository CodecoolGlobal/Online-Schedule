

namespace CodecoolAdvanced.Model
{
	public class UserCollector
	{
		private static UserCollector instance = null;

		private HashSet<User> _Users;
		private UserCollector()
		{
			_Users = new HashSet<User>();
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

		public bool AddUsersToCollector(User user)
		{
			if (user == null)
			{
				return false;
			}
			else return _Users.Add(user);
		}

		public bool RemoveFromStudents(User user)
		{
			if (user == null)
			{
				return false;
			}
			else return _Users.Remove(user);
		}
		public HashSet<User> GetAllUsers()
        {
			return _Users;
        } 
		public User? GetUserById(int Id)
        {
			User user = _Users.FirstOrDefault(s => s.Id == Id);
			return user;
        }

		public HashSet<Student> GetActualStudents()
        {
			HashSet<Student> students = new HashSet<Student>();
			HashSet<Team> teams=TeamCollector.Instance.GetCurrentWeekTeam();
			foreach (Team team in teams)
            {
				foreach( Student student in team.Students)
                {
					students.Add(student);
                }
            }
			return students;
        }
	}
}
