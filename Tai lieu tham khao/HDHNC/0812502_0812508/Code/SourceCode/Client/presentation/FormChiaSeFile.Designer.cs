namespace presentation
{
    partial class FormChiaSeFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChiaSeFile));
            this.btnTim = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.BangFile = new System.Windows.Forms.DataGridView();
            this.C_TenFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTinhTrangUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTinhTrangDownload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTenFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDongKetNoi = new System.Windows.Forms.Button();
            this.btnTrayIcon = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.BangFile)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(289, 14);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(156, 23);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(289, 46);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(370, 46);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // BangFile
            // 
            this.BangFile.AllowUserToAddRows = false;
            this.BangFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BangFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_TenFile,
            this.C_User,
            this.cTinhTrangUser,
            this.cTinhTrangDownload});
            this.BangFile.Location = new System.Drawing.Point(31, 75);
            this.BangFile.Name = "BangFile";
            this.BangFile.RowHeadersVisible = false;
            this.BangFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BangFile.Size = new System.Drawing.Size(414, 184);
            this.BangFile.TabIndex = 4;
            // 
            // C_TenFile
            // 
            this.C_TenFile.HeaderText = "TenFile";
            this.C_TenFile.Name = "C_TenFile";
            this.C_TenFile.Width = 105;
            // 
            // C_User
            // 
            this.C_User.HeaderText = "User";
            this.C_User.Name = "C_User";
            // 
            // cTinhTrangUser
            // 
            this.cTinhTrangUser.HeaderText = "TinhTrangUser";
            this.cTinhTrangUser.Name = "cTinhTrangUser";
            // 
            // cTinhTrangDownload
            // 
            this.cTinhTrangDownload.FillWeight = 105F;
            this.cTinhTrangDownload.HeaderText = "TinhTrangDownload";
            this.cTinhTrangDownload.Name = "cTinhTrangDownload";
            this.cTinhTrangDownload.Width = 105;
            // 
            // txtTenFile
            // 
            this.txtTenFile.Location = new System.Drawing.Point(104, 17);
            this.txtTenFile.Name = "txtTenFile";
            this.txtTenFile.Size = new System.Drawing.Size(179, 20);
            this.txtTenFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên File";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(34, 277);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(165, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDongKetNoi
            // 
            this.btnDongKetNoi.Location = new System.Drawing.Point(356, 277);
            this.btnDongKetNoi.Name = "btnDongKetNoi";
            this.btnDongKetNoi.Size = new System.Drawing.Size(89, 23);
            this.btnDongKetNoi.TabIndex = 6;
            this.btnDongKetNoi.Text = "Đóng Kết Nối";
            this.btnDongKetNoi.UseVisualStyleBackColor = true;
            this.btnDongKetNoi.Click += new System.EventHandler(this.btnDongKetNoi_Click);
            // 
            // btnTrayIcon
            // 
            this.btnTrayIcon.Location = new System.Drawing.Point(275, 277);
            this.btnTrayIcon.Name = "btnTrayIcon";
            this.btnTrayIcon.Size = new System.Drawing.Size(75, 23);
            this.btnTrayIcon.TabIndex = 5;
            this.btnTrayIcon.Text = "Tray icon";
            this.btnTrayIcon.UseVisualStyleBackColor = true;
            this.btnTrayIcon.Click += new System.EventHandler(this.btnTrayIcon_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ClientApp 1.0";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.closeAppToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 48);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // closeAppToolStripMenuItem
            // 
            this.closeAppToolStripMenuItem.Name = "closeAppToolStripMenuItem";
            this.closeAppToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.closeAppToolStripMenuItem.Text = "Close App";
            this.closeAppToolStripMenuItem.Click += new System.EventHandler(this.closeAppToolStripMenuItem_Click);
            // 
            // FormChiaSeFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 324);
            this.ControlBox = false;
            this.Controls.Add(this.btnTrayIcon);
            this.Controls.Add(this.btnDongKetNoi);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenFile);
            this.Controls.Add(this.BangFile);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnTim);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChiaSeFile";
            this.Text = "File";
            ((System.ComponentModel.ISupportInitialize)(this.BangFile)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView BangFile;
        private System.Windows.Forms.TextBox txtTenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_TenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTinhTrangUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTinhTrangDownload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnDongKetNoi;
        private System.Windows.Forms.Button btnTrayIcon;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAppToolStripMenuItem;
    }
}