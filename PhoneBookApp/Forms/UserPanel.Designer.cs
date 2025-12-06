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
            this.tabDepartments = new System.Windows.Forms.TabPage();
            this.tabBilling = new System.Windows.Forms.TabPage();
            this.lblSearchLastName = new System.Windows.Forms.Label();
            this.txtSearchLastName = new System.Windows.Forms.TextBox();
            this.txtSearchPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchByName = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.dgvDeptEmployees = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBilling = new System.Windows.Forms.DataGridView();
            this.btnDownloadBilling = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.picUserPhoto = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tabUser.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tabDepartments.SuspendLayout();
            this.tabBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tabSearch);
            this.tabUser.Controls.Add(this.tabDepartments);
            this.tabUser.Controls.Add(this.tabBilling);
            this.tabUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabUser.Location = new System.Drawing.Point(0, 126);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(897, 421);
            this.tabUser.TabIndex = 0;
            // 
            // tabSearch
            // 
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
            // 
            // tabDepartments
            // 
            this.tabDepartments.Controls.Add(this.dgvDeptEmployees);
            this.tabDepartments.Controls.Add(this.cmbDepartments);
            this.tabDepartments.Location = new System.Drawing.Point(4, 25);
            this.tabDepartments.Name = "tabDepartments";
            this.tabDepartments.Size = new System.Drawing.Size(863, 241);
            this.tabDepartments.TabIndex = 1;
            this.tabDepartments.Text = "Departments";
            this.tabDepartments.UseVisualStyleBackColor = true;
            // 
            // tabBilling
            // 
            this.tabBilling.Controls.Add(this.btnDownloadBilling);
            this.tabBilling.Controls.Add(this.dgvBilling);
            this.tabBilling.Controls.Add(this.label1);
            this.tabBilling.Location = new System.Drawing.Point(4, 25);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Size = new System.Drawing.Size(863, 241);
            this.tabBilling.TabIndex = 2;
            this.tabBilling.Text = "Billing";
            this.tabBilling.UseVisualStyleBackColor = true;
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
            // txtSearchLastName
            // 
            this.txtSearchLastName.Location = new System.Drawing.Point(20, 50);
            this.txtSearchLastName.Name = "txtSearchLastName";
            this.txtSearchLastName.Size = new System.Drawing.Size(200, 22);
            this.txtSearchLastName.TabIndex = 1;
            this.txtSearchLastName.TextChanged += new System.EventHandler(this.txtSearchLastName_TextChanged);
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.Location = new System.Drawing.Point(250, 50);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(200, 22);
            this.txtSearchPhone.TabIndex = 2;
            this.txtSearchPhone.TextChanged += new System.EventHandler(this.txtSearchPhone_TextChanged);
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
            // btnSearchByName
            // 
            this.btnSearchByName.Location = new System.Drawing.Point(480, 45);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Size = new System.Drawing.Size(120, 23);
            this.btnSearchByName.TabIndex = 4;
            this.btnSearchByName.Text = "Search";
            this.btnSearchByName.UseVisualStyleBackColor = true;
            this.btnSearchByName.Click += new System.EventHandler(this.btnSearchByName_Click_1);
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
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(20, 20);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(200, 24);
            this.cmbDepartments.TabIndex = 0;
            this.cmbDepartments.SelectedIndexChanged += new System.EventHandler(this.cmbDepartments_SelectedIndexChanged_1);
            // 
            // dgvDeptEmployees
            // 
            this.dgvDeptEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeptEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptEmployees.Location = new System.Drawing.Point(20, 60);
            this.dgvDeptEmployees.Name = "dgvDeptEmployees";
            this.dgvDeptEmployees.RowHeadersWidth = 51;
            this.dgvDeptEmployees.RowTemplate.Height = 24;
            this.dgvDeptEmployees.Size = new System.Drawing.Size(871, 170);
            this.dgvDeptEmployees.TabIndex = 1;
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
            // dgvBilling
            // 
            this.dgvBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBilling.Location = new System.Drawing.Point(20, 60);
            this.dgvBilling.Name = "dgvBilling";
            this.dgvBilling.RowHeadersWidth = 51;
            this.dgvBilling.RowTemplate.Height = 24;
            this.dgvBilling.Size = new System.Drawing.Size(800, 350);
            this.dgvBilling.TabIndex = 1;
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
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightGray;
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.picUserPhoto);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(897, 120);
            this.panelTop.TabIndex = 1;
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
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 547);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.tabUser);
            this.Name = "UserPanel";
            this.Text = "UserPanel";
            this.Load += new System.EventHandler(this.UserPanel_Load);
            this.tabUser.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.tabDepartments.ResumeLayout(false);
            this.tabBilling.ResumeLayout(false);
            this.tabBilling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUser;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabDepartments;
        private System.Windows.Forms.TabPage tabBilling;
        private System.Windows.Forms.Button btnSearchByName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchPhone;
        private System.Windows.Forms.TextBox txtSearchLastName;
        private System.Windows.Forms.Label lblSearchLastName;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.DataGridView dgvDeptEmployees;
        private System.Windows.Forms.DataGridView dgvBilling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownloadBilling;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox picUserPhoto;
    }
}