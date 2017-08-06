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
using QLBUS;
using QLDTO;

namespace CHTapHoa
{
    public partial class CRNhanVien : Form
    {
        public CRNhanVien()
        {
            InitializeComponent();
        }

        private void CRNhanVien_Load(object sender, EventArgs e)
        {
            NhanVienBUS nhanvienbus = new NhanVienBUS();
            List<NhanVienDTO> lsnhanvien = new List<NhanVienDTO>();
            lsnhanvien = nhanvienbus.DanhSachNhanVien();
            ReportDocument rp = new ReportDocument();
            rp.Load(@"C:\Users\Ron\Desktop\Tốt Nghiệp\CHTapHoa\CHTapHoa\Reports\DanhSachNhanVien.rpt");
            rp.SetDataSource(lsnhanvien);
            crystalReportViewer1.ReportSource = rp;
            this.crystalReportViewer1.Show();
            this.crystalReportViewer1.RefreshReport();
        }

    }
}
