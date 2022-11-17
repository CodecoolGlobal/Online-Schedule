namespace CodecoolAdvanced.Model
{
    public class EducationMaterialCollector
    {
		private static EducationMaterialCollector? instance = null;

		private EducationMaterialCollector()
		{
			_materials = new HashSet<EducationalMaterial>();
		}

		public static EducationMaterialCollector Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new EducationMaterialCollector();
				}
				return instance;
			}
		}
		private HashSet<EducationalMaterial> _materials;
		
		public HashSet<EducationalMaterial> GetEducationalMaterials()
        {
			return _materials;
        }

		public EducationalMaterial GetEducationalMaterialById(int id)
        {
			return _materials.FirstOrDefault(x => x.ID == id);
        }

		public bool AddToMaterials(EducationalMaterial material)
		{
			return _materials.Add(material);
		}
		public void deleteFromMaterials(EducationalMaterial material)
        {
			_materials.Remove(material);
        }
	}

}
