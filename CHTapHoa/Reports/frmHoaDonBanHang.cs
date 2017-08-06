using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QLDTO;
using QLBUS;

namespace CHTapHoa
{
    public partial class frmHoaDonBanHang : Form
    {
        CTHDXuatBUS _cthdxBus = new CTHDXuatBUS();
        HoaDonXuatBUS _hdxBus = new HoaDonXuatBUS();
        KhachHangBUS _khBus = new KhachHangBUS();

        public string MaHD = string.Empty;

        public frmHoaDonBanHang()
        {
            InitializeComponent();
        }

        private void frmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\HoaDonBanHang.rpt");

            List<HoaDonXuatDTO> dsHDX = new List<HoaDonXuatDTO>();
            HoaDonXuatDTO hdx = _hdxBus.LayHDTheoMa(MaHD);

            dsHDX.Add(hdx);

            rp.SetDataSource(dsHDX);

            List<CTHDXuatDTO> dsSanPham = _cthdxBus.DanhSachChiTietHoaDonXuat(MaHD);

            rp.Subreports[0].SetDataSource(dsSanPham);

            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.Refresh();
        }
    }
}
