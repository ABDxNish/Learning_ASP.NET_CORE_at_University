using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService service;
        public CategoryController(CategoryService service) { 
        this .service = service;    
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.GetAll();
            return Ok(data);
        }
        [HttpGet("find/{id}")]
        public IActionResult find(int id)
        {
            var data = service.find(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(CategoryDTO c)
        {
            var res = service.create(c);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
