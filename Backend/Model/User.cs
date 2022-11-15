using System;

namespace CodecoolAdvanced.Model {
	public abstract class User {
		public string Name { get; set; }
        private static int studentCounter = 0;


        public string Role { get; }
        public string Email { get; }
        public int Id { get; private set; }
        protected User(string name, string email)
        {
            Email = email;
            Name = name;
            Id = studentCounter;
            studentCounter++;
        }

    }

}
