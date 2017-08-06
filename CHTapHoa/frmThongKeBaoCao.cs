using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBUS;
using QLDTO;

namespace CHTapHoa
{
    public partial class frmThongKeBaoCao : Form
    {
        public frmThongKeBaoCao()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmThongKeBaoCao_Load(object sender, EventArgs e)
        {
            List<NhanVienDTO> lsnv = new List<NhanVienDTO>();
            NhanVienBUS nvbus = new NhanVienBUS();
            lsnv = nvbus.DanhSachNhanVien();
            cbonhanvien.DataSource = lsnv;
            cbonhanvien.DisplayMember = "TenNV";
            cbonhanvien.ValueMember = "MaNV";

        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            if (radSPSapHet.Checked)
            {
                CRSanPhamHetHang frmHetHang = new CRSanPhamHetHang();
                frmHetHang.ShowDialog();
            }
            else if (radTatCaHoaDon.Checked)
            {
                frmTatCaHoaDon frmtatca = new frmTatCaHoaDon();
                frmtatca.ShowDialog();
            }
            else if (radSPBanChay.Checked)
            {
                CRSanPhamBanChay frmbanchay = new CRSanPhamBanChay();
                frmbanchay.ShowDialog();
            }
            else if (radTheoNhanVien.Checked)
            {
                CRHoaDonNhanVien frm111 = new CRHoaDonNhanVien();
                frm111.maNV = cbonhanvien.Text;
                frm111.ShowDialog();
            }
            else if (radkhoangthoigian.Checked)
            {
                CRKhoangThoiGianHD frmm = new CRKhoangThoiGianHD();
                frmm.tungay = datetungay.Value;
                frmm.denngay = datedenngay.Value;
                frmm.ShowDialog();
            }
        }
    }
}
