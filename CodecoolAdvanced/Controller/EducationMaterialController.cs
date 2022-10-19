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
    }
}
