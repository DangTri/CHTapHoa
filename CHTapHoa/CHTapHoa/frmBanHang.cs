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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CHTapHoa
{
    public partial class frmBanHang : Form
    {
        List<SanPhamDTO> lstSanPham = new List<SanPhamDTO>();
        List<SanPhamDTO> lstSP = new List<SanPhamDTO>();
        List<CTHDXuatDTO> cthdxDTO = new List<CTHDXuatDTO>();
        List<SanPhamDTO> lstgiohang = new List<SanPhamDTO>();
        List<SanPhamDTO> lsttam = new List<SanPhamDTO>();

        SanPhamBUS sanphambus = new SanPhamBUS();
        NhanVienBUS nhanvienbus = new NhanVienBUS();
        HoaDonXuatBUS hdxbus = new HoaDonXuatBUS();
        CTHDXuatBUS cthdxbus = new CTHDXuatBUS();
        KhachHangBUS khbus = new KhachHangBUS();

        HoaDonXuatDTO hdxdto = new HoaDonXuatDTO();


        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            HamTongtien();

            lstSanPham = sanphambus.DanhSachSanPham();
            gctSP.DataSource = sanphambus.DanhSachSanPham();

            List<KhachHangDTO> lstkh = new List<KhachHangDTO>();
            lstkh = khbus.DanhSachKhachHang();
            lueKH.Properties.DataSource = lstkh;
            lueKH.Properties.DisplayMember = "TenKH";
            lueKH.Properties.ValueMember = "MaKH";
            lueKH.ItemIndex = 0;

            TangHD();

            btnLM.Enabled = false;
        }

        public void TangHD()
        {
            txtMHD.Text = hdxbus.TangHD();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            lblMSP.Text = gridView1.GetRowCellValue(e.RowHandle, "MaSP").ToString();
            lblTen.Text = gridView1.GetRowCellValue(e.RowHandle, "TenSP").ToString();
            lblGT.Text = gridView1.GetRowCellValue(e.RowHandle, "GiaTien").ToString();
            lblSLT.Text = gridView1.GetRowCellValue(e.RowHandle, "SoLuong").ToString();
            ptbHinhAnh.ImageLocation = gridView1.GetRowCellValue(e.RowHandle, "HinhAnh").ToString();
            lblDuongDan.Text = gridView1.GetRowCellValue(e.RowHandle, "HinhAnh").ToString();

            HamTongtien();
            HamThanhTienA();


            btnLM.Enabled = true;

            txtSL.Text = "";
        }

        private void HamThanhTienA()
        {
            if (lblGT.Text.Trim() != "")
            {
                double thanhtien = 0;

                double dongia = Convert.ToInt32(lblGT.Text);

                thanhtien = dongia;

                lblGT.Text = thanhtien.ToString();

                lblGT.Text = string.Format("{0:0,0}", thanhtien);

            }
            else
            {
                lblGT.Text = "";

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

        private void btnLM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lblTen.Text = "";
            lblGT.Text = "";
            lblSLT.Text = "";
            txtSL.Text = "";
            lblMSP.Text = "";
            lblThanhTien.Text = "";
            lblTongTien.Text = "";
            ptbHinhAnh.ImageLocation = "";
            lueKH.Enabled = true;

            for (int i = 0; i < gridView2.RowCount; )
            {
                gridView2.DeleteRow(i);
            }
            

            btnLM.Enabled = false;
        }

        private void btnTKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsFindPanelVisible)
                gridView1.HideFindPanel();
            else
                gridView1.ShowFindPanel();
        }

        private void ptbHinhAnh_Click(object sender, EventArgs e)
        {
            if (ofdHinhAnh.ShowDialog() == DialogResult.OK)
            {
                lblDuongDan.Text = ptbHinhAnh.ImageLocation = ofdHinhAnh.FileName;
            }
        }

        private void HamTongtien()
        {
            if (lblGT.Text.Trim() != "" && txtSL.Text.Trim() != "")
            {
                double tongtien = 0;
                double dongia = Convert.ToDouble(lblGT.Text);
                double soluong = Convert.ToDouble(txtSL.Text);
                tongtien = soluong * dongia;
                lblTongTien.Text = tongtien.ToString();
                lblTongTien.Text = string.Format("{0:0,0}", tongtien);
            }
            else
            {
                lblTongTien.Text = "0";
            }
        }

        private void lblGT_TextChanged(object sender, EventArgs e)
        {
            HamTongtien();
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            HamTongtien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSL.Text == "" || lblSLT.Text == "0" || txtSL.Text == "0")
                {
                    MessageBox.Show("Chưa nhập số lượng cần mua hoặc số lượng không được bằng 0", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtSL.Focus();
                }
            else
            {
            int slthem = int.Parse(txtSL.Text);
            string maht = lblMSP.Text;
            int slkt = 0;
            for (int i = 0; i < gridView2.RowCount;i++ )
            {
                string maI = gridView2.GetRowCellValue(i, gridView2.Columns[0]).ToString();
                if(maI==maht)
                {
                    slkt = slthem + Convert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns[3]));
                    break;
                }
            }
            if (int.Parse(txtSL.Text) > int.Parse(lblSLT.Text))
            {
                MessageBox.Show("Số lượng mua không được lớn hơn số lượng tồn kho!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (slkt > int.Parse(lblSLT.Text))
                {
                    XtraMessageBox.Show("Số lượng không đủ!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                else
                {
                    int tt = 0;

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        string masp = gridView2.GetRowCellValue(i, gridView2.Columns[0]).ToString();
                        if (masp == lblMSP.Text)
                        {

                            int slht = Convert.ToInt32(gridView2.GetRowCellValue(i, gridView2.Columns[3]).ToString());
                            double ttht = Convert.ToDouble(gridView2.GetRowCellValue(i, gridView2.Columns[4]).ToString());

                            int slnew = slht + int.Parse(txtSL.Text);
                            double ttnew = ttht + float.Parse(lblTongTien.Text);

                            gridView2.SetRowCellValue(i, gridView2.Columns[3], slnew);
                            gridView2.SetRowCellValue(i, gridView2.Columns[4], ttnew);

                            tt = 1;
                            break;
                        }
                    }
                    if (tt == 0)
                    {

                        SanPhamDTO sp = new SanPhamDTO();
                        sp.TenSP = lblTen.Text;
                        sp.MaSP = lblMSP.Text;
                        sp.SoLuong = Convert.ToDouble(txtSL.Text);
                        sp.GiaTien = Convert.ToDouble(lblGT.Text);
                        sp.ThanhTien = float.Parse(lblTongTien.Text);


                        lstSP.Add(sp);

                    }
                    gridControl2.DataSource = lstSP;
                    gridControl2.RefreshDataSource();

                    lblThanhTien.Text = string.Format("{0:0,00}", LayTongTien());
                }
            }
            }
            lblTongTien.Text = "";
            txtSL.Text = "";
            lueKH.Enabled = false;
            btnT.Enabled = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
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
                    double ttht = Convert.ToDouble(gridView2.GetRowCellValue(vitri, gridView2.Columns[4]).ToString());
                    gridView2.DeleteRow(vitri);
                    double tthq = double.Parse(lblThanhTien.Text) - ttht;
                    lblThanhTien.Text = tthq.ToString();
                    lblThanhTien.Text = string.Format("{0:0,00}", LayTongTien());

                }
            }
            else
            {
                XtraMessageBox.Show("Giỏ hàng rỗng, vui lòng mua hàng", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        public SanPhamDTO KiemTraTonTai(string masp)
        {
            for(int i=0; i< lstgiohang.Count;i++)
            {
                if (lstgiohang[i].MaSP == masp)
                    return lstgiohang[i];
            }
            return null;
        }

        public double LayTongTien()
        {
            double tongtien = 0;
            int n = gridView2.RowCount;

            for(int i=0;i<n;i++)
            {
                string tt = gridView2.GetRowCellValue(i, "ThanhTien").ToString();
                tongtien += double.Parse(tt);
            }
            return tongtien;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           
            GetDuLieu();
            if(gridView2.RowCount > 0 || gridView2.RowCount!=0)
            {
                try
                {
                    int tien = 0;
                    foreach(CTHDXuatDTO ct in cthdxDTO)
                    {
                        tien += ct.GiaBan * ct.SoLuong;
                    }

                    HoaDonXuatDTO hdb = new HoaDonXuatDTO();
                    frmSanPham sp = new frmSanPham();
                    Form1 frm = (Form1)this.MdiParent;
                    hdb.MaHDX = hdxbus.TangHD();
                    hdb.MaNV = frm.NhanVienDN.MaNV;
                    hdb.MaKH = lueKH.EditValue.ToString();
                    hdb.NgayXuat = System.DateTime.Now;
                    hdb.TongTien=tien;

                    int mhd = hdxbus.themHoaDon(hdb);

                    CTHDXuatBUS ctbus = new CTHDXuatBUS();

                    int kq = 0;
                    foreach(CTHDXuatDTO ct in cthdxDTO)
                    {
                        ct.MaCTHoaDonXuat = hdb.MaHDX;
                        if(ctbus.ThemCTHoaDonXuat(ct))
                        {
                            kq++;
                        }
                        if(sanphambus.TimSP(ct.MaSP))
                        {
                            SanPhamDTO hh = new SanPhamDTO();
                            hh.MaSP = ct.MaSP;
                            hh.SoLuong = ct.SoLuong;
                            sanphambus.TruSL(hh);
                        }
                    }
                    if(kq==cthdxDTO.Count)
                    {
                        XtraMessageBox.Show("Thanh toán thành công", "Thông báo",MessageBoxButtons.OK);
                        frmHoaDonBanHang frm1 = new frmHoaDonBanHang();
                        frm1.MaHD = txtMHD.Text;
                        frm1.ShowDialog();
                        txtMHD.Text = hdxbus.TangHD();
                    }
                    else
                    {
                        XtraMessageBox.Show("Thanh toán thất bại", "Thông báo");
                    }
                }
                catch(Exception)
                {
                    XtraMessageBox.Show("Bạn chưa mua hàng", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    
                }
                gctSP.DataSource = sanphambus.DanhSachSanPham();

                for(int i=0; i< gridView2.RowCount;)
                {
                    gridView2.DeleteRow(i);
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa mua hàng", "Thông báo");
            }
            txtSL.Text = "";
            lblThanhTien.Text = "";
            lblTongTien.Text = "";
            lueKH.Enabled = true;
            btnT.Enabled = true;

        }

        private void GetDuLieu()
        {
            cthdxDTO = new List<CTHDXuatDTO>();
            for(int i=0;i<gridView2.RowCount;i++)
            {
                CTHDXuatDTO ct = new CTHDXuatDTO();
                ct.MaCTHoaDonXuat = hdxbus.TangHD();
                ct.MaSP = gridView2.GetRowCellValue(i, "MaSP").ToString();
                ct.SoLuong =Convert.ToInt32(gridView2.GetRowCellValue(i, "SoLuong").ToString());
                ct.ThanhTien = Convert.ToDouble(gridView2.GetRowCellValue(i, "ThanhTien").ToString());
                ct.GiaBan=Convert.ToInt32(gridView2.GetRowCellValue(i, "GiaTien").ToString());
                cthdxDTO.Add(ct);
            }
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.Dock = DockStyle.Fill;
            kh.ShowDialog();

            List<KhachHangDTO> lstkh = new List<KhachHangDTO>();
            lstkh = khbus.DanhSachKhachHang();
            lueKH.Properties.DataSource = lstkh;
        }
    }
}
