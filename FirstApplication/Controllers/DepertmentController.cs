using FirstApplication.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepertmentController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult All()
        {
            var d1=new DepertmentDTO()
            {
                id = 1,
                name="CSE"
            };   
            var d2=new DepertmentDTO()
            {
                id = 2,
                name="EEE"
            };
            var data = new List<DepertmentDTO>() { d1, d2 };

            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var d1 = new DepertmentDTO()
            {
                id = id,
                name = id + "s depertment"
        };
            return Ok(d1);
        }
        [HttpGet("id/{id}/name/{name}")]
        public IActionResult Get(int id ,string name) {
            var d1 = new DepertmentDTO()
            {
                id = id,
                name = name
        };
            return Ok(d1);
        }
        [HttpPost("create")]
        public IActionResult Create(DepertmentDTO dto)
        {
            return Ok(dto);
        }


    }
}
