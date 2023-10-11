using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB05.DAL.Entites;

namespace Lab05.BUS
{
    public class MajorDAO
    {
        public List<Major> GetAll()
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Major.ToList();
            }

        }
        public List<Major> GetAll(int facultyID)
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Major.Where(n => n.FacultyID == facultyID).ToList();
            }
        }
        public Major GetMajor(int facultyID,int majorID)
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Major.FirstOrDefault(n => n.FacultyID == facultyID && n.MajorID == majorID);
            }
        }
    }
}
