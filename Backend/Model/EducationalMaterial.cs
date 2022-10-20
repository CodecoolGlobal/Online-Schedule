namespace CodecoolAdvanced.Model
{
    public class EducationalMaterial
    {
        private static int studentCounter = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public HashSet<string> Material { get; set; }

        public EducationalMaterial(string name)
        {
            Name = name;
            Id = studentCounter;
            studentCounter++;
            Material = new HashSet<string>();
        }
    }
}
