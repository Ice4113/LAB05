using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public List<Student> Getall_NoMajor()
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Student.Where(n => n.MajorID == null).ToList();
            }
        }
        public List<Student> GetAll_NoMajor(int FacultyID) 
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Student.Where(n => n.FacultyID == FacultyID && n.MajorID == null).ToList();
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
        public int Delete(Student S)
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                if (db_context.Student.Any(n => n.StudentId == S.StudentId))
                {
                    db_context.Student.Remove(S);
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
                else
                {
                    return 0;
                }
            }
        }
        public int Delete (string StudentID)
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                Student s = db_context.Student.FirstOrDefault(n => n.StudentId == StudentID);
                if (s == null)
                {
                    return 0;
                }
                else
                {
                    db_context.Student.Remove(s);
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
}
