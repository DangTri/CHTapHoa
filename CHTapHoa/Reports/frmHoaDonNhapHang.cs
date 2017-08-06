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
using CrystalDecisions.CrystalReports.Engine;

namespace CHTapHoa
{
    public partial class frmHoaDonNhapHang : Form
    {
        HoaDonNhapBUS _hdnbus = new HoaDonNhapBUS();
        CTHDNhapBUS _cthdnbus = new CTHDNhapBUS();

        public string MaHDN = string.Empty;
        public frmHoaDonNhapHang()
        {
            InitializeComponent();
        }

        private void frmHoaDonNhapHang_Load(object sender, EventArgs e)
        {
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\HoaDonNhapHang.rpt");

            List<HoaDonNhapDTO> dsHDN = new List<HoaDonNhapDTO>();
            HoaDonNhapDTO hdn = _hdnbus.LayHDNhapTheoMa(MaHDN);

            dsHDN.Add(hdn);

            rp.SetDataSource(dsHDN);

            List<CTHDNhapDTO> dsSanPham = _cthdnbus.DanhSachChiTietHoaDonNhap(MaHDN);

            rp.Subreports[0].SetDataSource(dsSanPham);

            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.Refresh();
        }
    }
}
