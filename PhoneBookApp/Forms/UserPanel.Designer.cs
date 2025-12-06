namespace PhoneBookApp.Forms
{
    partial class UserPanel
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
            this.tabUser = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSearchDepartment = new System.Windows.Forms.ComboBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnSearchByName = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchPhone = new System.Windows.Forms.TextBox();
            this.txtSearchLastName = new System.Windows.Forms.TextBox();
            this.lblSearchLastName = new System.Windows.Forms.Label();
            this.tabBilling = new System.Windows.Forms.TabPage();
            this.btnDownloadBilling = new System.Windows.Forms.Button();
            this.dgvBilling = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnChangePhoto = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.picUserPhoto = new System.Windows.Forms.PictureBox();
            this.btnDwlBilling = new System.Windows.Forms.Button();
            this.tabUser.SuspendLayout();
            this.tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.tabBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tabSearch);
            this.tabUser.Controls.Add(this.tabBilling);
            this.tabUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabUser.Location = new System.Drawing.Point(0, 121);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(906, 421);
            this.tabUser.TabIndex = 0;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.label3);
            this.tabSearch.Controls.Add(this.cmbSearchDepartment);
            this.tabSearch.Controls.Add(this.dgvResults);
            this.tabSearch.Controls.Add(this.btnSearchByName);
            this.tabSearch.Controls.Add(this.label2);
            this.tabSearch.Controls.Add(this.txtSearchPhone);
            this.tabSearch.Controls.Add(this.txtSearchLastName);
            this.tabSearch.Controls.Add(this.lblSearchLastName);
            this.tabSearch.Location = new System.Drawing.Point(4, 25);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(889, 392);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            this.tabSearch.Click += new System.EventHandler(this.tabSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Search by department:";
            // 
            // cmbSearchDepartment
            // 
            this.cmbSearchDepartment.FormattingEnabled = true;
            this.cmbSearchDepartment.Location = new System.Drawing.Point(479, 48);
            this.cmbSearchDepartment.Name = "cmbSearchDepartment";
            this.cmbSearchDepartment.Size = new System.Drawing.Size(200, 24);
            this.cmbSearchDepartment.TabIndex = 6;
            this.cmbSearchDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbSearchDepartment_SelectedIndexChanged_1);
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvResults.Location = new System.Drawing.Point(0, 92);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(889, 300);
            this.dgvResults.TabIndex = 5;
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
            // 
            // btnSearchByName
            // 
            this.btnSearchByName.Location = new System.Drawing.Point(714, 49);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Size = new System.Drawing.Size(120, 23);
            this.btnSearchByName.TabIndex = 4;
            this.btnSearchByName.Text = "Search";
            this.btnSearchByName.UseVisualStyleBackColor = true;
            this.btnSearchByName.Click += new System.EventHandler(this.btnSearchByName_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search by phone";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.Location = new System.Drawing.Point(250, 50);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(200, 22);
            this.txtSearchPhone.TabIndex = 2;
            this.txtSearchPhone.TextChanged += new System.EventHandler(this.txtSearchPhone_TextChanged);
            // 
            // txtSearchLastName
            // 
            this.txtSearchLastName.Location = new System.Drawing.Point(20, 50);
            this.txtSearchLastName.Name = "txtSearchLastName";
            this.txtSearchLastName.Size = new System.Drawing.Size(200, 22);
            this.txtSearchLastName.TabIndex = 1;
            this.txtSearchLastName.TextChanged += new System.EventHandler(this.txtSearchLastName_TextChanged);
            // 
            // lblSearchLastName
            // 
            this.lblSearchLastName.AutoSize = true;
            this.lblSearchLastName.Location = new System.Drawing.Point(20, 20);
            this.lblSearchLastName.Name = "lblSearchLastName";
            this.lblSearchLastName.Size = new System.Drawing.Size(129, 16);
            this.lblSearchLastName.TabIndex = 0;
            this.lblSearchLastName.Text = "Search by last name";
            this.lblSearchLastName.Click += new System.EventHandler(this.lblSearchLastName_Click);
            // 
            // tabBilling
            // 
            this.tabBilling.Controls.Add(this.btnDwlBilling);
            this.tabBilling.Controls.Add(this.btnDownloadBilling);
            this.tabBilling.Controls.Add(this.dgvBilling);
            this.tabBilling.Controls.Add(this.label1);
            this.tabBilling.Location = new System.Drawing.Point(4, 25);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Size = new System.Drawing.Size(898, 392);
            this.tabBilling.TabIndex = 2;
            this.tabBilling.Text = "Billing";
            this.tabBilling.UseVisualStyleBackColor = true;
            // 
            // btnDownloadBilling
            // 
            this.btnDownloadBilling.Location = new System.Drawing.Point(701, 416);
            this.btnDownloadBilling.Name = "btnDownloadBilling";
            this.btnDownloadBilling.Size = new System.Drawing.Size(119, 23);
            this.btnDownloadBilling.TabIndex = 2;
            this.btnDownloadBilling.Text = "Download CSV";
            this.btnDownloadBilling.UseVisualStyleBackColor = true;
            this.btnDownloadBilling.Click += new System.EventHandler(this.btnDownloadBilling_Click_1);
            // 
            // dgvBilling
            // 
            this.dgvBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBilling.Location = new System.Drawing.Point(20, 60);
            this.dgvBilling.Name = "dgvBilling";
            this.dgvBilling.RowHeadersWidth = 51;
            this.dgvBilling.RowTemplate.Height = 24;
            this.dgvBilling.Size = new System.Drawing.Size(800, 271);
            this.dgvBilling.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your billing";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightGray;
            this.panelTop.Controls.Add(this.btnChangePhoto);
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.picUserPhoto);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(906, 120);
            this.panelTop.TabIndex = 1;
            // 
            // btnChangePhoto
            // 
            this.btnChangePhoto.Location = new System.Drawing.Point(135, 80);
            this.btnChangePhoto.Name = "btnChangePhoto";
            this.btnChangePhoto.Size = new System.Drawing.Size(100, 30);
            this.btnChangePhoto.TabIndex = 2;
            this.btnChangePhoto.Text = "Change Photo";
            this.btnChangePhoto.UseVisualStyleBackColor = true;
            this.btnChangePhoto.Click += new System.EventHandler(this.btnChangePhoto_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWelcome.Location = new System.Drawing.Point(130, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(89, 27);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            // 
            // picUserPhoto
            // 
            this.picUserPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUserPhoto.Location = new System.Drawing.Point(10, 10);
            this.picUserPhoto.Name = "picUserPhoto";
            this.picUserPhoto.Size = new System.Drawing.Size(100, 100);
            this.picUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUserPhoto.TabIndex = 0;
            this.picUserPhoto.TabStop = false;
            this.picUserPhoto.Click += new System.EventHandler(this.picUserPhoto_Click);
            // 
            // btnDwlBilling
            // 
            this.btnDwlBilling.Location = new System.Drawing.Point(744, 351);
            this.btnDwlBilling.Name = "btnDwlBilling";
            this.btnDwlBilling.Size = new System.Drawing.Size(75, 23);
            this.btnDwlBilling.TabIndex = 3;
            this.btnDwlBilling.Text = "Download CSV";
            this.btnDwlBilling.UseVisualStyleBackColor = true;
            this.btnDwlBilling.Click += new System.EventHandler(this.btnDwlBilling_Click);
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 542);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.tabUser);
            this.Name = "UserPanel";
            this.Text = "UserPanel";
            this.Load += new System.EventHandler(this.UserPanel_Load);
            this.tabUser.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.tabBilling.ResumeLayout(false);
            this.tabBilling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUser;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabBilling;
        private System.Windows.Forms.Button btnSearchByName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchPhone;
        private System.Windows.Forms.TextBox txtSearchLastName;
        private System.Windows.Forms.Label lblSearchLastName;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridView dgvBilling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownloadBilling;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox picUserPhoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSearchDepartment;
        private System.Windows.Forms.Button btnChangePhoto;
        private System.Windows.Forms.Button btnDwlBilling;
    }
}