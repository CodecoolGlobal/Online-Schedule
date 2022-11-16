using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model {
	public abstract class User {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

		public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }

}
