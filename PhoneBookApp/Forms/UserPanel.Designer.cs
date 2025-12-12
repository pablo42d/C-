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
            this.btnDwlBilling = new System.Windows.Forms.Button();
            this.btnDownloadBilling = new System.Windows.Forms.Button();
            this.dgvBilling = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnChangePhoto = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.picUserPhoto = new System.Windows.Forms.PictureBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
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
            this.tabUser.Location = new System.Drawing.Point(0, 98);
            this.tabUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(680, 342);
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
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(672, 316);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            this.tabSearch.Click += new System.EventHandler(this.tabSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Search by department:";
            // 
            // cmbSearchDepartment
            // 
            this.cmbSearchDepartment.FormattingEnabled = true;
            this.cmbSearchDepartment.Location = new System.Drawing.Point(359, 39);
            this.cmbSearchDepartment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSearchDepartment.Name = "cmbSearchDepartment";
            this.cmbSearchDepartment.Size = new System.Drawing.Size(151, 21);
            this.cmbSearchDepartment.TabIndex = 6;
            this.cmbSearchDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbSearchDepartment_SelectedIndexChanged_1);
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvResults.Location = new System.Drawing.Point(0, 72);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(672, 244);
            this.dgvResults.TabIndex = 5;
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
            // 
            // btnSearchByName
            // 
            this.btnSearchByName.Location = new System.Drawing.Point(536, 40);
            this.btnSearchByName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Size = new System.Drawing.Size(90, 19);
            this.btnSearchByName.TabIndex = 4;
            this.btnSearchByName.Text = "Search";
            this.btnSearchByName.UseVisualStyleBackColor = true;
            this.btnSearchByName.Click += new System.EventHandler(this.btnSearchByName_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search by phone";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.Location = new System.Drawing.Point(188, 41);
            this.txtSearchPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(151, 20);
            this.txtSearchPhone.TabIndex = 2;
            this.txtSearchPhone.TextChanged += new System.EventHandler(this.txtSearchPhone_TextChanged);
            // 
            // txtSearchLastName
            // 
            this.txtSearchLastName.Location = new System.Drawing.Point(15, 41);
            this.txtSearchLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchLastName.Name = "txtSearchLastName";
            this.txtSearchLastName.Size = new System.Drawing.Size(151, 20);
            this.txtSearchLastName.TabIndex = 1;
            this.txtSearchLastName.TextChanged += new System.EventHandler(this.txtSearchLastName_TextChanged);
            // 
            // lblSearchLastName
            // 
            this.lblSearchLastName.AutoSize = true;
            this.lblSearchLastName.Location = new System.Drawing.Point(15, 16);
            this.lblSearchLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchLastName.Name = "lblSearchLastName";
            this.lblSearchLastName.Size = new System.Drawing.Size(118, 15);
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
            this.tabBilling.Location = new System.Drawing.Point(4, 22);
            this.tabBilling.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Size = new System.Drawing.Size(672, 316);
            this.tabBilling.TabIndex = 2;
            this.tabBilling.Text = "Billing";
            this.tabBilling.UseVisualStyleBackColor = true;
            // 
            // btnDwlBilling
            // 
            this.btnDwlBilling.Location = new System.Drawing.Point(558, 285);
            this.btnDwlBilling.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDwlBilling.Name = "btnDwlBilling";
            this.btnDwlBilling.Size = new System.Drawing.Size(56, 19);
            this.btnDwlBilling.TabIndex = 3;
            this.btnDwlBilling.Text = "Download CSV";
            this.btnDwlBilling.UseVisualStyleBackColor = true;
            this.btnDwlBilling.Click += new System.EventHandler(this.btnDwlBilling_Click);
            // 
            // btnDownloadBilling
            // 
            this.btnDownloadBilling.Location = new System.Drawing.Point(526, 338);
            this.btnDownloadBilling.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDownloadBilling.Name = "btnDownloadBilling";
            this.btnDownloadBilling.Size = new System.Drawing.Size(89, 19);
            this.btnDownloadBilling.TabIndex = 2;
            this.btnDownloadBilling.Text = "Download CSV";
            this.btnDownloadBilling.UseVisualStyleBackColor = true;
            this.btnDownloadBilling.Click += new System.EventHandler(this.btnDownloadBilling_Click_1);
            // 
            // dgvBilling
            // 
            this.dgvBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBilling.Location = new System.Drawing.Point(15, 49);
            this.dgvBilling.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvBilling.Name = "dgvBilling";
            this.dgvBilling.RowHeadersWidth = 51;
            this.dgvBilling.RowTemplate.Height = 24;
            this.dgvBilling.Size = new System.Drawing.Size(600, 220);
            this.dgvBilling.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your billing";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightGray;
            this.panelTop.Controls.Add(this.btnChangePassword);
            this.panelTop.Controls.Add(this.btnChangePhoto);
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.picUserPhoto);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(680, 98);
            this.panelTop.TabIndex = 1;
            // 
            // btnChangePhoto
            // 
            this.btnChangePhoto.Location = new System.Drawing.Point(101, 65);
            this.btnChangePhoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChangePhoto.Name = "btnChangePhoto";
            this.btnChangePhoto.Size = new System.Drawing.Size(108, 24);
            this.btnChangePhoto.TabIndex = 2;
            this.btnChangePhoto.Text = "Change Photo";
            this.btnChangePhoto.UseVisualStyleBackColor = true;
            this.btnChangePhoto.Click += new System.EventHandler(this.btnChangePhoto_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWelcome.Location = new System.Drawing.Point(98, 24);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(89, 27);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            // 
            // picUserPhoto
            // 
            this.picUserPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUserPhoto.Location = new System.Drawing.Point(8, 8);
            this.picUserPhoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picUserPhoto.Name = "picUserPhoto";
            this.picUserPhoto.Size = new System.Drawing.Size(76, 82);
            this.picUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUserPhoto.TabIndex = 0;
            this.picUserPhoto.TabStop = false;
            this.picUserPhoto.Click += new System.EventHandler(this.picUserPhoto_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(246, 65);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(118, 24);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 440);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.tabUser);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button btnChangePassword;
    }
}