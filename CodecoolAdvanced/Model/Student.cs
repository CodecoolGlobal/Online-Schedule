using System;

namespace CodecoolAvence.Model {
    public class Student : User
    {
        private static int studentCounter=0;
        public int Id { get; private set; }
        public Student(string name, Branch branch) : base(name)
        {
            BranchProgress = new BranchProgress(branch);
            Id = studentCounter;
            studentCounter++;
        }

        public BranchProgress BranchProgress { get; set; }

	}

}
