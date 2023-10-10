using System;
using System.IO;
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
using System.Security.Cryptography;

namespace LAB05
{
    public partial class Frm_QLSV : Form
    {
        private StudentDAO s_DAO = new StudentDAO();
        private FacultyDAO f_DAO = new FacultyDAO();
        private MajorDAO m_DAO = new MajorDAO();
        public Frm_QLSV()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkChuyenNganh_CheckedChanged(object sender, EventArgs e)
        {
            Fill_dgv_QLSV();
        }

        private void dgv_QLSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_QLSV.SelectedCells[0].RowIndex;
            if (dgv_QLSV.Rows[index].Cells["MSSV"].Value != null)
            {
                string studentID = dgv_QLSV.Rows[index].Cells["MSSV"].Value.ToString();
                Student S = s_DAO.GetStudent(studentID);
                txtStudentID.Text = S.StudentId;
                txtName.Text = S.Fullname;
                cbo_khoa.SelectedValue = S.FacultyID;
                txtAvarageScore.Text = S.AverageScore.ToString();
                if (S.Avatar == null )
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    fill_image(S.Avatar);
                }
            }
            
        }
        private void fill_image (string filename)
        {
            try
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string imagePath = Path.Combine(parentDirectory, "Images", filename);
                pictureBox1.Image = Image.FromFile(imagePath);
                pictureBox1.Refresh();
            }
            catch (Exception)
            {
                pictureBox1.Image = null;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text.Trim() == "")
            {
                MessageBox.Show("Mã Sv không được để trống ", "lỗi");
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Tên Sv không được để trống ", "lỗi");
                return;
            }
            if (txtAvarageScore.Text.Trim() == "")
            {
                MessageBox.Show("Diem TB không được để trống ", "lỗi");
            }
            float diemTB = 0;
            if (!float.TryParse(txtAvarageScore.Text,out diemTB))
            {
                MessageBox.Show("Điểm TB không đúng định dạng", "lỗi");
            }
            if (diemTB <0 || diemTB >10)
            {
                MessageBox.Show("Điểm Trung bình phải trong khoảng 0-10", "lỗi");
            }
            string filename = null;
            if (pictureBox1.Image != null)
            {
                string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                parentDirectory = Path.Combine(parentDirectory, "Images");
                DirectoryInfo dir = new DirectoryInfo(parentDirectory);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                filename = txtAvarageScore.Text + ".jpg";
                string imagePath = Path.Combine(parentDirectory, filename);
                pictureBox1.Image.Save(imagePath);
            }

            Student s = new Student()
            {
                StudentId = txtStudentID.Text,
                Fullname = txtName.Text,
                AverageScore = diemTB,
                FacultyID = int.Parse(cbo_khoa.SelectedValue.ToString()),
                Avatar = (filename == null) ? "" : filename
            };
            int ketqua = s_DAO.Update(s);
            if (ketqua == 0)
            {
                MessageBox.Show("Lưu kết quả thành công ", "kết quả");
                Fill_dgv_QLSV();
            }
            else
            {
                MessageBox.Show("Lưu kết quả thất bại ", "Lỗi");
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }
        private void cbo_khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_dgv_QLSV();
        }

        private void Frm_QLSV_Load(object sender, EventArgs e)
        {
            fill_cbo_khoa();
            Fill_dgv_QLSV();


        }
        private void fill_cbo_khoa()
        {
            List<Faculty> f_List = f_DAO.GetAll();
            cbo_khoa.DataSource = f_List;
            cbo_khoa.ValueMember = "FacultyID";
            cbo_khoa.DisplayMember = "FacultyName";
            this.cbo_khoa.SelectedIndexChanged += new System.EventHandler(this.cbo_khoa_SelectedIndexChanged);
        }
        private void  Fill_dgv_QLSV()
        {
            dgv_QLSV.Rows.Clear();
            int facultyID = int.Parse(cbo_khoa.SelectedValue.ToString());
            List<Student> s_List;
            if (checkChuyenNganh.Checked)
            {
                s_List=s_DAO.GetAll_NoMajor(facultyID);
            }
            else
            {
                s_List = s_DAO.GetAll(facultyID);
            }
            foreach(Student s in s_List)
            {
                string facultyName = null;
                if (s.FacultyID != null)
                {
                    facultyName = f_DAO.GetFaculty((int)s.FacultyID).FacultyName;
                }
                string majorName = null;
                if (s.FacultyID != null && s.MajorID !=null)
                {
                    majorName = m_DAO.GetMajor((int)s.FacultyID, (int)s.MajorID).Name;
                }
                    int index = dgv_QLSV.Rows.Add();
                dgv_QLSV.Rows[index].Cells["MSSV"].Value = s.StudentId;
                dgv_QLSV.Rows[index].Cells["HoTen"].Value = s.Fullname;
                dgv_QLSV.Rows[index].Cells["Khoa"].Value = (facultyName == null) ? "" : facultyName;
                dgv_QLSV.Rows[index].Cells["ChuyenNganh"].Value = (majorName == null) ? "" : majorName;
                dgv_QLSV.Rows[index].Cells["DTB"].Value = s.AverageScore;
            }
        }

        private void UploadAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog f_Dialog = new OpenFileDialog();
            f_Dialog.Filter = "All Files |*.*| JPEG Files|.jpg";
            if (f_Dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(f_Dialog.FileName);
            }
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Interval = 2000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (txtName.Text.Trim() == "")
            {
                pictureBox1.Image = null;
            }
            else
            {
                Student s = s_DAO.GetStudent(txtStudentID.Text);
                if (s == null || s.Avatar == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    fill_image(s.Avatar);
                }
            }
        }
    }
}
