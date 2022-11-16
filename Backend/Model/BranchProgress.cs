using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model
{
    public class BranchProgress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public Branch PBranch { get; set; }
        public string MaterialContent { get; set; }
        public int Week { get; set; }

    }

}
