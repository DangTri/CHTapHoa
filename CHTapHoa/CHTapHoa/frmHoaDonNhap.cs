using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBUS;
using QLDTO;

namespace CHTapHoa
{
    public partial class frmHoaDonNhap : Form
    {
        HoaDonNhapDTO hdndto = new HoaDonNhapDTO();
        HoaDonNhapBUS hdnbus = new HoaDonNhapBUS();


        CTHDNhapBUS cthdnbus = new CTHDNhapBUS();
        CTHDNhapDTO cthdndto = new CTHDNhapDTO();

        NhanVienBUS nvbus = new NhanVienBUS();
        SanPhamBUS spbus = new SanPhamBUS();

        NhaCungCapBUS nccbus = new NhaCungCapBUS();
        List<CTHDNhapDTO> cthd = new List<CTHDNhapDTO>();
        List<NhanVienDTO> lstnv = new List<NhanVienDTO>();
        List<CTHDNhapDTO> lstcthdn = new List<CTHDNhapDTO>();
        List<HoaDonNhapDTO> lsthdndto = new List<HoaDonNhapDTO>();

        string ngay = System.DateTime.Now.ToString("dd/MM/yyyy");

        public frmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            gctHDN.DataSource = hdnbus.DanhSachHoaDonNhap();

            CTHDNhapBUS chitiet = new CTHDNhapBUS();


            btnIHD.Enabled = false;

            txtMHDN.EditValue = hdnbus.TangHD();

            
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            
    
                gridControl2.DataSource = cthdnbus.DanhSachChiTietHoaDonNhap(gridView1.GetRowCellValue(e.RowHandle, "MaHDN").ToString());
                txtMHDN.Text = gridView1.GetRowCellValue(e.RowHandle, "MaHDN").ToString();
                txtTNV.Text = gridView1.GetRowCellValue(e.RowHandle, "MaNV").ToString();
                txtTT.Text = gridView1.GetRowCellValue(e.RowHandle, "TongTien").ToString();

                HamThanhTienA();

           

                txtMCTHDN.Text = gridView1.GetRowCellValue(e.RowHandle, "MaHDN").ToString();

                
                txtGN.Text = "";
                txtSL.Text = "";
                txtMSP.Text = "";
                btnIHD.Enabled = true;

 
        }

        private void HamThanhTienA()
        {
            if (txtTT.Text.Trim() != "")
            {
                int thanhtien = 0;
                
                int dongia = Convert.ToInt32(txtTT.Text);
                
                thanhtien = dongia;
                
                txtTT.Text = thanhtien.ToString();
                
                txtTT.Text = string.Format("{0:0,0}", thanhtien);
                
            }
            else
            {
                txtTT.Text = "";
                
            }
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            
                txtMHDN.Text = gridView2.GetRowCellValue(e.RowHandle, "MaCTHoaDonNhap").ToString();
                txtMSP.Text = gridView2.GetRowCellValue(e.RowHandle, "MaSP").ToString();
                txtGN.Text = gridView2.GetRowCellValue(e.RowHandle, "GiaNhap").ToString();
                txtSL.Text = gridView2.GetRowCellValue(e.RowHandle, "SoLuong").ToString();
                txtThanhTien.Text = gridView2.GetRowCellValue(e.RowHandle, "ThanhTien").ToString();
                
                HamThanhTienB();

                HamThanhTienC();
        }

        private void HamThanhTienB()
        {
            if (txtGN.Text.Trim() != "")
            {
                int thanhtien = 0;

                int dongia = Convert.ToInt32(txtGN.Text);

                thanhtien = dongia;

                txtGN.Text = thanhtien.ToString();

                txtGN.Text = string.Format("{0:0,0}", thanhtien);

            }
            else
            {
                txtGN.Text = "";

            }
        }

        private void HamThanhTienC()
        {
            if (txtThanhTien.Text.Trim() != "")
            {
                double thanhtien = 0;

                double dongia = Convert.ToDouble(txtThanhTien.Text);

                thanhtien = dongia;

                txtThanhTien.Text = thanhtien.ToString();

                txtThanhTien.Text = string.Format("{0:0,0}", thanhtien);

            }
            else
            {
                txtThanhTien.Text = "";

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTT.Text != "")
            {
                DialogResult dr;
                dr = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.No)
                {

                }
                else
                {
                    if (hdnbus.XoaHoaDonNhap(txtMHDN.Text))
                    {
                        MessageBox.Show("Xóa thành công!","Thông báo", MessageBoxButtons.OK);
                        gctHDN.DataSource = hdnbus.DanhSachHoaDonNhap();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }

                    txtMHDN.EditValue = hdnbus.TangHD();
                    txtTT.Text = "";
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            if (txtMSP.Text != ""||txtSL.Text !=""|| txtGN.Text!="")
            {
                DialogResult dr;
                dr = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.No)
                {

                }
                else
                {
                    if (cthdnbus.XoaCTHoaDonNhap(txtMCTHDN.Text))
                    {
                        MessageBox.Show("Xóa thành công!","Thông báo",MessageBoxButtons.OK);
                        gridControl2.DataSource = cthdnbus.DanhSachChiTietHoaDonNhap(txtMCTHDN.Text);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                    txtMCTHDN.Text = hdnbus.TangHD();
                    txtMSP.Text = "";
                    txtGN.Text = "";
                    txtSL.Text = "";
                    txtThanhTien.Text = "";
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn hóa đơn nhập và chọn dòng cần xóa", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsFindPanelVisible)
                gridView1.HideFindPanel();
            else
                gridView1.ShowFindPanel();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHoaDonNhapHang frm1 = new frmHoaDonNhapHang();
            frm1.MaHDN = txtMCTHDN.Text;
            frm1.ShowDialog();
        }

        private void btnLocHoaDon_Click(object sender, EventArgs e)
        {
            lsthdndto = hdnbus.TimDanhSachHoaDonNhap(dateTuNgay.Value, dateDenNgay.Value);
            gctHDN.DataSource = lsthdndto;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gctHDN.DataSource = hdnbus.DanhSachHoaDonNhap();
        }  
    }
}
