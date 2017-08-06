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
using DevExpress.XtraGrid.Views.Grid;

namespace CHTapHoa
{
    public partial class frmKhachHang : Form
    {
        List<KhachHangDTO> dskh = new List<KhachHangDTO>();
        KhachHangBUS khbus = new KhachHangBUS();
        KhachHangDTO khdto = new KhachHangDTO();

        public frmKhachHang()
        {
            InitializeComponent();
        }

        List<KhachHangDTO> lst = new KhachHangBUS().DanhSachKhachHang();
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            
            gctKH.DataSource = khbus.DanhSachKhachHang();

            btnT.Enabled = false;
            btnX.Enabled = false;
            btnS.Enabled = false;
            btnLM.Enabled = true;
            btnEC.Enabled = false;

            txtMKH.Text = lst[0].MaKH;
            txtTKH.Text = lst[0].TenKH;
            txtDC.Text = lst[0].DiaChi;
            txtSDT.Text = lst[0].SDT;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMKH.EditValue = khbus.TangKhachHang();
            txtTKH.Text = "";
            txtSDT.Text = "";
            txtDC.Text = "";

            btnT.Enabled = true;
            btnX.Enabled = false;
            btnS.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;
        }

        private void btnT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMKH.Text==""||txtTKH.Text==""||txtDC.Text==""||txtSDT.Text=="")
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                khdto.MaKH = txtMKH.Text;
                khdto.TenKH = txtTKH.Text;
                khdto.DiaChi = txtDC.Text;
                khdto.SDT = txtSDT.Text;
                if(khbus.ThemKhachHang(khdto))
                {
                    XtraMessageBox.Show("Thêm thành công","Thông báo", MessageBoxButtons.OK);
                    txtMKH.Text = khbus.TangKhachHang();
                    txtTKH.Text = "";
                    txtDC.Text = "";
                    txtSDT.Text = "";

                    btnT.Enabled = false;
                    btnX.Enabled = false;
                    btnS.Enabled = false;
                    btnLM.Enabled = false;
                    btnEC.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show("Thêm thất bại","Thông báo");
                }
                gctKH.DataSource = khbus.DanhSachKhachHang();
            }
        }

        private void btnS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMKH.Text == "" || txtTKH.Text == "" || txtDC.Text == "" || txtSDT.Text == "")
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                khdto.MaKH = txtMKH.Text;
                khdto.TenKH = txtTKH.Text;
                khdto.DiaChi = txtDC.Text;
                khdto.SDT = txtSDT.Text;
                if (khbus.SuaKhachHang(khdto))
                {
                    XtraMessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                    txtTKH.Text = "";
                    txtDC.Text = "";
                    txtSDT.Text = "";

                    btnT.Enabled = true;
                    btnX.Enabled = false;
                    btnS.Enabled = false;
                    btnLM.Enabled = false;
                    btnEC.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show("Sửa thất bại", "Thông báo");
                }
                gctKH.DataSource = khbus.DanhSachKhachHang();
            }
        }

        private void btnX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string makh = txtMKH.Text;
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
            {

            }
            else
            {
                if (khbus.XoaKhachHang(makh) == true)
                    gctKH.DataSource = khbus.DanhSachKhachHang();
            }

            btnT.Enabled = false;
            btnX.Enabled = false;
            btnS.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;

            txtTKH.Text = "";
            txtDC.Text = "";
            txtSDT.Text = "";
        }

        private void btnTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsFindPanelVisible)
                gridView1.HideFindPanel();
            else
                gridView1.ShowFindPanel();
        }

        private void btnEX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private Form KiemTraTonTai(Type fType)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                {
                    return f;
                }
            }
            return null;
        }
        private void btnRP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmSanPham));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                CRKhachHang nv = new CRKhachHang();
                nv.Dock = DockStyle.Fill;
                nv.Show();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            txtMKH.Text = gridView1.GetRowCellValue(e.RowHandle, "MaKH").ToString();
            txtTKH.Text = gridView1.GetRowCellValue(e.RowHandle, "TenKH").ToString();
            txtSDT.Text = gridView1.GetRowCellValue(e.RowHandle, "SDT").ToString();
            txtDC.Text = gridView1.GetRowCellValue(e.RowHandle, "DiaChi").ToString();

            btnT.Enabled = false;
            btnX.Enabled = true;
            btnS.Enabled = true;
            btnLM.Enabled = true;
            btnEC.Enabled = true;
        }
    }
}
