using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class StudentService
    {
        StudentRepo repo;
        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        } 
        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public List<StudentDTO> Get()
        {
            List<Student> data = repo.Get();
            var ret = GetMapper().Map<List<StudentDTO>>(data);
            return ret;
        }
        public bool Create(StudentDTO st)
        {
            Student s=GetMapper().Map<Student>(st);
            return repo.Create(s);
        }
        public bool Delete(int id) { 
        return repo.Delete(id);
        }
        public StudentDTO Find(int id)
        {
            var data=repo.Find(id);
            var res=GetMapper().Map<StudentDTO>(data);
            return res;
            
        }
        public StudentDTO Update(int id, StudentDTO d)
        {
            var s = GetMapper().Map<Student>(d);

            var updated = repo.Update(id, s);

            if (updated == null)
            {
                return null;
            }

            return d;
        }

    }
}
