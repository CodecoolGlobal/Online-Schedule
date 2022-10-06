using System;

namespace CodecoolAvence.Model {
	public class BranchProgress {
		public BranchProgress(Branch branch) 
		{
			Branch = branch;

		}
		public Branch Branch { get; }
		public string Progresess { get; private set; }
		private int _actualWeek;

		public void SetProgress()
        {
			throw new NotImplementedException(); // mentem ebédelni cya
        }
	
	}

}
