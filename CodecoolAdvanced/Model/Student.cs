using System;

namespace CodecoolAvence.Model {
	public class Student : User  {
		public BranchProgress BranchProgress { get; set; }

		public void AutoSetCurrentWeek() {
			throw new System.NotImplementedException("Not implemented");
		}

	}

}
