using System;

namespace CodecoolAvence.Model {
	public class Mentor : User {
        public Mentor(string name, string email) : base(name, email)
        {
        }

        public HashSet<Branch> _Specialisation { get; }
		public HashSet<Team> _Teams {get; }
		public bool AddSpecialisation(Branch branch) {
			return _Specialisation.Add(branch);
		}
		public bool RemoveSpecialisation(Branch branch) {
			return _Specialisation.Remove(branch);
		}
		public bool AddTeam(Team team) {
			return _Teams.Add(team);
		}
		public bool RemoveTeam(Team team) {
			return _Teams.Remove(team);
		}
	}
}
