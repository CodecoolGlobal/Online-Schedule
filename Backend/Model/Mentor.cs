using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model {
	public class Mentor : User {
        public Mentor(string name, string email) : base(name, email)
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

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
