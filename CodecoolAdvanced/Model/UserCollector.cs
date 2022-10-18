using CodecoolAvence.Model;

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

		public bool AddToStudents(User user)
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
	}
}
