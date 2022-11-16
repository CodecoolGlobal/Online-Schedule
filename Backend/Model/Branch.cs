using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model {
	public class Branch {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
		public string Name { get; set; }
        public HashSet<BranchProgress> Progress { get; set; }
		public bool AddProgress(BranchProgress progress)
		{
			return Progress.Add(progress);
		}
		public string GetTwWeekMaterial(int week)
		{
			return Progress.Where(x => x.Week == week && x.PBranch == this).First().MaterialContent;
		}
	}

}
