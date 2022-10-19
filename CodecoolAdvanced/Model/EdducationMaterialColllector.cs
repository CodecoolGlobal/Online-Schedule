namespace CodecoolAdvanced.Model
{
    public class EdducationMaterialColllector
    {
		private static EdducationMaterialColllector instance = null;

		private EdducationMaterialColllector()
		{
			_materials = new HashSet<EducationalMaterial>();
		}

		public static EdducationMaterialColllector Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new EdducationMaterialColllector();
				}
				return instance;
			}
		}


		private HashSet<EducationalMaterial> _materials;
	}
}
