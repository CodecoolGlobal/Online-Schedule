using System;

namespace CodecoolAvence.Model {
    public class Student : User
    {
        
        public Student(string name, Branch branch, string email) : base(name, email)
        {
            BranchProgress = new BranchProgress(branch);
            
        }

        public BranchProgress BranchProgress { get; set; }

	}

}
