using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model
{
    public class EducationalMaterial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        private static int studentCounter = 0;
        public string Name { get; set; }
        public HashSet<string> Material { get; set; }

        public EducationalMaterial(string name)
        {
            Name = name;
            ID = studentCounter;
            studentCounter++;
            Material = new HashSet<string>();
        }
    }
}
