using System;

namespace CodecoolAvence.Model {
	public abstract class User {
		private string _name;

        protected User(string name)
        {
            _name = name;
        }
    }

}
