using System;

namespace CodecoolAvence.Model {
	public abstract class User {
		private string _name;
        private static int studentCounter = 0;
        private string name;

        public string Email { get; }
        public int Id { get; private set; }
        protected User(string name, string email)
        {
            Email = email;
            _name = name;
            Id = studentCounter;
            studentCounter++;
        }

        protected User(string name)
        {
            this.name = name;
        }
    }

}
