using System;

namespace CodecoolAvence.Model {
	public class TeamCollector {
		private HashSet<Team> _teams;

		public void SetCourentWeekForAllTeam() {
			foreach (Team team in _teams)
            {
				team._branchProgress.AutoSetActualWeek(team.StartDate);
            };
		}
		public bool AddTeam(Team team) {
			return _teams.Add(team);
		}
		public bool DeleteTeam(Team team) {
			return _teams.Remove(team);
		}
		public HashSet<Team> GetCurrentWeekTeam() {
			HashSet<Team> result = new HashSet<Team>();
			foreach (Team team in _teams) { 
				if (team._branchProgress.ActualWeek % 2 == 0)
                {
					result.Add(team);
                }
			}
			return result;
		}

	}

}
