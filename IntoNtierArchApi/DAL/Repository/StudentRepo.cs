using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class StudentRepo
    {
        UMSContext db;
        public StudentRepo(UMSContext db)
        {
            this.db = db;
        }
        public bool Create(Student s)
        {
            db.Students.Add(s);
            return db.SaveChanges() > 0;
        }
        public List<Student> Get()
        {
            return db.Students.ToList();
        }
        public bool Delete(int id)
        {
            var data = db.Students.Find(id);
           db.Students.Remove(data);
            return db.SaveChanges() > 0;
        }
        public Student Find(int id)
        {
            var data=db.Students.Find(id);
            return data;
        }
        public Student Update(int id, Student student)
        {
            var exist = db.Students.Find(id);

            if (exist == null)
            {
                return null;
            }
            exist.Name = student.Name;

            db.SaveChanges();

            return exist;
        }

    }
}
