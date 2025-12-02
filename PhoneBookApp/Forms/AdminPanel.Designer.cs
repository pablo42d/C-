namespace PhoneBookApp.Forms
{
    partial class AdminPanel
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
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.tabDepartments = new System.Windows.Forms.TabPage();
            this.tabDevices = new System.Windows.Forms.TabPage();
            this.tabBilling = new System.Windows.Forms.TabPage();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.panelEmployeeDetails = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmpFirstName = new System.Windows.Forms.TextBox();
            this.txtEmpLastName = new System.Windows.Forms.TextBox();
            this.txtEmpEmail = new System.Windows.Forms.TextBox();
            this.txtEmpPhone = new System.Windows.Forms.TextBox();
            this.txtEmpMobile = new System.Windows.Forms.TextBox();
            this.cmbEmpDepartment = new System.Windows.Forms.ComboBox();
            this.picEmpPhoto = new System.Windows.Forms.PictureBox();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.tabAdmin.SuspendLayout();
            this.tabEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.panelEmployeeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmpPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabEmployees);
            this.tabAdmin.Controls.Add(this.tabDepartments);
            this.tabAdmin.Controls.Add(this.tabDevices);
            this.tabAdmin.Controls.Add(this.tabBilling);
            this.tabAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(1051, 592);
            this.tabAdmin.TabIndex = 0;
            // 
            // tabEmployees
            // 
            this.tabEmployees.Controls.Add(this.panelEmployeeDetails);
            this.tabEmployees.Controls.Add(this.btnDeleteEmployee);
            this.tabEmployees.Controls.Add(this.btnEditEmployee);
            this.tabEmployees.Controls.Add(this.btnAddEmployee);
            this.tabEmployees.Controls.Add(this.dgvEmployees);
            this.tabEmployees.Location = new System.Drawing.Point(4, 25);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(1043, 563);
            this.tabEmployees.TabIndex = 0;
            this.tabEmployees.Text = "Employees";
            this.tabEmployees.UseVisualStyleBackColor = true;
            this.tabEmployees.Click += new System.EventHandler(this.tabEmployees_Click);
            // 
            // tabDepartments
            // 
            this.tabDepartments.Location = new System.Drawing.Point(4, 25);
            this.tabDepartments.Name = "tabDepartments";
            this.tabDepartments.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepartments.Size = new System.Drawing.Size(792, 421);
            this.tabDepartments.TabIndex = 1;
            this.tabDepartments.Text = "Departments";
            this.tabDepartments.UseVisualStyleBackColor = true;
            // 
            // tabDevices
            // 
            this.tabDevices.Location = new System.Drawing.Point(4, 25);
            this.tabDevices.Name = "tabDevices";
            this.tabDevices.Size = new System.Drawing.Size(792, 421);
            this.tabDevices.TabIndex = 2;
            this.tabDevices.Text = "Devices";
            this.tabDevices.UseVisualStyleBackColor = true;
            // 
            // tabBilling
            // 
            this.tabBilling.Location = new System.Drawing.Point(4, 25);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Size = new System.Drawing.Size(792, 421);
            this.tabBilling.TabIndex = 3;
            this.tabBilling.Text = "Billing Import";
            this.tabBilling.UseVisualStyleBackColor = true;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEmployees.Location = new System.Drawing.Point(3, 3);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.RowTemplate.Height = 250;
            this.dgvEmployees.Size = new System.Drawing.Size(1037, 143);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellContentClick);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(116, 50);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(120, 52);
            this.btnAddEmployee.TabIndex = 1;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(472, 50);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(120, 52);
            this.btnEditEmployee.TabIndex = 2;
            this.btnEditEmployee.Text = "Edit Employee";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(809, 50);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(120, 52);
            this.btnDeleteEmployee.TabIndex = 3;
            this.btnDeleteEmployee.Text = "Delete Employee";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // panelEmployeeDetails
            // 
            this.panelEmployeeDetails.Controls.Add(this.btnUploadPhoto);
            this.panelEmployeeDetails.Controls.Add(this.picEmpPhoto);
            this.panelEmployeeDetails.Controls.Add(this.cmbEmpDepartment);
            this.panelEmployeeDetails.Controls.Add(this.txtEmpMobile);
            this.panelEmployeeDetails.Controls.Add(this.txtEmpPhone);
            this.panelEmployeeDetails.Controls.Add(this.txtEmpEmail);
            this.panelEmployeeDetails.Controls.Add(this.txtEmpLastName);
            this.panelEmployeeDetails.Controls.Add(this.txtEmpFirstName);
            this.panelEmployeeDetails.Controls.Add(this.label5);
            this.panelEmployeeDetails.Controls.Add(this.label4);
            this.panelEmployeeDetails.Controls.Add(this.label3);
            this.panelEmployeeDetails.Controls.Add(this.label2);
            this.panelEmployeeDetails.Controls.Add(this.label1);
            this.panelEmployeeDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEmployeeDetails.Location = new System.Drawing.Point(3, 380);
            this.panelEmployeeDetails.Name = "panelEmployeeDetails";
            this.panelEmployeeDetails.Size = new System.Drawing.Size(1037, 180);
            this.panelEmployeeDetails.TabIndex = 4;
            this.panelEmployeeDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEmployeeDetails_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "\nFirst Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(732, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(891, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mobile";
            // 
            // txtEmpFirstName
            // 
            this.txtEmpFirstName.Location = new System.Drawing.Point(184, 47);
            this.txtEmpFirstName.Name = "txtEmpFirstName";
            this.txtEmpFirstName.Size = new System.Drawing.Size(158, 22);
            this.txtEmpFirstName.TabIndex = 5;
            this.txtEmpFirstName.TextChanged += new System.EventHandler(this.txtEmpFirstName_TextChanged);
            // 
            // txtEmpLastName
            // 
            this.txtEmpLastName.Location = new System.Drawing.Point(348, 47);
            this.txtEmpLastName.Name = "txtEmpLastName";
            this.txtEmpLastName.Size = new System.Drawing.Size(177, 22);
            this.txtEmpLastName.TabIndex = 6;
            this.txtEmpLastName.TextChanged += new System.EventHandler(this.txtEmpLastName_TextChanged);
            // 
            // txtEmpEmail
            // 
            this.txtEmpEmail.Location = new System.Drawing.Point(534, 47);
            this.txtEmpEmail.Name = "txtEmpEmail";
            this.txtEmpEmail.Size = new System.Drawing.Size(170, 22);
            this.txtEmpEmail.TabIndex = 7;
            this.txtEmpEmail.TextChanged += new System.EventHandler(this.txtEmpEmail_TextChanged);
            // 
            // txtEmpPhone
            // 
            this.txtEmpPhone.Location = new System.Drawing.Point(735, 47);
            this.txtEmpPhone.Name = "txtEmpPhone";
            this.txtEmpPhone.Size = new System.Drawing.Size(114, 22);
            this.txtEmpPhone.TabIndex = 8;
            this.txtEmpPhone.TextChanged += new System.EventHandler(this.txtEmpPhone_TextChanged);
            // 
            // txtEmpMobile
            // 
            this.txtEmpMobile.Location = new System.Drawing.Point(894, 47);
            this.txtEmpMobile.Name = "txtEmpMobile";
            this.txtEmpMobile.Size = new System.Drawing.Size(121, 22);
            this.txtEmpMobile.TabIndex = 9;
            this.txtEmpMobile.TextChanged += new System.EventHandler(this.txtEmpMobile_TextChanged);
            // 
            // cmbEmpDepartment
            // 
            this.cmbEmpDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpDepartment.FormattingEnabled = true;
            this.cmbEmpDepartment.Location = new System.Drawing.Point(184, 108);
            this.cmbEmpDepartment.Name = "cmbEmpDepartment";
            this.cmbEmpDepartment.Size = new System.Drawing.Size(155, 24);
            this.cmbEmpDepartment.TabIndex = 10;
            this.cmbEmpDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbEmpDepartment_SelectedIndexChanged);
            // 
            // picEmpPhoto
            // 
            this.picEmpPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEmpPhoto.Location = new System.Drawing.Point(8, 12);
            this.picEmpPhoto.Name = "picEmpPhoto";
            this.picEmpPhoto.Size = new System.Drawing.Size(120, 120);
            this.picEmpPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEmpPhoto.TabIndex = 11;
            this.picEmpPhoto.TabStop = false;
            this.picEmpPhoto.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Location = new System.Drawing.Point(8, 149);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(120, 26);
            this.btnUploadPhoto.TabIndex = 12;
            this.btnUploadPhoto.Text = "Upload Photo";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 592);
            this.Controls.Add(this.tabAdmin);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.tabAdmin.ResumeLayout(false);
            this.tabEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.panelEmployeeDetails.ResumeLayout(false);
            this.panelEmployeeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmpPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.TabPage tabDepartments;
        private System.Windows.Forms.TabPage tabDevices;
        private System.Windows.Forms.TabPage tabBilling;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Panel panelEmployeeDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpMobile;
        private System.Windows.Forms.TextBox txtEmpPhone;
        private System.Windows.Forms.TextBox txtEmpEmail;
        private System.Windows.Forms.TextBox txtEmpLastName;
        private System.Windows.Forms.TextBox txtEmpFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEmpDepartment;
        private System.Windows.Forms.PictureBox picEmpPhoto;
        private System.Windows.Forms.Button btnUploadPhoto;
    }
}