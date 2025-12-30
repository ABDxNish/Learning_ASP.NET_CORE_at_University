using BLL.DTOs;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace NtierArch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentService service;
        public StudentController(StudentService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult All() { 
        var data=service.Get();
            if (data != null)
            {
                return Ok(data);
            }

                return NotFound();
        }
        [HttpPost("create")]
        public IActionResult Create(StudentDTO s)
        {
            var res=service.Create(s);
            return Ok(res);
        }
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = service.Delete(id);
            if(data!=null){
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
            }
        [HttpPost("find/{id}")]
        public IActionResult Find(int id) {
            var data = service.Find(id);
            if (data != null) { 
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("Update/{id}")]
        public IActionResult Update(int id,StudentDTO d) { 
            var data=service.Update(id,d);
            if (data != null)
            {

                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        
        }


        }
}
