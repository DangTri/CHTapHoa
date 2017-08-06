using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLDTO;
using QLBUS;
using DevExpress.XtraGrid.Views.Grid;

namespace CHTapHoa
{
    public partial class frmHoaDonXuat : Form
    {
        HoaDonXuatBUS hdxbus = new HoaDonXuatBUS();
        CTHDXuatBUS cthdxbus = new CTHDXuatBUS();
        List<HoaDonXuatDTO> lsthdxdto = new List<HoaDonXuatDTO>();

        public frmHoaDonXuat()
        {
            InitializeComponent();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmHoaDonXuat_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = hdxbus.DanhSachHoaDonXuat();

            txtMHDX.EditValue = hdxbus.TangHD();
            bthIHD.Enabled = false;

            CTHDXuatBUS chitiet = new CTHDXuatBUS();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                gridControl2.DataSource = cthdxbus.DanhSachChiTietHoaDonXuat(gridView1.GetRowCellValue(e.RowHandle, "MaHDX").ToString());
                txtMHDX.Text = gridView1.GetRowCellValue(e.RowHandle, "MaHDX").ToString();
                txtMKH.Text = gridView1.GetRowCellValue(e.RowHandle, "MaKH").ToString();
                txtMNV.Text = gridView1.GetRowCellValue(e.RowHandle, "MaNV").ToString();
                txtTT.Text = gridView1.GetRowCellValue(e.RowHandle, "TongTien").ToString();

                txtMCTHDX.Text = gridView1.GetRowCellValue(e.RowHandle, "MaHDX").ToString();

                HamThanhTienA();

                txtThanhTien.Text = "";
                txtSL.Text = "";
                txtMSP.Text = "";
                txtGB.Text = "";
                bthIHD.Enabled = true;

            }
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
            txtMCTHDX.Text = gridView2.GetRowCellValue(e.RowHandle, "MaCTHoaDonXuat").ToString();
            txtGB.Text = gridView2.GetRowCellValue(e.RowHandle, "GiaBan").ToString();
            txtMSP.Text = gridView2.GetRowCellValue(e.RowHandle, "MaSP").ToString();
            txtSL.Text = gridView2.GetRowCellValue(e.RowHandle, "SoLuong").ToString();
            txtThanhTien.Text = gridView2.GetRowCellValue(e.RowHandle, "ThanhTien").ToString();

            HamThanhTienB();

            HamThanhTienC();
        }

        private void HamThanhTienB()
        {
            if (txtGB.Text.Trim() != "")
            {
                int thanhtien = 0;

                int dongia = Convert.ToInt32(txtGB.Text);

                thanhtien = dongia;

                txtGB.Text = thanhtien.ToString();

                txtGB.Text = string.Format("{0:0,0}", thanhtien);

            }
            else
            {
                txtGB.Text = "";

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

        private void btnX_Click(object sender, EventArgs e)
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
                    if (hdxbus.XoaHoaDonXuat(txtMHDX.Text))
                    {
                        MessageBox.Show("Xóa thành công!","Thông báo", MessageBoxButtons.OK);
                        gridControl1.DataSource = hdxbus.DanhSachHoaDonXuat();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }

                   txtMHDX.EditValue = hdxbus.TangHD();
                   txtTT.Text = "";
                    txtMNV.Text = "";
                    txtMKH.Text = "";
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
           }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMSP.Text != "" || txtSL.Text != "" || txtGB.Text != "")
            {
                DialogResult dr;
                dr = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.No)
                {

                }
                else
                {
                    if (cthdxbus.XoaCTHoaDonNhap(txtMCTHDX.Text))
                    {
                        MessageBox.Show("Xóa thành công!","Thông báo",MessageBoxButtons.OK);
                        gridControl2.DataSource = cthdxbus.DanhSachChiTietHoaDonXuat(txtMCTHDX.Text);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                    txtMCTHDX.EditValue = hdxbus.TangHD();
                    txtMSP.Text = "";
                    txtSL.Text = "";
                    txtTT.Text = "";
                    txtGB.Text = "";
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHoaDonBanHang frm1 = new frmHoaDonBanHang();
            frm1.MaHD = txtMCTHDX.Text;
            frm1.ShowDialog();
        }

        private void btnXemThoiGian_Click(object sender, EventArgs e)
        {
            lsthdxdto = hdxbus.TimDanhSachHoaDon(TuNgay.Value, DenNgay.Value);
            gridControl1.DataSource = lsthdxdto;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = hdxbus.DanhSachHoaDonXuat();
        }
    }
}
