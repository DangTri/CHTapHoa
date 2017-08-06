using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class frmTatCaHoaDon : Form
    {
        public frmTatCaHoaDon()
        {
            InitializeComponent();
        }
        

        private void frmHoaDonThang_Load(object sender, EventArgs e)
        {
            HoaDonXuatBUS _hdxBus = new HoaDonXuatBUS();
            List<HoaDonXuatDTO> lshdx = new List<HoaDonXuatDTO>();
            lshdx = _hdxBus.DanhSachHoaDonXuat();

            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\TatCaHoaDon.rpt");
            rp.SetDataSource(lshdx);
            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.Refresh();
        }
    }
}
