namespace CHTapHoa
{
    partial class frmThongKeBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKeBaoCao));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbonhanvien = new System.Windows.Forms.ComboBox();
            this.radkhoangthoigian = new System.Windows.Forms.RadioButton();
            this.datedenngay = new System.Windows.Forms.DateTimePicker();
            this.datetungay = new System.Windows.Forms.DateTimePicker();
            this.radTatCaHoaDon = new System.Windows.Forms.RadioButton();
            this.btnInBaoCao = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radTheoNhanVien = new System.Windows.Forms.RadioButton();
            this.radSPBanChay = new System.Windows.Forms.RadioButton();
            this.radSPSapHet = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.ActAsDropDown = true;
            this.barButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem1.Caption = "Exit";
            this.barButtonItem1.DropDownControl = this.popupMenu1;
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.ImageUri.Uri = "Cancel;Size32x32";
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Làm Mới";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1036, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 461);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1036, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 421);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1036, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 421);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.cbonhanvien);
            this.groupControl1.Controls.Add(this.radkhoangthoigian);
            this.groupControl1.Controls.Add(this.datedenngay);
            this.groupControl1.Controls.Add(this.datetungay);
            this.groupControl1.Controls.Add(this.radTatCaHoaDon);
            this.groupControl1.Controls.Add(this.btnInBaoCao);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.radTheoNhanVien);
            this.groupControl1.Controls.Add(this.radSPBanChay);
            this.groupControl1.Controls.Add(this.radSPSapHet);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1036, 421);
            this.groupControl1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(689, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(560, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Từ";
            // 
            // cbonhanvien
            // 
            this.cbonhanvien.FormattingEnabled = true;
            this.cbonhanvien.Location = new System.Drawing.Point(787, 202);
            this.cbonhanvien.Name = "cbonhanvien";
            this.cbonhanvien.Size = new System.Drawing.Size(121, 21);
            this.cbonhanvien.TabIndex = 12;
            // 
            // radkhoangthoigian
            // 
            this.radkhoangthoigian.AutoSize = true;
            this.radkhoangthoigian.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radkhoangthoigian.Location = new System.Drawing.Point(425, 256);
            this.radkhoangthoigian.Name = "radkhoangthoigian";
            this.radkhoangthoigian.Size = new System.Drawing.Size(136, 21);
            this.radkhoangthoigian.TabIndex = 11;
            this.radkhoangthoigian.TabStop = true;
            this.radkhoangthoigian.Text = "Thời gian hóa đơn";
            this.radkhoangthoigian.UseVisualStyleBackColor = true;
            // 
            // datedenngay
            // 
            this.datedenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datedenngay.Location = new System.Drawing.Point(722, 255);
            this.datedenngay.Name = "datedenngay";
            this.datedenngay.Size = new System.Drawing.Size(108, 21);
            this.datedenngay.TabIndex = 10;
            // 
            // datetungay
            // 
            this.datetungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetungay.Location = new System.Drawing.Point(588, 256);
            this.datetungay.Name = "datetungay";
            this.datetungay.Size = new System.Drawing.Size(97, 21);
            this.datetungay.TabIndex = 9;
            // 
            // radTatCaHoaDon
            // 
            this.radTatCaHoaDon.AutoSize = true;
            this.radTatCaHoaDon.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radTatCaHoaDon.Location = new System.Drawing.Point(644, 152);
            this.radTatCaHoaDon.Name = "radTatCaHoaDon";
            this.radTatCaHoaDon.Size = new System.Drawing.Size(151, 21);
            this.radTatCaHoaDon.TabIndex = 8;
            this.radTatCaHoaDon.TabStop = true;
            this.radTatCaHoaDon.Text = "Tất Cả Hóa Đơn Bán";
            this.radTatCaHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Location = new System.Drawing.Point(551, 308);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(149, 34);
            this.btnInBaoCao.TabIndex = 6;
            this.btnInBaoCao.Text = "In Báo Cáo";
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 40F);
            this.label1.Location = new System.Drawing.Point(468, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 61);
            this.label1.TabIndex = 4;
            this.label1.Text = "THỐNG KÊ";
            // 
            // radTheoNhanVien
            // 
            this.radTheoNhanVien.AutoSize = true;
            this.radTheoNhanVien.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radTheoNhanVien.Location = new System.Drawing.Point(644, 202);
            this.radTheoNhanVien.Name = "radTheoNhanVien";
            this.radTheoNhanVien.Size = new System.Drawing.Size(145, 21);
            this.radTheoNhanVien.TabIndex = 2;
            this.radTheoNhanVien.TabStop = true;
            this.radTheoNhanVien.Text = "Hóa Đơn Nhân Viên";
            this.radTheoNhanVien.UseVisualStyleBackColor = true;
            this.radTheoNhanVien.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radSPBanChay
            // 
            this.radSPBanChay.AutoSize = true;
            this.radSPBanChay.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radSPBanChay.Location = new System.Drawing.Point(425, 152);
            this.radSPBanChay.Name = "radSPBanChay";
            this.radSPBanChay.Size = new System.Drawing.Size(199, 21);
            this.radSPBanChay.TabIndex = 1;
            this.radSPBanChay.TabStop = true;
            this.radSPBanChay.Text = "Top 10 Sản Phẩm Bán Chạy";
            this.radSPBanChay.UseVisualStyleBackColor = true;
            // 
            // radSPSapHet
            // 
            this.radSPSapHet.AutoSize = true;
            this.radSPSapHet.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radSPSapHet.Location = new System.Drawing.Point(425, 202);
            this.radSPSapHet.Name = "radSPSapHet";
            this.radSPSapHet.Size = new System.Drawing.Size(144, 21);
            this.radSPSapHet.TabIndex = 0;
            this.radSPSapHet.TabStop = true;
            this.radSPSapHet.Text = "Sản Phẩm Sắp Hết ";
            this.radSPSapHet.UseVisualStyleBackColor = true;
            // 
            // frmThongKeBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 484);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKeBaoCao";
            this.Text = "Thống Kê Báo Cáo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKeBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radTheoNhanVien;
        private System.Windows.Forms.RadioButton radSPBanChay;
        private System.Windows.Forms.RadioButton radSPSapHet;
        private System.Windows.Forms.RadioButton radTatCaHoaDon;
        private DevExpress.XtraEditors.SimpleButton btnInBaoCao;
        private System.Windows.Forms.RadioButton radkhoangthoigian;
        private System.Windows.Forms.DateTimePicker datedenngay;
        private System.Windows.Forms.DateTimePicker datetungay;
        private System.Windows.Forms.ComboBox cbonhanvien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}