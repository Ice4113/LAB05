using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab05.BUS;
using LAB05.DAL.Entites;
namespace LAB05
{
   
    public partial class frm_Dangki : Form
    {
        private StudentDAO s_DAO = new StudentDAO();
        private FacultyDAO f_DAO = new FacultyDAO();
        private MajorDAO m_DAO = new MajorDAO();
        public frm_Dangki()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcbo_chuyenganh();
            fill_dgv_DDSV();
        }


        private void Add_Click(object sender, EventArgs e)
        {
            int majorID = int.Parse(CboChuyenNgnah.SelectedValue.ToString());
            for (int i=0; i< dgvDangKi.Rows.Count; i++)
            {
                if (dgvDangKi.Rows[i].Cells["Chon"].Value != null &&
                    bool.Parse(dgvDangKi.Rows[i].Cells["Chon"].Value.ToString()));
                {
                    string studentID = dgvDangKi.Rows[i].Cells["MaSV"].Value.ToString();
                    Student s = s_DAO.GetStudent(studentID);
                    if (s != null)
                    {
                        s.MajorID = majorID;
                        int ketqua = s_DAO.Update(s);
                        if (ketqua==0)
                        {
                            MessageBox.Show("Thêm Chuyên Ngành Thành Công ", "Kết quả");
                            fill_dgv_DDSV();
                        }
                        else
                        {
                            MessageBox.Show("Thêm Chuyên Ngành Thất Bại", "Kết quả");
                        }
                    }
                }

                
                    
                 
            }
        }

        private void frm_Dangki_Load(object sender, EventArgs e)
        {
            format_dgv_QLSV();
            fillcbo_Khoa();
            fillcbo_chuyenganh();
            fill_dgv_DDSV();
        }
        private void format_dgv_QLSV()
        {
            dgvDangKi.Columns.Clear();
            DataGridViewCheckBoxColumn column= new DataGridViewCheckBoxColumn();
            column.Name = ("chon");
            column.HeaderText = ("Chọn");
            dgvDangKi.Columns.Add(column);
            dgvDangKi.Columns.Add("MaSV", "Mã SV");
            dgvDangKi.Columns.Add("HoTen", "Họ Tên");
            dgvDangKi.Columns["HoTen"].Width = 160;
            dgvDangKi.Columns.Add("Khoa", "khoa");
            dgvDangKi.Columns.Add("DiemTB", "Điểm TB");
        }
        public void fillcbo_Khoa()
        {
            List<Faculty> f_List = f_DAO.GetAll();
            cboKhoa.DataSource = f_List;
            cboKhoa.ValueMember = "FacultyID";
            cboKhoa.DisplayMember = "FacultyName";
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
        }
        public void fillcbo_chuyenganh()
        {
            int facultyID = int.Parse(cboKhoa.SelectedValue.ToString());
            List<Major> m_List = m_DAO.GetAll(facultyID);
            CboChuyenNgnah.DataSource = m_List;
            CboChuyenNgnah.ValueMember = "MajorID";
            CboChuyenNgnah.DisplayMember = "Name";
            
        }
        public void fill_dgv_DDSV()
        {
            dgvDangKi.Rows.Clear();
            int facultyID = int.Parse(cboKhoa.SelectedValue.ToString());
            List<Student> s_List = s_DAO.GetAll_NoMajor(facultyID);
        
            foreach (Student s in s_List)
                
            {
                string facultyName = null;
                if (s.FacultyID != null)
                {
                    facultyName = f_DAO.GetFaculty((int)s.FacultyID).FacultyName;
                }

                    int index = dgvDangKi.Rows.Add();
                    dgvDangKi.Rows[index].Cells["Chon"].Value = false;
                    dgvDangKi.Rows[index].Cells["MaSV"].Value = s.StudentId;
                    dgvDangKi.Rows[index].Cells["HoTen"].Value = s.Fullname;
                    dgvDangKi.Rows[index].Cells["Khoa"].Value = (facultyName == null) ? "" : facultyName;
                    dgvDangKi.Rows[index].Cells["DiemTB"].Value = s.AverageScore;
                

            }
        }

        private void CboChuyenNgnah_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
