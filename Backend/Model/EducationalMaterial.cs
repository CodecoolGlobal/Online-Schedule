﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model
{
    public class EducationalMaterial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }
        public HashSet<Material> Materials { get; set; }

    }
}
