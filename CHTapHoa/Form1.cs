using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLDTO;
using DevExpress.XtraEditors;

namespace CHTapHoa
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public NhanVienDTO NhanVienDN = null;

        public Form1()
        {
            InitializeComponent();
        }

        private Form KiemTraTonTai(Type fType)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                {
                    return f;
                }
            }
            return null;
        }

        private void btnDSSP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmSanPham));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmSanPham sp = new frmSanPham();
                sp.MdiParent = this;
                sp.Dock = DockStyle.Fill;
                sp.Show();
            }
        }

        private void btnDSNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                Form frm = this.KiemTraTonTai(typeof(frmNhanVien));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    frmNhanVien nv = new frmNhanVien();
                    nv.MdiParent = this;
                    nv.Dock = DockStyle.Fill;
                    nv.Show();
                }
        }

        private void btnNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmNhaCungCap));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhaCungCap ncc = new frmNhaCungCap();
                ncc.MdiParent = this;
                ncc.Dock = DockStyle.Fill;
                ncc.Show();
            }
        }

        private void btnKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmKhachHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmKhachHang kh = new frmKhachHang();
                kh.MdiParent = this;
                kh.Dock = DockStyle.Fill;
                kh.Show();
            }
        }

        private void btnHD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmHoaDonNhap));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmHoaDonNhap hd = new frmHoaDonNhap();
                hd.MdiParent = this;
                hd.Dock = DockStyle.Fill;
                hd.Show();
            }
        }

        public void SetTrangThaiDangNhap(NhanVienDTO nv)
        {
            NhanVienDN = nv;
            if (NhanVienDN.MaLoaiNV != null)
            {
                btnDN.Enabled = true;
               

                if (NhanVienDN.MaLoaiNV == "QUẢN LÝ")
                {
                    lblXC.Visible = true;
                    ribbonControl1.Visible = true;
                    lblLNV.Visible = true;

                    Form frm = this.KiemTraTonTai(typeof(frmBanHang));
                    if (frm != null)
                    {
                        frm.Activate();
                    }
                    else
                    {
                        frmBanHang bh = new frmBanHang();
                        bh.MdiParent = this;
                        bh.Dock = DockStyle.Fill;
                        bh.Show();
                    }

                    lblXC.Text = "Xin chào: " + NhanVienDN.HoTenNV;
                    lblLNV.Text = NhanVienDN.MaLoaiNV;

                    btnDSSP.Enabled = true;
                    btnDSNV.Enabled = true;
                    btnNCC.Enabled = true;
                    btnKH.Enabled = true;
                    btnHDN.Enabled = true;
                    btnHDX.Enabled = true;
                    btnTK.Enabled = true;
                    btnIHD.Enabled = true;
                    btnDMK.Enabled = true;
                    btnBH.Enabled = true;
                    btnDX.Enabled = true;
                    btnNH.Enabled = true;
                    btnBCTK.Enabled = true;
                    btnDN.Enabled = false;

                    
                }
                else
                {
                    if (NhanVienDN.MaLoaiNV == "BÁN HÀNG")
                    {
                        ribbonControl1.Visible = true;
                        lblXC.Visible = true;
                        lblLNV.Visible = true;

                        Form frm = this.KiemTraTonTai(typeof(frmBanHang));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frmBanHang bh = new frmBanHang();
                            bh.MdiParent = this;
                            bh.Dock = DockStyle.Fill;
                            bh.Show();
                        }


                        lblXC.Text = "Xin chào: " + NhanVienDN.HoTenNV;
                        lblLNV.Text = NhanVienDN.MaLoaiNV;

                        btnDSSP.Enabled = false;
                        btnDSNV.Enabled = false;
                        btnNCC.Enabled = false;
                        btnKH.Enabled = false;
                        btnHDN.Enabled = false;
                        btnHDX.Enabled = false;
                        btnTK.Enabled = false;
                        btnIHD.Enabled = false;
                        btnDMK.Enabled = true;
                        btnBH.Enabled = true;
                        btnDX.Enabled = true;
                        btnNH.Enabled = true;
                        btnDN.Enabled = false;
                    }
                    else
                    {
                        lblXC.Visible = true;
                        ribbonControl1.Visible = true;
                        lblLNV.Visible = true;

                        Form frm = this.KiemTraTonTai(typeof(frmNhapHang));
                        if (frm != null)
                        {
                            frm.Activate();
                        }
                        else
                        {
                            frmNhapHang nh = new frmNhapHang();
                            nh.MdiParent = this;
                            nh.Dock = DockStyle.Fill;
                            nh.Show();
                        }


                        lblXC.Text = "Xin chào: " + NhanVienDN.HoTenNV;
                        lblLNV.Text = NhanVienDN.MaLoaiNV;

                        btnDSSP.Enabled = false;
                        btnDSNV.Enabled = false;
                        btnNCC.Enabled = false;
                        btnKH.Enabled = false;
                        btnHDN.Enabled = false;
                        btnHDX.Enabled = false;
                        btnTK.Enabled = false;
                        btnIHD.Enabled = false;
                        btnDMK.Enabled = true;
                        btnBH.Enabled = false;
                        btnDX.Enabled = true;
                        btnNH.Enabled = true;
                        btnDN.Enabled = false;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                ribbonControl1.Visible = true;

                frmDangNhap frmDangNhap = new frmDangNhap();
                frmDangNhap.MdiParent = this;
                frmDangNhap.Dock = DockStyle.Fill;
                frmDangNhap.Show();

                lblXC.Visible = false;
                lblLNV.Visible = false;

                btnDSSP.Enabled = false;
                btnDX.Enabled = false;
                btnHDX.Enabled = false;
                btnHDN.Enabled = false;
                btnKH.Enabled = false;
                btnNCC.Enabled = false;
                btnNH.Enabled = false;
                btnBH.Enabled = false;
                btnDSNV.Enabled = false;
                btnBCTK.Enabled = false;
                btnDMK.Enabled = false;
                btnIHD.Enabled = false;
                btnTK.Enabled = false;

            
        }

        

        private void btnDX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            SetTrangThaiDangNhap(NhanVienDN);
            frmDangNhap frmdangnhap = new frmDangNhap();
            frmdangnhap.MdiParent = this;
            frmdangnhap.WindowState = FormWindowState.Maximized;
            frmdangnhap.Show();

            ribbonControl1.Visible = true;

            

            lblXC.Visible = false;


            lblLNV.Visible = false;

            btnDSSP.Enabled = false;
            btnDX.Enabled = false;
            btnHDX.Enabled = false;
            btnHDN.Enabled = false;
            btnKH.Enabled = false;
            btnNCC.Enabled = false;
            btnNH.Enabled = false;
            btnBH.Enabled = false;
            btnDSNV.Enabled = false;
            btnDMK.Enabled = false;
            btnIHD.Enabled = false;
            btnTK.Enabled = false;
            btnDN.Enabled = true;
            
        }

        private void btnNH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmNhapHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmNhapHang nh = new frmNhapHang();
                nh.MdiParent = this;
                nh.Dock = DockStyle.Fill;
                nh.Show();
            }
        }

        private void btnBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmBanHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmBanHang bh = new frmBanHang();
                bh.MdiParent = this;
                bh.Dock = DockStyle.Fill;
                bh.Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmDangNhap));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmDangNhap dn = new frmDangNhap();
                dn.MdiParent = this;
                dn.Dock = DockStyle.Fill;
                dn.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnDMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmDoiMatKhau));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                
                frmDoiMatKhau dmk = new frmDoiMatKhau();
                dmk.MdiParent = this;
                dmk.Dock = DockStyle.Fill;
                dmk.Show();
            }
        }

        private void btnHDX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmHoaDonXuat));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {

                frmHoaDonXuat hdx = new frmHoaDonXuat();
                hdx.MdiParent = this;
                hdx.Dock = DockStyle.Fill;
                hdx.Show();
            }
        }

        private void btnBCTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmThongKeBaoCao));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {

                frmThongKeBaoCao tkbc = new frmThongKeBaoCao();
                tkbc.MdiParent = this;
                tkbc.Dock = DockStyle.Fill;
                tkbc.Show();
            }
        }
    }
}

