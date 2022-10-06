using System;

namespace CodecoolAvence.Model {
	public class Mentor : User {
		public HashSet<Branch> _Specialisation { get; }
		public HashSet<Team> _Teams {get; }

		public bool AddSpecialisation() {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool RemoveSpecialisation() {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool AddTeam() {
			throw new System.NotImplementedException("Not implemented");
		}
		public bool RemoveTeam() {
			throw new System.NotImplementedException("Not implemented");
		}
	}
}
