//using Microsoft.AspNetCore.Mvc;
//using CodecoolAdvanced.Model;

//namespace CodecoolAdvanced.Controller
//{
//    [ApiController]
//    [Route("api/material")]
//    public class EducationMaterialController : ControllerBase
//    {
//        [HttpGet]
//        public ActionResult<HashSet<EducationalMaterial>> GetAllMaterials()
//        {
//            HashSet<EducationalMaterial> materials = EducationMaterialCollector.Instance.GetEducationalMaterials();
//            return Ok(materials);
//        }

//        [HttpGet]
//        [Route("{id}")]
//        public ActionResult<EducationalMaterial> GetMaterialById(int id)
//        {
//            EducationalMaterial material = EducationMaterialCollector.Instance.GetEducationalMaterialById(id);
//            if (material == null)
//            {
//                return NotFound();
//            }
//            return Ok(material);
//        }

//        [HttpPost]
//        public ActionResult<EducationalMaterial> CreateNewEducationMaterial(string name)
//        {
//            EducationalMaterial material = new EducationalMaterial(name);
//            EducationMaterialCollector.Instance.AddToMaterials(material);
//            return Ok(material);
//        }

//        [HttpPut]
//        [Route("{id}/add")]
//        public ActionResult AddMaterialToEducationMaterial(int id, string material)
//        {
//            EducationalMaterial EduMaterial = EducationMaterialCollector.Instance.GetEducationalMaterialById(id);
//            if (EduMaterial == null)
//            {
//                return NotFound();
//            }
//            if (EduMaterial.Material.Add(material))
//            {
//                return NoContent();
//            }
//            return BadRequest();
//        }
//        [HttpPut]
//        [Route("{id}/remove")]
//        public ActionResult RemoveMaterialToEducationMaterial(int id, string material)
//        {
//            EducationalMaterial EduMaterial = EducationMaterialCollector.Instance.GetEducationalMaterialById(id);
//            if (EduMaterial == null)
//            {
//                return NotFound();
//            }
//            if (EduMaterial.Material.Remove(material))
//            {
//                return NoContent();
//            }
//            return BadRequest();
//        }

//        [HttpDelete]
//        [Route("{id}")]
//        public ActionResult DeleteEducationMaterial(int id)
//        {
//            EducationalMaterial EduMaterial = EducationMaterialCollector.Instance.GetEducationalMaterialById(id);
//            if (EduMaterial == null)
//            {
//                return NotFound();
//            }
//            EducationMaterialCollector.Instance.deleteFromMaterials(EduMaterial);
//            return NoContent();
//        }
//    }
//}
