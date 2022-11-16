using System;

namespace CodecoolAdvanced.Model {
    public class Student : User
    {
        public Branch SBranch { get; set; }
        public DateTime Start { get; set; }
        public int WeekChanged { get; set; }

        public int GetCurrentWeek()
        {
            return (int)((Start - DateTime.Now).TotalDays/7) + WeekChanged;
        }
    }

}
