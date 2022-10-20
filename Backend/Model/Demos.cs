using CodecoolAvence.Model;

namespace CodecoolAdvanced.Model;

public class Demos
{
    public DateTime DemoStart { get; set; } = DateTime.Now;
    public List<Team> DemoOrder { get; private set; } 

    private static Demos instance = null;

    public static Demos Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Demos();
            }
            return instance;
        }
    }

    public List<Team> shafelOrder()
    {
        HashSet<Team> actualTeams = TeamCollector.Instance.GetCurrentWeekTeam();
        List<Team> actualTeamsList = actualTeams.ToList();

        Random rand = new Random();
        var shuffled = actualTeamsList.OrderBy(_ => rand.Next()).ToList();
        DemoOrder = shuffled;
        
        return DemoOrder;
    }
}