using FirstApplication.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var s1 = new StudentDTO()
            {
                id = 1,
                name = "Abul",
                email   ="abdul@gmail.com"
            };
            var s2 = new StudentDTO()
            {
                id = 2,
                name = "Alhum",
                email = "alhum@gmail.com"
            };
            var data=new List<StudentDTO>() { s1, s2 };
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Post(StudentDTO s)
        {
            return Ok(s);
        }
    }
}
