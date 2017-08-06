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
    public partial class CRSanPhamHetHang : Form
    {
        public CRSanPhamHetHang()
        {
            InitializeComponent();
        }

        private void CRSanPhamHetHang_Load(object sender, EventArgs e)
        {
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPhamDTO> lssanphamdto = new List<SanPhamDTO>();
            lssanphamdto = sanphambus.DanhSachSanPhamHetHang();
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\SanPhamHetHang.rpt");
            rp.SetDataSource(lssanphamdto);
            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
