using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLDTO;
using QLBUS;

namespace CHTapHoa
{
    public partial class CRKhachHang : Form
    {
        public CRKhachHang()
        {
            InitializeComponent();
        }

        private void CRKhachHang_Load(object sender, EventArgs e)
        {
            KhachHangBUS khachhhangbus = new KhachHangBUS();
            List<KhachHangDTO> lskhdto = new List<KhachHangDTO>();
            lskhdto = khachhhangbus.DanhSachKhachHang();
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\DanhSachKhachHang.rpt");
            rp.SetDataSource(lskhdto);
            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
