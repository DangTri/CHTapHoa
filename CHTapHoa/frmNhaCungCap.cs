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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace CHTapHoa
{
    public partial class frmNhaCungCap : Form
    {
        List<NhaCungCapDTO> dsncc = new List<NhaCungCapDTO>();
        NhaCungCapDTO nccdto = new NhaCungCapDTO();
        NhaCungCapBUS nccbus = new NhaCungCapBUS();

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        List<NhaCungCapDTO> lst = new NhaCungCapBUS().LayNhaCungCap();
        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            
            gctNCC.DataSource = nccbus.LayNhaCungCap();

            btnT.Enabled = false;
            btnX.Enabled = false;
            btnS.Enabled = false;
            btnLM.Enabled = true;
            btnEC.Enabled = false;

            txtMNCC.Text = lst[0].MaNCC;
            txtTNCC.Text = lst[0].TenNCC;
            txtDC.Text = lst[0].DiaChi;
            txtSDT.Text = lst[0].SDT;
            txtEM.Text = lst[0].Email;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMNCC.EditValue = nccbus.TangNhaCungCap();
            txtTNCC.Text = "";
            txtSDT.Text = "";
            txtEM.Text = "";
            txtDC.Text = "";

            btnT.Enabled = true;
            btnX.Enabled = false;
            btnS.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;      
        }

        private void btnT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMNCC.Text==""||txtTNCC.Text==""||txtDC.Text==""||txtSDT.Text==""||txtEM.Text=="")
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                nccdto.MaNCC = txtMNCC.Text;
                nccdto.TenNCC = txtTNCC.Text;
                nccdto.DiaChi = txtDC.Text;
                nccdto.SDT = txtSDT.Text;
                nccdto.Email = txtEM.Text;
                if (nccbus.ThemNhaCungCap(nccdto))
                {
                    XtraMessageBox.Show("Thêm thành công","Thông báo", MessageBoxButtons.OK);
                    gctNCC.DataSource = nccbus.LayNhaCungCap();
                    txtMNCC.Text = nccbus.TangNhaCungCap();

                    btnT.Enabled = false;
                    btnX.Enabled = false;
                    btnS.Enabled = false;
                    btnLM.Enabled = false;
                    btnEC.Enabled = false;

                    txtTNCC.Text = "";
                    txtSDT.Text = "";
                    txtDC.Text = "";
                    txtEM.Text = "";
                }
                else
                {
                    XtraMessageBox.Show("Thêm thất bại","Thông báo");
                }


            }
        }

        private void btnS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMNCC.Text == "" || txtTNCC.Text == "" || txtDC.Text == "" || txtSDT.Text == "" || txtEM.Text == "")
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                nccdto.MaNCC = txtMNCC.Text;
                nccdto.TenNCC = txtTNCC.Text;
                nccdto.DiaChi = txtDC.Text;
                nccdto.SDT = txtSDT.Text;
                nccdto.Email = txtEM.Text;
                if (nccbus.SuaNhaCungCap(nccdto))
                {
                    XtraMessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);

                    btnT.Enabled = true;
                    btnX.Enabled = false;
                    btnS.Enabled = false;
                    btnLM.Enabled = false;
                    btnEC.Enabled = false;

                    txtTNCC.Text = "";
                    txtSDT.Text = "";
                    txtDC.Text = "";
                    txtEM.Text = "";

                }
                else
                {
                    XtraMessageBox.Show("Sửa thất bại", "Thông báo");
                }
                gctNCC.DataSource = nccbus.LayNhaCungCap();
            }
            
        }

        private void btnX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mancc = txtMNCC.Text;
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
            {

            }
            else
            {
                if (nccbus.XoaNhaCungCap(mancc) == true)
                    gctNCC.DataSource = nccbus.LayNhaCungCap();
            }

            btnT.Enabled = false;
            btnX.Enabled = false;
            btnS.Enabled = false;
            btnLM.Enabled = false;
            btnEC.Enabled = false;

            txtTNCC.Text = "";
            txtSDT.Text = "";
            txtDC.Text = "";
            txtEM.Text = "";
        }

        private void btnTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsFindPanelVisible)
                gridView1.HideFindPanel();
            else
                gridView1.ShowFindPanel();
        }

        private void btnEX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
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
        private void btnRP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(frmSanPham));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                CRNhaCungCap nv = new CRNhaCungCap();
                nv.Dock = DockStyle.Fill;
                nv.Show();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            txtMNCC.Text = gridView1.GetRowCellValue(e.RowHandle, "MaNCC").ToString();
            txtTNCC.Text = gridView1.GetRowCellValue(e.RowHandle, "TenNCC").ToString();
            txtDC.Text = gridView1.GetRowCellValue(e.RowHandle, "DiaChi").ToString();
            txtSDT.Text = gridView1.GetRowCellValue(e.RowHandle, "SDT").ToString();
            txtEM.Text = gridView1.GetRowCellValue(e.RowHandle, "Email").ToString();

            btnT.Enabled = false;
            btnX.Enabled = true;
            btnS.Enabled = true;
            btnLM.Enabled = true;
            btnEC.Enabled = true;
        }

        
    }
}
