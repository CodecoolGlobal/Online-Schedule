namespace CodecoolAdvanced.Model
{
    public class EducationalMaterial
    {
        public EducationalMaterial(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public HashSet<string> Material { get; set; }

    }
}
