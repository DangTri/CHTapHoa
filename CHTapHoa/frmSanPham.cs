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
    public partial class frmSanPham : Form
    {
        List<SanPhamDTO> dssp = new List<SanPhamDTO>();
        SanPhamDTO sanphamdto = new SanPhamDTO();
        SanPhamBUS sanphambus = new SanPhamBUS();
        LoaiSanPhamBUS lspbus = new LoaiSanPhamBUS();
        NhaCungCapBUS nccbus = new NhaCungCapBUS();
        List<NhaCungCapDTO> dsncc = new List<NhaCungCapDTO>();
        List<LoaiSanPhamDTO> dsl = new List<LoaiSanPhamDTO>();
        
        


        public frmSanPham()
        {
            InitializeComponent();

            dsl = lspbus.DSLSanPham();
            dsncc = nccbus.LayNhaCungCap();  
        }

        List<SanPhamDTO> lst = new SanPhamBUS().DanhSachSanPham();



        private void frmSanPham_Load(object sender, EventArgs e)
        {
            

            dssp = sanphambus.DanhSachSanPham();


            gctSanPham.DataSource = dssp;

            lueLSP.Properties.DataSource = dsl;
            lueLSP.Properties.DisplayMember = "TenLoaiSP";
            lueLSP.Properties.ValueMember = "MaLoaiSP";
            lueLSP.ItemIndex = 0;


            luencc.Properties.DataSource = dsncc;
            luencc.Properties.DisplayMember = "TenNCC";
            luencc.Properties.ValueMember = "MaNCC";
            luencc.ItemIndex = 0;

            gctSanPham.DataSource = sanphambus.DanhSachSanPham();

            txtMSP.Text = lst[0].MaSP;
            txtTSP.Text = lst[0].TenSP;
            lueLSP.Text = lst[0].MaLoaiSP;
            luencc.Text = lst[0].MaNCC;
            txtXX.Text = lst[0].XuatXu;
            txtGT.Text = (lst[0].GiaTien).ToString();
            ptbHinhSP.ImageLocation = lst[0].HinhAnh;



            btnS.Enabled = false;
            barButtonItem3.Enabled = false;
            btnX.Enabled = false;
            btnLM.Enabled = true;
            btnEC.Enabled = false;
            btnRP.Enabled = true;
        }

        private void btnTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsFindPanelVisible)
                gridView1.HideFindPanel();
            else
                gridView1.ShowFindPanel();
        }

        private void btnX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string masp = txtMSP.Text;
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
            {

            }
            else
            {
                if (sanphambus.XoaSanPham(masp) == true)
                    gctSanPham.DataSource = sanphambus.DanhSachSanPham();
            }
            btnS.Enabled = false;
            barButtonItem3.Enabled = false;
            btnX.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;

            txtTSP.Text = "";
            txtXX.Text = "";
            txtSL.Text = "";
            txtGT.Text = "";
            ptbHinhSP.ImageLocation = "";
            lueLSP.ItemIndex = 0;
            luencc.ItemIndex = 0;
        }

        private void btnLM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMSP.EditValue = sanphambus.TangSanPham();
            txtTSP.Text = "";
            txtXX.Text = "";
            txtGT.Text = "";
            txtSL.Text = "";
            ptbHinhSP.ImageLocation = "";

            luencc.ItemIndex = 0;
            lueLSP.ItemIndex = 0;

            btnS.Enabled = false;
            barButtonItem3.Enabled = true;
            btnX.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;



        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void btnS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMSP.Text == "" || txtTSP.Text == "" || txtXX.Text == "" || txtGT.Text == "")
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                sanphamdto.MaSP = txtMSP.Text;
                sanphamdto.TenSP = txtTSP.Text;
                sanphamdto.MaLoaiSP = lueLSP.EditValue.ToString();
                sanphamdto.XuatXu = txtXX.Text;
                sanphamdto.GiaTien = Convert.ToDouble(txtGT.Text);
                sanphamdto.HinhAnh = lblDuongDan.Text;
                sanphamdto.SoLuong = int.Parse(txtSL.Text);
                sanphamdto.MaNCC = luencc.EditValue.ToString();

                if (sanphambus.SuaSanPham(sanphamdto))
                {
                    XtraMessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    gctSanPham.DataSource = sanphambus.DanhSachSanPham();
                    txtTSP.Text = "";
                    txtXX.Text = "";
                    txtSL.Text = "";
                    txtGT.Text = "";
                    ptbHinhSP.ImageLocation = "";
                }
                else
                {
                    XtraMessageBox.Show("Sửa thất bại!", "Thông báo");
                }
            }

            btnS.Enabled = false;
            barButtonItem3.Enabled = false;
            btnX.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;
        }

        private void txtGT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMSP.Text == "" || txtTSP.Text == "" || txtXX.Text == "" || txtGT.Text == "")
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                sanphamdto.MaSP = txtMSP.Text;
                sanphamdto.TenSP = txtTSP.Text;
                sanphamdto.MaLoaiSP = lueLSP.EditValue.ToString();
                sanphamdto.XuatXu = txtXX.Text;
                sanphamdto.GiaTien = Convert.ToDouble(txtGT.Text);
                sanphamdto.HinhAnh = lblDuongDan.Text;
                sanphamdto.MaNCC = luencc.EditValue.ToString();

                if (sanphambus.ThemSanPham(sanphamdto))
                {
                    XtraMessageBox.Show("Thêm thành công!","Thông báo",MessageBoxButtons.OK);
                    txtMSP.Text = sanphambus.TangSanPham();
                    txtTSP.Text = "";
                    txtXX.Text = "";
                    txtSL.Text = "";
                    txtGT.Text = "";
                }
                else
                {
                    XtraMessageBox.Show("Thêm thât bại!");
                }
                gctSanPham.DataSource = sanphambus.DanhSachSanPham();
            }
            btnS.Enabled = false;
            barButtonItem3.Enabled = false;
            btnX.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;
        }
        private void txtGT_TextChanged(object sender, EventArgs e)
        {
            if (txtGT.Text == "0")
                txtGT.Text = "";
            else
            {
                try
                {
                    txtGT.Text = string.Format("{0:0,0}", double.Parse(txtGT.Text));
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnEX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ptbHinhSP_Click(object sender, EventArgs e)
        {
            if (ofdHinhAnh.ShowDialog() == DialogResult.OK)
            {            
                lblDuongDan.Text = ptbHinhSP.ImageLocation = ofdHinhAnh.FileName;
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
                CRSanPham sp = new CRSanPham();
                sp.Dock = DockStyle.Fill;
                sp.Show();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            txtMSP.Text = gridView1.GetRowCellValue(e.RowHandle, "MaSP").ToString();
            txtTSP.Text = gridView1.GetRowCellValue(e.RowHandle, "TenSP").ToString();
            txtXX.Text = gridView1.GetRowCellValue(e.RowHandle, "XuatXu").ToString();
            txtGT.Text = gridView1.GetRowCellValue(e.RowHandle, "GiaTien").ToString();
            txtSL.Text = gridView1.GetRowCellValue(e.RowHandle, "SoLuong").ToString();
            ptbHinhSP.ImageLocation = gridView1.GetRowCellValue(e.RowHandle, "HinhAnh").ToString();
            lblDuongDan.Text = gridView1.GetRowCellValue(e.RowHandle, "HinhAnh").ToString();

            btnS.Enabled = true;
            barButtonItem3.Enabled = false;
            btnX.Enabled = true;
            btnLM.Enabled = true;
            btnRP.Enabled = true;
            btnEC.Enabled = true;



            string ncc = gridView1.GetRowCellValue(e.RowHandle, "MaNCC").ToString();
            if (ncc == "Huỳnh Trấn Thành")
                luencc.ItemIndex = 0;
            else if (ncc == "Chí Tài")
                luencc.ItemIndex = 1;
            else if (ncc == "Việt Hương")
                luencc.ItemIndex = 2;
            else if (ncc == "Hoài Linh")
                luencc.ItemIndex = 3;
            else if (ncc == "Trường Giang")
                luencc.ItemIndex = 4;
            else if (ncc == "Nguyễn Thành Danh")
                luencc.ItemIndex = 5;
            else if (ncc == "Cao Nghĩa Tín")
                luencc.ItemIndex = 6;
            else if (ncc == "Trần Huỳnh Như")
                luencc.ItemIndex = 7;
            else if (ncc == "Huỳnh Trọng tin")
                luencc.ItemIndex = 8;
            else
                luencc.ItemIndex = 9;

            string loai = gridView1.GetRowCellValue(e.RowHandle, "MaLoaiSP").ToString();
            if (loai == "Mỹ Phẩm")
                lueLSP.ItemIndex = 0;
            else if (loai == "Sữa")
                lueLSP.ItemIndex = 1;
            else if (loai == "Nước")
                lueLSP.ItemIndex = 2;
            else if (loai == "Bánh")
                lueLSP.ItemIndex = 3;
            else if (loai == "Kẹo")
                lueLSP.ItemIndex = 4;
            else
                lueLSP.ItemIndex = 5;
        }
    }
}