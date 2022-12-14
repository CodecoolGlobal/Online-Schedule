using Microsoft.AspNetCore.Mvc;
using CodecoolAdvanced.Model;

namespace CodecoolAdvanced.Controller
{
    [ApiController]
    [Route("api/material")]
    public class EducationMaterialController : ControllerBase
    {
        private readonly CodecoolContext _context;

        public EducationMaterialController(CodecoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<EducationalMaterial>> GetAllMaterials()
        {
            return await _context.GetMaterial();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EducationalMaterial> GetMaterialById(int id)
        {
            return await _context.GetMaterialById(id);
        }

        [HttpPost]
        public async Task<EducationalMaterial> CreateNewEducationMaterial(string name)
        {
            EducationalMaterial ematerial = new() { 
            Name = name
            };
            return await _context.CreateEMaterial(ematerial);
        }

        [HttpPut]
        [Route("{id}/add")]
        public async Task<EducationalMaterial> AddMaterialToEducationMaterial(int id, string material)
        {
            return await _context.AddMaterial(material, id);
        }
        [HttpDelete]
        [Route("{id}/remove")]
        public async Task RemoveMaterial(int id)
        {
            _context.RemoveMaterial(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteEducationMaterial(int id)
        {
            _context.RemoveEm(id);
        }
    }
}
