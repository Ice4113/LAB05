using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB05.DAL.Entites;

namespace Lab05.BUS
{
    public class StudentDAO
    {
        public List <Student> Getall()
        {
            using (QLSVEntities db_context = new QLSVEntities())
                    {
                return db_context.Student.ToList();
            }
        }
        public List<Student> GetAll(int FacultyID)
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Student.Where(n => n.FacultyID == FacultyID).ToList();
            }
        }
        public List<Student> GetAll_NoMajor(int FacultyID) 
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Student.Where(n => n.MajorID == null).ToList();
            }
        }
        public Student GetStudent (string studentID)
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Student.FirstOrDefault(n => n.StudentId == studentID);
            }
        }
        public int Update(Student s)
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                if (db_context.Student.Any(n => n.StudentId == s.StudentId)) 
                    //update 
                {
                    db_context.Entry(s).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db_context.Student.Add(s);
                }
                try
                {
                    db_context.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
    }
}
