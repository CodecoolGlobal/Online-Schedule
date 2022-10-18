using System;

namespace CodecoolAvence.Model {
	public abstract class User {
		private string _name;
        private static int studentCounter = 0;
        public int Id { get; private set; }
        protected User(string name)
        {
            _name = name;
            Id = studentCounter;
            studentCounter++;
        }
    }

}
