using crudOperation.DTOs;
using crudOperation.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly DotNetApiContext db;
        public ProductController(DotNetApiContext db)
        {
            this.db = db;
        }

        [HttpGet("all")]
        public IActionResult all()
        {
            var data=db.Products.ToList();
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(ProductsDTO pro)
        {
            var data = new Product
            {
                ProductName = pro.ProductName,
                ProductType = pro.ProductType,
                Quantity = pro.Quantity,
                Price = pro.Price
            };

            db.Products.Add(data);
            db.SaveChanges();

            return Ok(data);
        }

        [HttpDelete("delete/{id}")]

        public IActionResult Delete(int id)
        {
            var data = db.Products.Find(id);

            if (data == null)
            {
                return NotFound("Not found");
            }

            db.Products.Remove(data);
            db.SaveChanges();

            return Ok(data);
        }
        [HttpPost("update/{id}")]
        public IActionResult Update(int id, ProductsDTO p)
        {
            var data = db.Products.Find(id);
            if (data == null) { 
                return NotFound("Not found");
        }
            data.ProductName=p.ProductName;
            data.ProductType=p.ProductType; 
            data.Quantity=p.Quantity;
            data.Price=p.Price;
            db.SaveChanges();
            return Ok(data);

        }

    }
}
