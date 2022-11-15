using System;

namespace CodecoolAdvanced.Model {
	public class TeamCollector {
		private static TeamCollector instance = null;

		private TeamCollector()
		{
			_teams = new HashSet<Team> ();
		}

		public static TeamCollector Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new TeamCollector();
				}
				return instance;
			}
		}


		private HashSet<Team> _teams;

		public void SetCourentWeekForAllTeam() {
			foreach (Team team in _teams)
            {
				team._branchProgress.AutoSetActualWeek(team.StartDate);
            }
		}
		public bool AddTeam(Team team) {
			return _teams.Add(team);
		}
		public bool DeleteTeam(Team team) {
			return _teams.Remove(team);
		}

		public HashSet<Team> GetTeams() { 
			return _teams;
		}

		public Team GetTeamById(int id) { 
			Team teamToReturn = _teams.FirstOrDefault(t => t.Id == id);
			if (teamToReturn == null)
            {
				return null;
            }
			return teamToReturn;
		}
		
		public HashSet<Student> GetStudentsFromTeamById(int Id)
        {
			Team team = GetTeamById(Id);
			return team.Students; 
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
