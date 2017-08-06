using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLDTO;
using QLBUS;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace CHTapHoa
{
    public partial class frmDoiMatKhau : Form
    {

        

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            Form1 frmMain = (Form1)this.MdiParent;
            txtTDN.Text = frmMain.NhanVienDN.HoTenNV;
        }

        private void btnDY_Click(object sender, EventArgs e)
        {
            TaiKhoanBUS tk=new TaiKhoanBUS();
            Form1 frmMain = (Form1)this.MdiParent;

            if (txtMKC.Text == "")
                XtraMessageBox.Show("Chưa nhập mật khẩu cũ", "Thông báo");
            else if (txtMKM.Text == "")
                XtraMessageBox.Show("Chưa nhập mật khẩu mới", "Thông báo");
            else if (txtNLMK.Text == "")
                XtraMessageBox.Show("Chưa nhập lại mật khẩu", "Thông báo");
            else if (txtMKM.Text != txtNLMK.Text)
                XtraMessageBox.Show("Mật khẩu không khớp", "Thông báo");
            else if (txtMKC.Text != frmMain.NhanVienDN.MatKhau)
                XtraMessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo");
            else
            {
                //Thực hiện đổi mk
                string manv = frmMain.NhanVienDN.MaNV;
                string mk = txtMKM.Text;
                int kq = tk.DoiMatKhauBUS(manv, mk);
                if(kq>0)
                {
                    XtraMessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                }
                else
                    XtraMessageBox.Show("Đổi mật khẩu thất bại!!!", "Thông báo");
            }

            txtMKC.Text = "";
            txtMKM.Text = "";
            txtNLMK.Text = "";
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnMKC_Click(object sender, EventArgs e)
        {
            if (txtMKC.Text != "")
            {
                if (txtMKC.Properties.PasswordChar == '*')
                    txtMKC.Properties.PasswordChar = '\0';
                else
                    txtMKC.Properties.PasswordChar = '*';
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo");
            }
        }

        private void btnMKM_Click(object sender, EventArgs e)
        {
            if (txtMKM.Text != "")
            {
                if (txtMKM.Properties.PasswordChar == '*')
                    txtMKM.Properties.PasswordChar = '\0';
                else
                    txtMKM.Properties.PasswordChar = '*';
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo");
            }
        }

        private void btnNLMK_Click(object sender, EventArgs e)
        {
            if (txtNLMK.Text != "")
            {
                if (txtNLMK.Properties.PasswordChar == '*')
                    txtNLMK.Properties.PasswordChar = '\0';
                else
                    txtNLMK.Properties.PasswordChar = '*';
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo");
            }
        }
    }
}
