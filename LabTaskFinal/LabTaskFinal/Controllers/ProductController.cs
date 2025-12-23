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
    public class ProductController : ControllerBase
    {
        UMSContext db;

        public ProductController(UMSContext db)
        {
            this.db = db;
        }
        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>().ReverseMap();
            });
            return new Mapper(config);
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = GetMapper().Map<List<ProductDTO>>(db.Products.ToList());
            return Ok(data);
        }

        [HttpPost("create")]
        public IActionResult Create(ProductDTO pd)
        {
           

            var data = GetMapper().Map<Product>(pd);
            var exist = db.Categories.Find(data.Cid);
            if (exist != null)
            {
                db.Products.Add(data);
                db.SaveChanges();

                return Ok(data);
            }
            else
            {
                return NotFound("Category Not Found");

            }
        }

        [HttpGet("find/{id}")]
        public IActionResult Find(int id)
        { 
            
            var data = GetMapper().Map<ProductDTO>(db.Products.Find(id));
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, ProductDTO pd)
        {
            var existing = db.Products.Find(id);
            if (existing == null)
            {
                return NotFound();
            }

            pd.Id = existing.Id;
            GetMapper().Map(pd, existing);
            db.SaveChanges();

            return Ok(existing);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = db.Products.Find(id);
            if (data == null)
                return NotFound();

            db.Products.Remove(data);
            db.SaveChanges();


            return Ok("Product deleted successfully");

        }
    }
}
