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
    public partial class frmNhanVien : Form
    {
        List<NhanVienDTO> dsnv = new List<NhanVienDTO>();
        NhanVienBUS nhanvienbus = new NhanVienBUS();
        NhanVienDTO nhanviendto = new NhanVienDTO();
        LoaiNhanVienBUS lnvbus = new LoaiNhanVienBUS();
        List<LoaiNhanVienDTO> dslnv = new List<LoaiNhanVienDTO>();


        public frmNhanVien()
        {
            InitializeComponent();
            dslnv = lnvbus.LayLoaiNhanVien();
        }

        List<NhanVienDTO> lst = new NhanVienBUS().DanhSachNhanVien();
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            
            dsnv = nhanvienbus.DanhSachNhanVien();
            
            gctNhanVien.DataSource = dsnv;

            lueLNV.Properties.DataSource = dslnv;
            lueLNV.Properties.DisplayMember = "LoaiNV";
            lueLNV.Properties.ValueMember = "MaLoaiNV";
            lueLNV.ItemIndex = 1;

            gctNhanVien.DataSource = nhanvienbus.DanhSachNhanVien();

            txtMNV.Text = lst[0].MaNV;
            txtHNV.Text = lst[0].HoNV;
            txtTNV.Text = lst[0].TenNV;
            txtGT.Text = lst[0].GioiTinh;
            txtSDT.Text = lst[0].SDT;
            txtMK.Text = lst[0].MatKhau;
            dateNS.DateTime = lst[0].NgaySinh;
            lueLNV.Text = lst[0].MaLoaiNV;
            txtDC.Text = lst[0].DiaChi;
            txtL.Text = lst[0].Luong.ToString();
            ptbHinhNV.ImageLocation = lst[0].HinhAnh;

            btnT.Enabled = false;
            btnS.Enabled = false;
            btnX.Enabled = false;
            btnLM.Enabled = true;
            btnRP.Enabled = true;
            btnEC.Enabled = false;



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
            txtMNV.EditValue = nhanvienbus.TangNhanVien();
            txtTNV.Text = "";
            txtSDT.Text = "";
            txtSDT.Text = "";
            txtMK.Text = "123456";
            txtL.Text = "";
            txtGT.Text = "";
            txtDC.Text = "";
            txtHNV.Text = "";
            dateNS.Text = "";
            ptbHinhNV.ImageLocation="";

            lueLNV.ItemIndex = 0;

            btnT.Enabled = true;
            btnS.Enabled = false;
            btnX.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;
        }

        private void btnT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                if (txtMNV.Text == "" || txtHNV.Text == "" || txtTNV.Text == "" || txtMK.Text == "" || txtGT.Text == "" || txtDC.Text == "" || txtSDT.Text == "" || txtL.Text == "")
                {
                    XtraMessageBox.Show("Chưa nhập đủ thông tin!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    nhanviendto.MaNV = txtMNV.Text;
                    nhanviendto.HoNV = txtHNV.Text;
                    nhanviendto.TenNV = txtTNV.Text;
                    nhanviendto.MaLoaiNV = lueLNV.EditValue.ToString();
                    nhanviendto.MatKhau = txtMK.Text;
                    nhanviendto.GioiTinh = txtGT.Text;
                    nhanviendto.NgaySinh = Convert.ToDateTime(dateNS.Text);
                    nhanviendto.DiaChi = txtDC.Text;
                    nhanviendto.SDT = txtSDT.Text;
                    nhanviendto.Luong = Convert.ToDouble(txtL.Text);
                    nhanviendto.HinhAnh = lblDuongDan.Text;
                    if (nhanvienbus.ThemNhanVien(nhanviendto))
                    {
                        XtraMessageBox.Show("Thêm thành công!","Thông báo", MessageBoxButtons.OK);
                        gctNhanVien.DataSource = nhanvienbus.DanhSachNhanVien();
                        txtMNV.Text = nhanvienbus.TangNhanVien();
                        txtHNV.Text = "";
                        txtTNV.Text = "";
                        txtGT.Text = "";
                        txtSDT.Text = "";
                        txtMK.Text = "";
                        txtDC.Text = "";
                        txtL.Text = "";

                        btnT.Enabled = false;
                        btnS.Enabled = false;
                        btnX.Enabled = false;
                        btnLM.Enabled = false;
                        btnEC.Enabled = false;
                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm thất bại!");
                    }
                } 
        }

        private void btnS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNV.Text == "" || txtHNV.Text == "" || txtTNV.Text == "" || txtMK.Text == "" || txtGT.Text == "" || txtDC.Text == "" || txtSDT.Text == "" || txtL.Text == "")
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                nhanviendto.MaNV = txtMNV.Text;
                nhanviendto.HoNV = txtHNV.Text;
                nhanviendto.TenNV = txtTNV.Text;
                nhanviendto.MaLoaiNV = lueLNV.EditValue.ToString();
                nhanviendto.MatKhau = txtMK.Text;
                nhanviendto.GioiTinh = txtGT.Text;
                nhanviendto.DiaChi = txtDC.Text;
                nhanviendto.Luong = Convert.ToDouble(txtL.Text);
                nhanviendto.HinhAnh = lblDuongDan.Text;
                nhanviendto.SDT = txtSDT.Text;
                nhanviendto.NgaySinh = DateTime.Parse(dateNS.EditValue.ToString());

                if (nhanvienbus.SuaNhanVien(nhanviendto) == true)
                {
                    XtraMessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK);
                    txtHNV.Text = "";
                    txtTNV.Text = "";
                    txtGT.Text = "";
                    txtSDT.Text = "";
                    txtMK.Text = "";
                    txtDC.Text = "";
                    txtL.Text = "";

                    ptbHinhNV.ImageLocation = "";

                    btnT.Enabled = false;
                    btnS.Enabled = false;
                    btnX.Enabled = false;
                    btnLM.Enabled = false;
                    btnEC.Enabled = false;
                }
                else
                {
                    XtraMessageBox.Show("Sửa thất bại");
                }
                gctNhanVien.DataSource = nhanvienbus.DanhSachNhanVien();
            }  
        }

        private void btnX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int vt = this.gridView1.FocusedRowHandle;
            string ttht = (gridView1.GetRowCellValue(vt, gridView1.Columns["MaLoaiNV"]).ToString());
            if (ttht != "QUẢN LÝ")
            { 
             string manv = txtMNV.Text;
             DialogResult dr;
             dr = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             if (dr == DialogResult.No)
             {

             }
                else
             {
                if (nhanvienbus.XoaNhanVien(manv) == true)
                    gctNhanVien.DataSource = nhanvienbus.DanhSachNhanVien();
             }
            }
            else
            {
                XtraMessageBox.Show("Bạn không được xóa QUẢN LÝ","Thông Báo!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                txtHNV.Text = "";
                txtTNV.Text = "";
                txtGT.Text = "";
                txtSDT.Text = "";
                txtMK.Text = "";
                txtDC.Text = "";
                txtL.Text = "";

             btnT.Enabled = false;
             btnS.Enabled = false;
             btnX.Enabled = false;
             btnLM.Enabled = false;
             btnEC.Enabled = false;
    }

        private void btnTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsFindPanelVisible)
                gridView1.HideFindPanel();
            else
                gridView1.ShowFindPanel();
        }

        private void btnHMK_Click(object sender, EventArgs e)
        {
            if (txtMK.Text != "")
            {
                if (txtMK.Properties.PasswordChar == '*')
                    txtMK.Properties.PasswordChar = '\0';
                else
                    txtMK.Properties.PasswordChar = '*';
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn nhân viên", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }



        private void txtL_TextChanged(object sender, EventArgs e)
        {
            if (txtL.Text == "0")
                txtL.Text = "";
            else
            {
                try
                {
                    txtL.Text = string.Format("{0:0,0}", double.Parse(txtL.Text));
                }
                catch (Exception)
                {

                }
            }
        }

        private void txtL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                CRNhanVien nv = new CRNhanVien();
                nv.Dock = DockStyle.Fill;
                nv.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnInDTNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            txtMNV.Text = gridView1.GetRowCellValue(e.RowHandle, "MaNV").ToString();
            txtHNV.Text = gridView1.GetRowCellValue(e.RowHandle, "HoNV").ToString();
            txtTNV.Text = gridView1.GetRowCellValue(e.RowHandle, "TenNV").ToString();
            txtMK.Text = gridView1.GetRowCellValue(e.RowHandle, "MatKhau").ToString();
            txtGT.Text = gridView1.GetRowCellValue(e.RowHandle, "GioiTinh").ToString();
            dateNS.DateTime = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, "NgaySinh").ToString());
            txtDC.Text = gridView1.GetRowCellValue(e.RowHandle, "DiaChi").ToString();
            txtSDT.Text = gridView1.GetRowCellValue(e.RowHandle, "SDT").ToString();
            txtL.Text = gridView1.GetRowCellValue(e.RowHandle, "Luong").ToString();
            ptbHinhNV.ImageLocation = gridView1.GetRowCellValue(e.RowHandle, "HinhAnh").ToString();
            lblDuongDan.Text = gridView1.GetRowCellValue(e.RowHandle, "HinhAnh").ToString();
            string lnv = gridView1.GetRowCellValue(e.RowHandle, "MaLoaiNV").ToString();
            if (lnv == "QUẢN LÝ")
                lueLNV.ItemIndex = 0;
            else if (lnv == "BÁN HÀNG")
                lueLNV.ItemIndex = 1;
            else
                lueLNV.ItemIndex = 2;

            btnT.Enabled = false;
            btnS.Enabled = true;
            btnX.Enabled = true;
            btnLM.Enabled = true;
            btnEC.Enabled = true;
            btnRP.Enabled = true;
        }

        private void ptbHinhNV_Click(object sender, EventArgs e)
        {
            if (ofdHinhAnh.ShowDialog() == DialogResult.OK)
            {
                lblDuongDan.Text = ptbHinhNV.ImageLocation = ofdHinhAnh.FileName;
            }
        }

       
    }
}
