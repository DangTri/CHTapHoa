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
    public partial class CRHoaDonNhanVien : Form
    {
        public string maNV = string.Empty;
        public CRHoaDonNhanVien()
        {
            InitializeComponent();
        }

        private void CRHoaDonNhanVien_Load(object sender, EventArgs e)
        {
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\HoaDonNhanVien.rpt");
            HoaDonXuatBUS _hdxBus = new HoaDonXuatBUS();
            List<HoaDonXuatDTO> lst = new List<HoaDonXuatDTO>();
            List<HoaDonXuatDTO> lshdxdto = _hdxBus.LayHDTheoMaNhanVien(maNV);       
            rp.SetDataSource(lshdxdto);
            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.RefreshReport();
        }

    }
}
