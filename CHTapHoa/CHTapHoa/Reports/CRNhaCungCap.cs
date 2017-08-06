using CrystalDecisions.CrystalReports.Engine;
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

namespace CHTapHoa
{
    public partial class CRNhaCungCap : Form
    {
        public CRNhaCungCap()
        {
            InitializeComponent();
        }

        private void CRNhaCungCap_Load(object sender, EventArgs e)
        {
            NhaCungCapBUS nhacungcapbus = new NhaCungCapBUS();
            List<NhaCungCapDTO> lsnccdto = new List<NhaCungCapDTO>();
            lsnccdto = nhacungcapbus.LayNhaCungCap();
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\DanhSachNhaCungCap.rpt");
            rp.SetDataSource(lsnccdto);
            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
