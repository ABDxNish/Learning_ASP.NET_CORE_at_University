using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<T> where T : class
    {
        DbSet<T> table;
        UMSContext db;
        public Repository(UMSContext db) {
            this.db = db;
            table=db.Set<T>();
        }
        public List<T> GetAll() { 
        return table.ToList();  
        }
        public T find(int id)
        {
            return table.Find(id);

        }

        public bool create(T obj)
        {
            table.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update()
        {
            return true;
        }
        public bool delete(int id)
        {   
            var ex=find(id);
            table.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
