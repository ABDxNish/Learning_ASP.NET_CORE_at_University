using AutoMapper;
using LabTaskFinal.DTOs;
using LabTaskFinal.EF;
using LabTaskFinal.EF.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabTaskFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        UMSContext db;
        public CategoryController(UMSContext db)
        {
            this.db = db;
        }
        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>().ReverseMap();
            });
            return new Mapper(config);
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = GetMapper().Map<List<CategoryDTO>>(db.Categories.ToList());
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(CategoryDTO ctg)
        {
            var data = GetMapper().Map<Category>(ctg);
            db.Categories.Add(data);
            db.SaveChanges();
            return Ok(data);
        }
        [HttpGet("find/{id}")]
        public IActionResult Find(int id)
        {
            var data = GetMapper().Map<CategoryDTO>(db.Categories.Find(id));
            if (data != null)
            {
                return Ok(data);
            }
            else { return NotFound(); }
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, CategoryDTO ctg)
        {
            var existing = db.Categories.Find(id);
            if (existing == null)
            {
                return NotFound();
            }

            GetMapper().Map(ctg, existing);
            db.SaveChanges();

            return Ok(existing);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = db.Categories.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            db.Categories.Remove(data);
            db.SaveChanges();

            return Ok("Category deleted successfully");
        }

    }
}
