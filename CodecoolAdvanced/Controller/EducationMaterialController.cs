using Microsoft.AspNetCore.Mvc;
using CodecoolAdvanced.Model;

namespace CodecoolAdvanced.Controller
{
    [ApiController]
    [Route("api/material")]
    public class EducationMaterialController : ControllerBase
    {
        [HttpGet]
        public ActionResult<HashSet<EducationalMaterial>> GetAllMaterials()
        {
            HashSet<EducationalMaterial> materials = EducationMaterialCollector.Instance.GetEducationalMaterials();
            return Ok(materials);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<EducationalMaterial> GetMaterialById(int id)
        {
            EducationalMaterial material = EducationMaterialCollector.Instance.GetEducationalMaterialById(id);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(material);
        }

        [HttpPost]
        public ActionResult<EducationalMaterial> CreateNewEducationMaterial(string name)
        {
            EducationalMaterial material = new EducationalMaterial(name);
            EducationMaterialCollector.Instance.AddToMaterials(material);
            return Ok(material);
        }
    }
}
