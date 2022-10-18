using System;

namespace CodecoolAvence.Model {
    public class Student : User
    {
        
        public Student(string name, Branch branch) : base(name)
        {
            BranchProgress = new BranchProgress(branch);
            
        }

        public BranchProgress BranchProgress { get; set; }

	}

}
