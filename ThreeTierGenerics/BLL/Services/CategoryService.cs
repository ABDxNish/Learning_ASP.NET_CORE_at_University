using BLL.DTOs;
using DAL.EF;
using DAL.EF.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        Repository<Category> repo;
        
      public CategoryService(Repository<Category> repo)
        {
            this.repo = repo;
        }
        public List<CategoryDTO> GetAll()
        {
            var data = repo.GetAll();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<CategoryDTO>>(data);
            return ret;
        }
        public CategoryDTO find(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO>(repo.find(id));
        }
        public bool create(CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return repo.create(data);
        }

        public bool update(int id)
        {

            return true;
        }
        public bool delete(int id)
        {

            return repo.delete(id);
        }
    }
}
