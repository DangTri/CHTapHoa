namespace CHTapHoa
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTK = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnDN = new DevExpress.XtraEditors.SimpleButton();
            this.cbbTTK = new System.Windows.Forms.ComboBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnHienThi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTK
            // 
            this.lblTK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTK.Appearance.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTK.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTK.Appearance.Options.UseFont = true;
            this.lblTK.Appearance.Options.UseForeColor = true;
            this.lblTK.Location = new System.Drawing.Point(235, 161);
            this.lblTK.Name = "lblTK";
            this.lblTK.Size = new System.Drawing.Size(131, 25);
            this.lblTK.TabIndex = 2;
            this.lblTK.Text = "Tên tài khoản";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(235, 214);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 25);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // btnDN
            // 
            this.btnDN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDN.Appearance.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDN.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDN.Appearance.Options.UseFont = true;
            this.btnDN.Appearance.Options.UseForeColor = true;
            this.btnDN.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnDN.Location = new System.Drawing.Point(384, 259);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(111, 33);
            this.btnDN.TabIndex = 3;
            this.btnDN.Text = "Đăng nhập";
            this.btnDN.Click += new System.EventHandler(this.btnDN_Click);
            // 
            // cbbTTK
            // 
            this.cbbTTK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbTTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTTK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTTK.FormattingEnabled = true;
            this.cbbTTK.Location = new System.Drawing.Point(391, 158);
            this.cbbTTK.Name = "cbbTTK";
            this.cbbTTK.Size = new System.Drawing.Size(228, 29);
            this.cbbTTK.TabIndex = 0;
            // 
            // txtMK
            // 
            this.txtMK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK.Location = new System.Drawing.Point(390, 212);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(228, 29);
            this.txtMK.TabIndex = 1;
            this.txtMK.Text = "123456";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Appearance.Options.UseForeColor = true;
            this.btnHuy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnHuy.Location = new System.Drawing.Point(502, 259);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(111, 33);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::CHTapHoa.Properties.Resources.secrecy_icon1;
            this.pictureEdit1.Location = new System.Drawing.Point(104, 154);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(125, 96);
            this.pictureEdit1.TabIndex = 8;
            // 
            // btnHienThi
            // 
            this.btnHienThi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHienThi.Image = global::CHTapHoa.Properties.Resources._64875;
            this.btnHienThi.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnHienThi.ImageUri.Uri = "Show;Office2013";
            this.btnHienThi.Location = new System.Drawing.Point(643, 212);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(42, 20);
            this.btnHienThi.TabIndex = 2;
            this.btnHienThi.ToolTip = "Hiển thị mật khẩu";
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = global::CHTapHoa.Properties.Resources.hinh_nen_7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(855, 453);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.cbbTTK);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblTK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangNhap";
            this.Text = "Đăng Nhập Hệ Thống";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTK;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDN;
        private System.Windows.Forms.ComboBox cbbTTK;
        private System.Windows.Forms.TextBox txtMK;
        private DevExpress.XtraEditors.SimpleButton btnHienThi;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton btnHuy;

    }
}