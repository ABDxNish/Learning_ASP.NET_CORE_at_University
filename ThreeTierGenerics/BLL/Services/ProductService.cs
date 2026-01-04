using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        Repository<Product> repo;
        public ProductService(Repository<Product> repo)
        {
            this.repo = repo;
        }   
        public List<ProductDTO> GetAll()
        {
            var data=repo.GetAll();
            var mapper = MapperConfig.GetMapper();
            var ret=mapper.Map<List<ProductDTO>>(data);
            return ret;
        }
        public ProductDTO find(int id)
        {
            return MapperConfig.GetMapper().Map<ProductDTO>(repo.find(id));
        }
        public bool create(ProductDTO c)
        {
            var mapper=MapperConfig.GetMapper();
            var data = mapper.Map<Product>(c);
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
