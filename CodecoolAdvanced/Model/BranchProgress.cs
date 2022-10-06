using System;

namespace CodecoolAvence.Model
{
    public class BranchProgress
    {
        public BranchProgress(Branch branch)
        {
            Branch = branch;
            ActualWeek = 1;
            _weekChanged = 0;
        }
        public Branch Branch { get; }
        public string Progresess { get; private set; }
        public int ActualWeek { get; set; }
        private int _weekChanged;

        public void AutoSetActualWeek(DateTime start)
        {
            ActualWeek = (int)((start - DateTime.Now).TotalDays / 7) + _weekChanged;
        }
        public void SetActualWeek(int change)
        {
            _weekChanged += change;
        }
        public void SetProgress()
        {
            if (Branch == Branch.C_sharp)
            {
                Progresess = ProgressLists.Instance.cSharp[ActualWeek/2];
            }
            else if (Branch == Branch.Java)
            {
                Progresess = ProgressLists.Instance.java[ActualWeek/2];
            }
            else if (Branch == Branch.PHP)
            {
                Progresess = ProgressLists.Instance.php[ActualWeek/2];
            }
            else if (Branch == Branch.PHP)
            {
                Progresess = ProgressLists.Instance.php[ActualWeek/2];
            }
            else if (Branch == Branch.DevOps)
            {
                Progresess = ProgressLists.Instance.devOps[ActualWeek/2];
            }
            else if (Branch == Branch.TestAutomation)
            {
                Progresess = ProgressLists.Instance.TestAutomation[ActualWeek/2];
            }
        }

    }

}
