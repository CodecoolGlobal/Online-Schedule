using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model {
	public class Mentor : User {

		public HashSet<Branch> Specialisation { get; set; }
		public HashSet<Team> Teams { get; set; }
		public bool AddSpecialisation(Branch branch) {
			return Specialisation.Add(branch);
		}
		public bool RemoveSpecialisation(Branch branch) {
			return Specialisation.Remove(branch);
		}
		public bool AddTeam(Team team) {
			return Teams.Add(team);
		}
		public bool RemoveTeam(Team team) {
			return Teams.Remove(team);
		}
	}
}
