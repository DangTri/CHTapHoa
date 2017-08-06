using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLBUS;
using QLDTO;
using DevExpress.XtraEditors;

namespace CHTapHoa
{
    public partial class frmDangNhap : Form
    {
        NhanVienBUS nvbus = new NhanVienBUS();
        List<NhanVienDTO> lstnv = new List<NhanVienDTO>();
        NhanVienDTO nvdn = null;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            lstnv = nvbus.DanhSachNhanVien();
            cbbTTK.DataSource = lstnv;
            cbbTTK.DisplayMember = "HoTenNV";
            cbbTTK.ValueMember = "MaNV";
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            nvdn = (NhanVienDTO)cbbTTK.SelectedItem;
            if(nvdn == null || txtMK.Text == "")
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu !!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(nvdn.MatKhau != txtMK.Text)
                {
                    XtraMessageBox.Show("Mật khẩu không đúng !!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    (this.MdiParent as Form1).SetTrangThaiDangNhap(nvdn);
                    this.Close();
                }
            }

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (txtMK.Text != "")
            {
                if (txtMK.PasswordChar == '*')
                    txtMK.PasswordChar = '\0';
                else
                    txtMK.PasswordChar = '*';
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
