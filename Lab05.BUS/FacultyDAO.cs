using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB05.DAL.Entites;

namespace Lab05.BUS
{
    public class FacultyDAO
    {
        public List<Faculty> GetAll()
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Faculty.ToList();
            }
        }

        public Faculty GetFaculty(int facultyID)
        {
            using (QLSVEntities db_context = new QLSVEntities())
            {
                return db_context.Faculty.FirstOrDefault(n => n.FacultyID == facultyID);
            }
        }

    }
}
