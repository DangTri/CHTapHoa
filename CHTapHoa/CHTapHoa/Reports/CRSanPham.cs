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
using System.Windows.Forms;

namespace CHTapHoa
{
    public partial class CRSanPham : Form
    {
        public CRSanPham()
        {
            InitializeComponent();
        }

        private void CRSanPham_Load(object sender, EventArgs e)
        {
            SanPhamBUS sanphambus = new SanPhamBUS();
            List<SanPhamDTO> lssanphamdto = new List<SanPhamDTO>();
            lssanphamdto = sanphambus.DanhSachSanPham();
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\DanhSachSanPham.rpt");
            rp.SetDataSource(lssanphamdto);
            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
