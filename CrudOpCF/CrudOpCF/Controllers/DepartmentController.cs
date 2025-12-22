using AutoMapper;
using CrudOpCF.DTOs;
using CrudOpCF.EF;
using CrudOpCF.EF.Models;

using Microsoft.AspNetCore.Http;


using Microsoft.AspNetCore.Mvc;

namespace CrudOpCF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        UMSContext db;
        public DepartmentController(UMSContext db)
        {
            this.db = db;
        }
        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentDTO, Department>().ReverseMap();
            });
            return new Mapper(config);
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data=GetMapper().Map<List<DepartmentDTO>>(db.Departments.ToList());
            return Ok(data);
        }
        [HttpGet("find/{id}")]
        public IActionResult Find(int id) { 
        var data=GetMapper().Map<DepartmentDTO>(db.Departments.Find(id));
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(DepartmentDTO d)
        {
            var data = GetMapper().Map<Department>(d);
            db.Departments.Add(data);
            db.SaveChanges();
            return Ok(data);
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, DepartmentDTO d)
        {
            var existing = db.Departments.Find(id);
            if (existing == null)
            {
                return NotFound();
            }

            GetMapper().Map(d, existing);
            db.SaveChanges();

            return Ok(existing);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = db.Departments.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            db.Departments.Remove(data);
            db.SaveChanges();

            return Ok("Department deleted successfully");
        }

    }
}
