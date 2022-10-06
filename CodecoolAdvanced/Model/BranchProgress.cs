using System;

namespace CodecoolAvence.Model
{
    public class BranchProgress
    {
        public BranchProgress(Branch branch)
        {
            Branch = branch;
            ActualWeek = 1;
        }
        public Branch Branch { get; }
        public string Progresess { get; private set; }
        public int ActualWeek { get; set; }

        public void AutoSetActualWeek()
        {
            ActualWeek++;
        }
        public void SetProgress()
        {
            if (Branch == Branch.C_sharp)
            {
                Progresess = ProgressLists.Instance.cSharp[ActualWeek];
            }
            else if (Branch == Branch.Java)
            {
                Progresess = ProgressLists.Instance.java[ActualWeek];
            }
            else if (Branch == Branch.PHP)
            {
                Progresess = ProgressLists.Instance.php[ActualWeek];
            }
            else if (Branch == Branch.PHP)
            {
                Progresess = ProgressLists.Instance.php[ActualWeek];
            }
            else if (Branch == Branch.DevOps)
            {
                Progresess = ProgressLists.Instance.devOps[ActualWeek];
            }
            else if (Branch == Branch.TestAutomation)
            {
                Progresess = ProgressLists.Instance.TestAutomation[ActualWeek];
            }
        }

    }

}
