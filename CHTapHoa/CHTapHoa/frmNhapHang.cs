using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using QLBUS;
using QLDTO;
using DevExpress.XtraEditors;

namespace CHTapHoa
{
    public partial class frmNhapHang : Form
    {
        List<CTHDNhapDTO> lstchitiet = new List<CTHDNhapDTO>();
        List<SanPhamDTO> ls = new List<SanPhamDTO>();
      
        List<SanPhamDTO> lstsanpham = new List<SanPhamDTO>();
        List<SanPhamDTO> lstgiohang = new List<SanPhamDTO>();
        List<SanPhamDTO> lstSP = new List<SanPhamDTO>();

        SanPhamDTO sanphamdto = new SanPhamDTO();

        CTHDNhapDTO chitietdto = new CTHDNhapDTO();
        CTHDNhapBUS chitietbus = new CTHDNhapBUS();

        LoaiSanPhamBUS loaispbus = new LoaiSanPhamBUS();
        NhaCungCapBUS nccbus = new NhaCungCapBUS();
        HoaDonNhapBUS hdnbus = new HoaDonNhapBUS();
        SanPhamBUS sanphambus = new SanPhamBUS();


        public frmNhapHang()
        {

            InitializeComponent();
            
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            TangHD();
            TangMSP();
            HamThanhTien();


            gctSanPham.DataSource = sanphambus.DanhSachSanPham();

        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMSP.Text = gridView1.GetRowCellValue(e.RowHandle, "MaSP").ToString();
            txtTSP.Text = gridView1.GetRowCellValue(e.RowHandle, "TenSP").ToString();
            txtXX.Text = gridView1.GetRowCellValue(e.RowHandle, "XuatXu").ToString();
            txtGT.Text = gridView1.GetRowCellValue(e.RowHandle, "GiaTien").ToString();
            txtLSP.Text = gridView1.GetRowCellValue(e.RowHandle, "MaLoaiSP").ToString();
            txtNCC.Text = gridView1.GetRowCellValue(e.RowHandle, "MaNCC").ToString();
            ptbHinhSP.ImageLocation = gridView1.GetRowCellValue(e.RowHandle, "HinhAnh").ToString();
            lblDuongDan.Text = gridView1.GetRowCellValue(e.RowHandle, "HinhAnh").ToString();
            HamThanhTien();

            HamThanhTienA();
            
            btnH.Enabled = true;
            btnEX.Enabled = true;
            btnTK.Enabled = true;

            txtSL.Text = "";
           
        }

        private void HamThanhTienA()
        {
            if (txtGT.Text.Trim() != "")
            {
                double thanhtien = 0;

                double dongia = Convert.ToDouble(txtGT.Text);

                thanhtien = dongia;

                txtGT.Text = thanhtien.ToString();

                txtGT.Text = string.Format("{0:0,0}", thanhtien);

            }
            else
            {
                txtGT.Text = "";

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

        public void TangHD()
        {
            txtMHD.Text = hdnbus.TangHD();
        }
        
        public void TangMSP()
        {
            txtMSP.Text = sanphambus.TangSanPham();
        }

        private void ptbHinhSP_Click(object sender, EventArgs e)
        {
            if (ofdHinhAnh.ShowDialog() == DialogResult.OK)
            {
                lblDuongDan.Text = ptbHinhSP.ImageLocation = ofdHinhAnh.FileName;
            }
        }

        private void btnH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtGT.Text = "";
            txtSL.Text = "";
            txtXX.Text = "";
            txtTSP.Text = "";
            txtLSP.Text = "";
            txtNCC.Text = "";

            ptbHinhSP.ImageLocation = "";
            txtMSP.EditValue = sanphambus.TangSanPham();
            txtMHD.EditValue = hdnbus.TangHD();

            for (int i = 0; i < gridView2.RowCount; )
            {
                gridView2.DeleteRow(i);
            }
        }

        private void HamThanhTien()
        {
            if (txtGT.Text.Trim() != "" && txtSL.Text.Trim() != "")
            {
                double thanhtien = 0;
                double dongia = Convert.ToDouble(txtGT.Text);
                double soluong = Convert.ToDouble(txtSL.Text);
                thanhtien = soluong * dongia;
                lblThanhTien.Text = thanhtien.ToString();
                lblThanhTien.Text = string.Format("{0:0,0}", thanhtien);
            }
            else
            {
                lblThanhTien.Text = "0";
            }
        }


        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            HamThanhTien();
        }

        private void txtGT_TextChanged(object sender, EventArgs e)
        {
            HamThanhTien();
            
        }

        public double LayTongTien()
        {
            double tongtien = 0;
            int n = gridView2.RowCount;

            for (int i = 0; i < n; i++)
            {
                string tt = gridView2.GetRowCellValue(i, "ThanhTien").ToString();
                tongtien += double.Parse(tt);
            }
            return tongtien;
        }

        private void btnTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsFindPanelVisible)
                gridView1.HideFindPanel();
            else
                gridView1.ShowFindPanel();
        }


        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void GetDuLieu()
        {
            lstchitiet = new List<CTHDNhapDTO>();
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                CTHDNhapDTO ct = new CTHDNhapDTO();
                ct.MaCTHoaDonNhap = hdnbus.TangHD();
                ct.MaSP = gridView2.GetRowCellValue(i, "MaSP").ToString();
                ct.SoLuong = Convert.ToInt32(gridView2.GetRowCellValue(i, "SoLuong").ToString());
                ct.ThanhTien = Convert.ToDouble(gridView2.GetRowCellValue(i, "ThanhTien").ToString());
                ct.GiaNhap = Convert.ToInt32(gridView2.GetRowCellValue(i, "GiaTien").ToString());
                lstchitiet.Add(ct);
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSanPham sp = new frmSanPham();
            sp.Dock = DockStyle.Fill;
            sp.ShowDialog();

            gctSanPham.DataSource = sanphambus.DanhSachSanPham();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSL.Text == "" || txtSL.Text == "0")
            {
                MessageBox.Show("Chưa nhập số lượng cần nhập hoặc số lượng không được bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSL.Focus();
            }
            else
            {
                int tt = 0;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string masp = gridView2.GetRowCellValue(i, gridView2.Columns[0]).ToString();
                    if (masp == txtMSP.Text)
                    {
                        int slht = Convert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns[6]).ToString());
                        double ttht = Convert.ToDouble(gridView2.GetRowCellValue(i, gridView2.Columns[5]).ToString());
                        int slnew = slht + int.Parse(txtSL.Text);
                        double ttnew = ttht + float.Parse(lblThanhTien.Text);
                        gridView2.SetRowCellValue(i, gridView2.Columns[6], slnew);
                        gridView2.SetRowCellValue(i, gridView2.Columns[5], ttnew);
                        tt = 1;
                        break;
                    }
                }
                if (tt == 0)
                {
                    SanPhamDTO sp = new SanPhamDTO();
                    sp.MaSP = txtMSP.Text;
                    sp.TenSP = txtTSP.Text;
                    sp.SoLuong = Convert.ToDouble(txtSL.Text);
                    sp.MaLoaiSP = txtLSP.Text;
                    sp.GiaTien = Convert.ToDouble(txtGT.Text);
                    sp.MaNCC = txtNCC.Text;
                    sp.XuatXu = txtXX.Text;
                    sp.ThanhTien = float.Parse(lblThanhTien.Text);

                    ls.Add(sp);

                }
            }
            gctSPThem.DataSource = ls;
            gctSPThem.RefreshDataSource();

            lblTT.Text = string.Format("{0:0,00}", LayTongTien());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount != 0)
            {
                DialogResult dr;
                dr = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.No)
                {

                }
                else
                {
                    int vitri = this.gridView2.FocusedRowHandle;
                    double ttht = Convert.ToDouble(gridView2.GetRowCellValue(vitri, gridView2.Columns[5]).ToString());
                    gridView2.DeleteRow(vitri);
                    double tthq = double.Parse(lblTT.Text) - ttht;
                    lblTT.Text = tthq.ToString();
                    lblTT.Text = string.Format("{0:0,00}", LayTongTien());
                }
            }
            else
            {
                XtraMessageBox.Show("Giỏ hàng rỗng, vui lòng nhập hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            GetDuLieu();
            if (gridView2.RowCount > 0 || gridView2.RowCount != 0)
            {
                try
                {
                    double tien = 0;
                    foreach (CTHDNhapDTO ct in lstchitiet)
                    {
                        tien += ct.GiaNhap * ct.SoLuong;
                    }

                    HoaDonNhapDTO hdb = new HoaDonNhapDTO();
                    frmSanPham sp = new frmSanPham();
                    Form1 frm = (Form1)this.MdiParent;
                    hdb.MaHDN = hdnbus.TangHD();
                    hdb.MaNV = frm.NhanVienDN.MaNV;
                    hdb.NgayNhap = System.DateTime.Now;
                    hdb.TongTien = tien;

                    int mhd = hdnbus.ThemHoaDonNhap(hdb);

                    CTHDNhapBUS ctbus = new CTHDNhapBUS();

                    int kq = 0;
                    foreach (CTHDNhapDTO ct in lstchitiet)
                    {
                        ct.MaCTHoaDonNhap = hdb.MaHDN;
                        if (ctbus.ThemCTHoaDonNhap(ct))
                        {
                            kq++;
                        }
                        if (sanphambus.TimSP(ct.MaSP))
                        {
                            SanPhamDTO hh = new SanPhamDTO();
                            hh.MaSP = ct.MaSP;
                            hh.SoLuong = ct.SoLuong;
                            sanphambus.CongSL(hh);
                        }
                    }
                    if (kq == lstchitiet.Count)
                    {
                        XtraMessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK);
                        frmHoaDonNhapHang frm1 = new frmHoaDonNhapHang();
                        frm1.MaHDN = txtMHD.Text;
                        frm1.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("Thanh toán thất bại", "Thông báo");
                    }
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Bạn chưa nhập hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                gctSanPham.DataSource = sanphambus.DanhSachSanPham();

                for (int i = 0; i < gridView2.RowCount; )
                {
                    gridView2.DeleteRow(i);
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn hàng cần nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            lblThanhTien.Text = "";
            lblTT.Text = "";
            txtSL.Text = "";

            TangHD();
        }
    }
}
