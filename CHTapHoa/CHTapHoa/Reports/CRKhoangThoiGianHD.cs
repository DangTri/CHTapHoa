using CrystalDecisions.CrystalReports.Engine;
using QLBUS;
using QLDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHTapHoa
{
    public partial class CRKhoangThoiGianHD : Form
    {
        public DateTime tungay, denngay;
        public CRKhoangThoiGianHD()
        {
            InitializeComponent();
        }

        private void CRKhoangThoiGianHD_Load(object sender, EventArgs e)
        {
            HoaDonXuatBUS _hdxBus = new HoaDonXuatBUS();
            List<HoaDonXuatDTO> lshdx = new List<HoaDonXuatDTO>();
            lshdx = _hdxBus.TimDanhSachHoaDon(tungay, denngay);
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\KhoangThoiGianHD.rpt");
            rp.SetDataSource(lshdx);
            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.Refresh();
        }
    }
}
