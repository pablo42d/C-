using System;
using System.Windows.Forms;

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
            this.panelEmployeeDetails = new System.Windows.Forms.Panel();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.picEmpPhoto = new System.Windows.Forms.PictureBox();
            this.cmbEmpDepartment = new System.Windows.Forms.ComboBox();
            this.txtEmpMobile = new System.Windows.Forms.TextBox();
            this.txtEmpPhone = new System.Windows.Forms.TextBox();
            this.txtEmpEmail = new System.Windows.Forms.TextBox();
            this.txtEmpLastName = new System.Windows.Forms.TextBox();
            this.txtEmpFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.tabDepartments = new System.Windows.Forms.TabPage();
            this.panelDepartmentDetails = new System.Windows.Forms.Panel();
            this.lblDeptDescription = new System.Windows.Forms.Label();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.txtDeptDescription = new System.Windows.Forms.TextBox();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.btnDeleteDepartment = new System.Windows.Forms.Button();
            this.btnEditDepartment = new System.Windows.Forms.Button();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.tabDevices = new System.Windows.Forms.TabPage();
            this.panelDeviceDetails = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDevReplace = new System.Windows.Forms.DateTimePicker();
            this.dtpDevIssue = new System.Windows.Forms.DateTimePicker();
            this.cmbDevEmployee = new System.Windows.Forms.ComboBox();
            this.cmbDevStatus = new System.Windows.Forms.ComboBox();
            this.cmbDevType = new System.Windows.Forms.ComboBox();
            this.txtDevNotes = new System.Windows.Forms.TextBox();
            this.txtDevLocation = new System.Windows.Forms.TextBox();
            this.txtDevMAC = new System.Windows.Forms.TextBox();
            this.txtDevIMEI = new System.Windows.Forms.TextBox();
            this.txtDevModel = new System.Windows.Forms.TextBox();
            this.txtDevInventory = new System.Windows.Forms.TextBox();
            this.txtDevSerial = new System.Windows.Forms.TextBox();
            this.lblDevNotes = new System.Windows.Forms.Label();
            this.lblDevEmployee = new System.Windows.Forms.Label();
            this.lblDevStatus = new System.Windows.Forms.Label();
            this.lblDevType = new System.Windows.Forms.Label();
            this.lblDevLocation = new System.Windows.Forms.Label();
            this.lblDevMAC = new System.Windows.Forms.Label();
            this.lblDevIMEI = new System.Windows.Forms.Label();
            this.lblDevModel = new System.Windows.Forms.Label();
            this.lblDevInventory = new System.Windows.Forms.Label();
            this.lblDevSerial = new System.Windows.Forms.Label();
            this.chkDevMDM = new System.Windows.Forms.CheckBox();
            this.btnDeleteDevice = new System.Windows.Forms.Button();
            this.btnEditDevice = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.tabBilling = new System.Windows.Forms.TabPage();
            this.dgvAllBilling = new System.Windows.Forms.DataGridView();
            this.btnExportBilling = new System.Windows.Forms.Button();
            this.btnLoadBilling = new System.Windows.Forms.Button();
            this.dtpBillingTo = new System.Windows.Forms.DateTimePicker();
            this.dtpBillingFrom = new System.Windows.Forms.DateTimePicker();
            this.lblBillingRange = new System.Windows.Forms.Label();
            this.btnImportBilling = new System.Windows.Forms.Button();
            this.txtBillingFile = new System.Windows.Forms.TextBox();
            this.btnBillingBrowse = new System.Windows.Forms.Button();
            this.tabAdmin.SuspendLayout();
            this.tabEmployees.SuspendLayout();
            this.panelEmployeeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmpPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.tabDepartments.SuspendLayout();
            this.panelDepartmentDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.tabDevices.SuspendLayout();
            this.panelDeviceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.tabBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBilling)).BeginInit();
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
            this.tabAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.SelectedIndex = 0;
            this.tabAdmin.Size = new System.Drawing.Size(789, 515);
            this.tabAdmin.TabIndex = 0;
            this.tabAdmin.SelectedIndexChanged += new System.EventHandler(this.tabAdmin_SelectedIndexChanged);
            // 
            // tabEmployees
            // 
            this.tabEmployees.Controls.Add(this.panelEmployeeDetails);
            this.tabEmployees.Controls.Add(this.btnDeleteEmployee);
            this.tabEmployees.Controls.Add(this.btnEditEmployee);
            this.tabEmployees.Controls.Add(this.btnAddEmployee);
            this.tabEmployees.Controls.Add(this.dgvEmployees);
            this.tabEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabEmployees.Margin = new System.Windows.Forms.Padding(2);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(2);
            this.tabEmployees.Size = new System.Drawing.Size(781, 489);
            this.tabEmployees.TabIndex = 0;
            this.tabEmployees.Text = "Employees";
            this.tabEmployees.UseVisualStyleBackColor = true;
            this.tabEmployees.Click += new System.EventHandler(this.tabEmployees_Click);
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
            this.panelEmployeeDetails.Location = new System.Drawing.Point(2, 341);
            this.panelEmployeeDetails.Margin = new System.Windows.Forms.Padding(2);
            this.panelEmployeeDetails.Name = "panelEmployeeDetails";
            this.panelEmployeeDetails.Size = new System.Drawing.Size(777, 146);
            this.panelEmployeeDetails.TabIndex = 4;
            this.panelEmployeeDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEmployeeDetails_Paint);
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Location = new System.Drawing.Point(6, 121);
            this.btnUploadPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(90, 21);
            this.btnUploadPhoto.TabIndex = 12;
            this.btnUploadPhoto.Text = "Upload Photo";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // picEmpPhoto
            // 
            this.picEmpPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEmpPhoto.Location = new System.Drawing.Point(6, 10);
            this.picEmpPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.picEmpPhoto.Name = "picEmpPhoto";
            this.picEmpPhoto.Size = new System.Drawing.Size(90, 98);
            this.picEmpPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEmpPhoto.TabIndex = 11;
            this.picEmpPhoto.TabStop = false;
            this.picEmpPhoto.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cmbEmpDepartment
            // 
            this.cmbEmpDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpDepartment.FormattingEnabled = true;
            this.cmbEmpDepartment.Location = new System.Drawing.Point(138, 88);
            this.cmbEmpDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.cmbEmpDepartment.Name = "cmbEmpDepartment";
            this.cmbEmpDepartment.Size = new System.Drawing.Size(117, 21);
            this.cmbEmpDepartment.TabIndex = 10;
            this.cmbEmpDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbEmpDepartment_SelectedIndexChanged);
            // 
            // txtEmpMobile
            // 
            this.txtEmpMobile.Location = new System.Drawing.Point(670, 38);
            this.txtEmpMobile.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpMobile.Name = "txtEmpMobile";
            this.txtEmpMobile.Size = new System.Drawing.Size(92, 20);
            this.txtEmpMobile.TabIndex = 9;
            this.txtEmpMobile.TextChanged += new System.EventHandler(this.txtEmpMobile_TextChanged);
            // 
            // txtEmpPhone
            // 
            this.txtEmpPhone.Location = new System.Drawing.Point(551, 38);
            this.txtEmpPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpPhone.Name = "txtEmpPhone";
            this.txtEmpPhone.Size = new System.Drawing.Size(86, 20);
            this.txtEmpPhone.TabIndex = 8;
            this.txtEmpPhone.TextChanged += new System.EventHandler(this.txtEmpPhone_TextChanged);
            // 
            // txtEmpEmail
            // 
            this.txtEmpEmail.Location = new System.Drawing.Point(400, 38);
            this.txtEmpEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpEmail.Name = "txtEmpEmail";
            this.txtEmpEmail.Size = new System.Drawing.Size(128, 20);
            this.txtEmpEmail.TabIndex = 7;
            this.txtEmpEmail.TextChanged += new System.EventHandler(this.txtEmpEmail_TextChanged);
            // 
            // txtEmpLastName
            // 
            this.txtEmpLastName.Location = new System.Drawing.Point(261, 38);
            this.txtEmpLastName.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpLastName.Name = "txtEmpLastName";
            this.txtEmpLastName.Size = new System.Drawing.Size(134, 20);
            this.txtEmpLastName.TabIndex = 6;
            this.txtEmpLastName.TextChanged += new System.EventHandler(this.txtEmpLastName_TextChanged);
            // 
            // txtEmpFirstName
            // 
            this.txtEmpFirstName.Location = new System.Drawing.Point(138, 38);
            this.txtEmpFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpFirstName.Name = "txtEmpFirstName";
            this.txtEmpFirstName.Size = new System.Drawing.Size(120, 20);
            this.txtEmpFirstName.TabIndex = 5;
            this.txtEmpFirstName.TextChanged += new System.EventHandler(this.txtEmpFirstName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(668, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mobile";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(549, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(673, 262);
            this.btnDeleteEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(90, 42);
            this.btnDeleteEmployee.TabIndex = 3;
            this.btnDeleteEmployee.Text = "Delete Employee";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(320, 262);
            this.btnEditEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(90, 42);
            this.btnEditEmployee.TabIndex = 2;
            this.btnEditEmployee.Text = "Edit Employee";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(6, 262);
            this.btnAddEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(90, 42);
            this.btnAddEmployee.TabIndex = 1;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEmployees.Location = new System.Drawing.Point(2, 2);
            this.dgvEmployees.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.RowTemplate.Height = 40;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(777, 254);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellContentClick);
            // 
            // tabDepartments
            // 
            this.tabDepartments.Controls.Add(this.panelDepartmentDetails);
            this.tabDepartments.Controls.Add(this.btnDeleteDepartment);
            this.tabDepartments.Controls.Add(this.btnEditDepartment);
            this.tabDepartments.Controls.Add(this.btnAddDepartment);
            this.tabDepartments.Controls.Add(this.dgvDepartments);
            this.tabDepartments.Location = new System.Drawing.Point(4, 22);
            this.tabDepartments.Margin = new System.Windows.Forms.Padding(2);
            this.tabDepartments.Name = "tabDepartments";
            this.tabDepartments.Padding = new System.Windows.Forms.Padding(2);
            this.tabDepartments.Size = new System.Drawing.Size(781, 489);
            this.tabDepartments.TabIndex = 1;
            this.tabDepartments.Text = "Departments";
            this.tabDepartments.UseVisualStyleBackColor = true;
            // 
            // panelDepartmentDetails
            // 
            this.panelDepartmentDetails.Controls.Add(this.lblDeptDescription);
            this.panelDepartmentDetails.Controls.Add(this.lblDeptName);
            this.panelDepartmentDetails.Controls.Add(this.txtDeptDescription);
            this.panelDepartmentDetails.Controls.Add(this.txtDeptName);
            this.panelDepartmentDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDepartmentDetails.Location = new System.Drawing.Point(2, 341);
            this.panelDepartmentDetails.Margin = new System.Windows.Forms.Padding(2);
            this.panelDepartmentDetails.Name = "panelDepartmentDetails";
            this.panelDepartmentDetails.Size = new System.Drawing.Size(777, 146);
            this.panelDepartmentDetails.TabIndex = 4;
            // 
            // lblDeptDescription
            // 
            this.lblDeptDescription.AutoSize = true;
            this.lblDeptDescription.Location = new System.Drawing.Point(2, 47);
            this.lblDeptDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeptDescription.Name = "lblDeptDescription";
            this.lblDeptDescription.Size = new System.Drawing.Size(72, 15);
            this.lblDeptDescription.TabIndex = 3;
            this.lblDeptDescription.Text = "Description:";
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Location = new System.Drawing.Point(2, 15);
            this.lblDeptName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(44, 15);
            this.lblDeptName.TabIndex = 2;
            this.lblDeptName.Text = "Name:";
            // 
            // txtDeptDescription
            // 
            this.txtDeptDescription.Location = new System.Drawing.Point(103, 45);
            this.txtDeptDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeptDescription.Multiline = true;
            this.txtDeptDescription.Name = "txtDeptDescription";
            this.txtDeptDescription.Size = new System.Drawing.Size(301, 82);
            this.txtDeptDescription.TabIndex = 1;
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(103, 13);
            this.txtDeptName.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(151, 20);
            this.txtDeptName.TabIndex = 0;
            // 
            // btnDeleteDepartment
            // 
            this.btnDeleteDepartment.Location = new System.Drawing.Point(673, 262);
            this.btnDeleteDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteDepartment.Name = "btnDeleteDepartment";
            this.btnDeleteDepartment.Size = new System.Drawing.Size(90, 42);
            this.btnDeleteDepartment.TabIndex = 3;
            this.btnDeleteDepartment.Text = "Delete Department";
            this.btnDeleteDepartment.UseVisualStyleBackColor = true;
            this.btnDeleteDepartment.Click += new System.EventHandler(this.btnDeleteDepartment_Click);
            // 
            // btnEditDepartment
            // 
            this.btnEditDepartment.Location = new System.Drawing.Point(320, 262);
            this.btnEditDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditDepartment.Name = "btnEditDepartment";
            this.btnEditDepartment.Size = new System.Drawing.Size(90, 42);
            this.btnEditDepartment.TabIndex = 2;
            this.btnEditDepartment.Text = "Edit Department";
            this.btnEditDepartment.UseVisualStyleBackColor = true;
            this.btnEditDepartment.Click += new System.EventHandler(this.btnEditDepartment_Click);
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.Location = new System.Drawing.Point(6, 262);
            this.btnAddDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(90, 42);
            this.btnAddDepartment.TabIndex = 1;
            this.btnAddDepartment.Text = "Add Department";
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.AllowUserToAddRows = false;
            this.dgvDepartments.AllowUserToDeleteRows = false;
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDepartments.Location = new System.Drawing.Point(2, 2);
            this.dgvDepartments.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDepartments.MultiSelect = false;
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.ReadOnly = true;
            this.dgvDepartments.RowHeadersWidth = 51;
            this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.Size = new System.Drawing.Size(777, 254);
            this.dgvDepartments.TabIndex = 0;
            this.dgvDepartments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartments_CellClick);
            // 
            // tabDevices
            // 
            this.tabDevices.Controls.Add(this.panelDeviceDetails);
            this.tabDevices.Controls.Add(this.btnDeleteDevice);
            this.tabDevices.Controls.Add(this.btnEditDevice);
            this.tabDevices.Controls.Add(this.btnAddDevice);
            this.tabDevices.Controls.Add(this.dgvDevices);
            this.tabDevices.Location = new System.Drawing.Point(4, 22);
            this.tabDevices.Margin = new System.Windows.Forms.Padding(2);
            this.tabDevices.Name = "tabDevices";
            this.tabDevices.Size = new System.Drawing.Size(781, 489);
            this.tabDevices.TabIndex = 2;
            this.tabDevices.Text = "Devices";
            this.tabDevices.UseVisualStyleBackColor = true;
            // 
            // panelDeviceDetails
            // 
            this.panelDeviceDetails.Controls.Add(this.label7);
            this.panelDeviceDetails.Controls.Add(this.label6);
            this.panelDeviceDetails.Controls.Add(this.dtpDevReplace);
            this.panelDeviceDetails.Controls.Add(this.dtpDevIssue);
            this.panelDeviceDetails.Controls.Add(this.cmbDevEmployee);
            this.panelDeviceDetails.Controls.Add(this.cmbDevStatus);
            this.panelDeviceDetails.Controls.Add(this.cmbDevType);
            this.panelDeviceDetails.Controls.Add(this.txtDevNotes);
            this.panelDeviceDetails.Controls.Add(this.txtDevLocation);
            this.panelDeviceDetails.Controls.Add(this.txtDevMAC);
            this.panelDeviceDetails.Controls.Add(this.txtDevIMEI);
            this.panelDeviceDetails.Controls.Add(this.txtDevModel);
            this.panelDeviceDetails.Controls.Add(this.txtDevInventory);
            this.panelDeviceDetails.Controls.Add(this.txtDevSerial);
            this.panelDeviceDetails.Controls.Add(this.lblDevNotes);
            this.panelDeviceDetails.Controls.Add(this.lblDevEmployee);
            this.panelDeviceDetails.Controls.Add(this.lblDevStatus);
            this.panelDeviceDetails.Controls.Add(this.lblDevType);
            this.panelDeviceDetails.Controls.Add(this.lblDevLocation);
            this.panelDeviceDetails.Controls.Add(this.lblDevMAC);
            this.panelDeviceDetails.Controls.Add(this.lblDevIMEI);
            this.panelDeviceDetails.Controls.Add(this.lblDevModel);
            this.panelDeviceDetails.Controls.Add(this.lblDevInventory);
            this.panelDeviceDetails.Controls.Add(this.lblDevSerial);
            this.panelDeviceDetails.Controls.Add(this.chkDevMDM);
            this.panelDeviceDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDeviceDetails.Location = new System.Drawing.Point(0, 261);
            this.panelDeviceDetails.Margin = new System.Windows.Forms.Padding(2);
            this.panelDeviceDetails.Name = "panelDeviceDetails";
            this.panelDeviceDetails.Size = new System.Drawing.Size(781, 228);
            this.panelDeviceDetails.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 193);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Replacement Date:";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Issued Date:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dtpDevReplace
            // 
            this.dtpDevReplace.Location = new System.Drawing.Point(455, 188);
            this.dtpDevReplace.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDevReplace.Name = "dtpDevReplace";
            this.dtpDevReplace.Size = new System.Drawing.Size(151, 20);
            this.dtpDevReplace.TabIndex = 22;
            // 
            // dtpDevIssue
            // 
            this.dtpDevIssue.Location = new System.Drawing.Point(105, 188);
            this.dtpDevIssue.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDevIssue.Name = "dtpDevIssue";
            this.dtpDevIssue.Size = new System.Drawing.Size(151, 20);
            this.dtpDevIssue.TabIndex = 21;
            // 
            // cmbDevEmployee
            // 
            this.cmbDevEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevEmployee.FormattingEnabled = true;
            this.cmbDevEmployee.Location = new System.Drawing.Point(435, 73);
            this.cmbDevEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDevEmployee.Name = "cmbDevEmployee";
            this.cmbDevEmployee.Size = new System.Drawing.Size(151, 21);
            this.cmbDevEmployee.TabIndex = 20;
            // 
            // cmbDevStatus
            // 
            this.cmbDevStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevStatus.FormattingEnabled = true;
            this.cmbDevStatus.Items.AddRange(new object[] {
            "Active",
            "In Repair",
            "Returned",
            "Lost",
            "Deprecated",
            "In Storage"});
            this.cmbDevStatus.Location = new System.Drawing.Point(435, 45);
            this.cmbDevStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDevStatus.Name = "cmbDevStatus";
            this.cmbDevStatus.Size = new System.Drawing.Size(151, 21);
            this.cmbDevStatus.TabIndex = 19;
            // 
            // cmbDevType
            // 
            this.cmbDevType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevType.FormattingEnabled = true;
            this.cmbDevType.Items.AddRange(new object[] {
            "Laptop",
            "Android",
            "iOS",
            "Desk Phone",
            "Tablet",
            "Desktop",
            "Router",
            "Other"});
            this.cmbDevType.Location = new System.Drawing.Point(435, 16);
            this.cmbDevType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDevType.Name = "cmbDevType";
            this.cmbDevType.Size = new System.Drawing.Size(151, 21);
            this.cmbDevType.TabIndex = 18;
            // 
            // txtDevNotes
            // 
            this.txtDevNotes.Location = new System.Drawing.Point(435, 98);
            this.txtDevNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtDevNotes.Multiline = true;
            this.txtDevNotes.Name = "txtDevNotes";
            this.txtDevNotes.Size = new System.Drawing.Size(226, 66);
            this.txtDevNotes.TabIndex = 17;
            // 
            // txtDevLocation
            // 
            this.txtDevLocation.Location = new System.Drawing.Point(105, 158);
            this.txtDevLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtDevLocation.Name = "txtDevLocation";
            this.txtDevLocation.Size = new System.Drawing.Size(151, 20);
            this.txtDevLocation.TabIndex = 16;
            // 
            // txtDevMAC
            // 
            this.txtDevMAC.Location = new System.Drawing.Point(105, 130);
            this.txtDevMAC.Margin = new System.Windows.Forms.Padding(2);
            this.txtDevMAC.Name = "txtDevMAC";
            this.txtDevMAC.Size = new System.Drawing.Size(151, 20);
            this.txtDevMAC.TabIndex = 15;
            // 
            // txtDevIMEI
            // 
            this.txtDevIMEI.Location = new System.Drawing.Point(105, 102);
            this.txtDevIMEI.Margin = new System.Windows.Forms.Padding(2);
            this.txtDevIMEI.Name = "txtDevIMEI";
            this.txtDevIMEI.Size = new System.Drawing.Size(151, 20);
            this.txtDevIMEI.TabIndex = 14;
            // 
            // txtDevModel
            // 
            this.txtDevModel.Location = new System.Drawing.Point(105, 73);
            this.txtDevModel.Margin = new System.Windows.Forms.Padding(2);
            this.txtDevModel.Name = "txtDevModel";
            this.txtDevModel.Size = new System.Drawing.Size(151, 20);
            this.txtDevModel.TabIndex = 13;
            // 
            // txtDevInventory
            // 
            this.txtDevInventory.Location = new System.Drawing.Point(105, 45);
            this.txtDevInventory.Margin = new System.Windows.Forms.Padding(2);
            this.txtDevInventory.Name = "txtDevInventory";
            this.txtDevInventory.Size = new System.Drawing.Size(151, 20);
            this.txtDevInventory.TabIndex = 12;
            // 
            // txtDevSerial
            // 
            this.txtDevSerial.Location = new System.Drawing.Point(105, 16);
            this.txtDevSerial.Margin = new System.Windows.Forms.Padding(2);
            this.txtDevSerial.Name = "txtDevSerial";
            this.txtDevSerial.Size = new System.Drawing.Size(151, 20);
            this.txtDevSerial.TabIndex = 11;
            // 
            // lblDevNotes
            // 
            this.lblDevNotes.AutoSize = true;
            this.lblDevNotes.Location = new System.Drawing.Point(338, 98);
            this.lblDevNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevNotes.Name = "lblDevNotes";
            this.lblDevNotes.Size = new System.Drawing.Size(42, 15);
            this.lblDevNotes.TabIndex = 10;
            this.lblDevNotes.Text = "Notes:";
            // 
            // lblDevEmployee
            // 
            this.lblDevEmployee.AutoSize = true;
            this.lblDevEmployee.Location = new System.Drawing.Point(338, 73);
            this.lblDevEmployee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevEmployee.Name = "lblDevEmployee";
            this.lblDevEmployee.Size = new System.Drawing.Size(77, 15);
            this.lblDevEmployee.TabIndex = 9;
            this.lblDevEmployee.Text = "Assigned To:";
            // 
            // lblDevStatus
            // 
            this.lblDevStatus.AutoSize = true;
            this.lblDevStatus.Location = new System.Drawing.Point(338, 45);
            this.lblDevStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevStatus.Name = "lblDevStatus";
            this.lblDevStatus.Size = new System.Drawing.Size(44, 15);
            this.lblDevStatus.TabIndex = 8;
            this.lblDevStatus.Text = "Status:";
            // 
            // lblDevType
            // 
            this.lblDevType.AutoSize = true;
            this.lblDevType.Location = new System.Drawing.Point(338, 16);
            this.lblDevType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevType.Name = "lblDevType";
            this.lblDevType.Size = new System.Drawing.Size(76, 15);
            this.lblDevType.TabIndex = 7;
            this.lblDevType.Text = "Device Type:";
            // 
            // lblDevLocation
            // 
            this.lblDevLocation.AutoSize = true;
            this.lblDevLocation.Location = new System.Drawing.Point(15, 158);
            this.lblDevLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevLocation.Name = "lblDevLocation";
            this.lblDevLocation.Size = new System.Drawing.Size(57, 15);
            this.lblDevLocation.TabIndex = 6;
            this.lblDevLocation.Text = "Location:";
            // 
            // lblDevMAC
            // 
            this.lblDevMAC.AutoSize = true;
            this.lblDevMAC.Location = new System.Drawing.Point(15, 130);
            this.lblDevMAC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevMAC.Name = "lblDevMAC";
            this.lblDevMAC.Size = new System.Drawing.Size(83, 15);
            this.lblDevMAC.TabIndex = 5;
            this.lblDevMAC.Text = "MAC Address:";
            // 
            // lblDevIMEI
            // 
            this.lblDevIMEI.AutoSize = true;
            this.lblDevIMEI.Location = new System.Drawing.Point(15, 102);
            this.lblDevIMEI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevIMEI.Name = "lblDevIMEI";
            this.lblDevIMEI.Size = new System.Drawing.Size(35, 15);
            this.lblDevIMEI.TabIndex = 4;
            this.lblDevIMEI.Text = "IMEI:";
            // 
            // lblDevModel
            // 
            this.lblDevModel.AutoSize = true;
            this.lblDevModel.Location = new System.Drawing.Point(15, 73);
            this.lblDevModel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevModel.Name = "lblDevModel";
            this.lblDevModel.Size = new System.Drawing.Size(45, 15);
            this.lblDevModel.TabIndex = 3;
            this.lblDevModel.Text = "Model:";
            // 
            // lblDevInventory
            // 
            this.lblDevInventory.AutoSize = true;
            this.lblDevInventory.Location = new System.Drawing.Point(15, 45);
            this.lblDevInventory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevInventory.Name = "lblDevInventory";
            this.lblDevInventory.Size = new System.Drawing.Size(106, 15);
            this.lblDevInventory.TabIndex = 2;
            this.lblDevInventory.Text = "Inventory Number:";
            // 
            // lblDevSerial
            // 
            this.lblDevSerial.AutoSize = true;
            this.lblDevSerial.Location = new System.Drawing.Point(15, 16);
            this.lblDevSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevSerial.Name = "lblDevSerial";
            this.lblDevSerial.Size = new System.Drawing.Size(90, 15);
            this.lblDevSerial.TabIndex = 1;
            this.lblDevSerial.Text = "Serial Number:";
            // 
            // chkDevMDM
            // 
            this.chkDevMDM.AutoSize = true;
            this.chkDevMDM.Location = new System.Drawing.Point(340, 167);
            this.chkDevMDM.Margin = new System.Windows.Forms.Padding(2);
            this.chkDevMDM.Name = "chkDevMDM";
            this.chkDevMDM.Size = new System.Drawing.Size(85, 19);
            this.chkDevMDM.TabIndex = 23;
            this.chkDevMDM.Text = "Has MDM";
            this.chkDevMDM.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDevice
            // 
            this.btnDeleteDevice.Location = new System.Drawing.Point(673, 211);
            this.btnDeleteDevice.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(90, 32);
            this.btnDeleteDevice.TabIndex = 3;
            this.btnDeleteDevice.Text = "Delete Device";
            this.btnDeleteDevice.UseVisualStyleBackColor = true;
            this.btnDeleteDevice.Click += new System.EventHandler(this.btnDeleteDevice_Click);
            // 
            // btnEditDevice
            // 
            this.btnEditDevice.Location = new System.Drawing.Point(320, 211);
            this.btnEditDevice.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditDevice.Name = "btnEditDevice";
            this.btnEditDevice.Size = new System.Drawing.Size(90, 32);
            this.btnEditDevice.TabIndex = 2;
            this.btnEditDevice.Text = "Edit Device";
            this.btnEditDevice.UseVisualStyleBackColor = true;
            this.btnEditDevice.Click += new System.EventHandler(this.btnEditDevice_Click);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(6, 211);
            this.btnAddDevice.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(90, 32);
            this.btnAddDevice.TabIndex = 1;
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // dgvDevices
            // 
            this.dgvDevices.AllowUserToAddRows = false;
            this.dgvDevices.AllowUserToDeleteRows = false;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDevices.Location = new System.Drawing.Point(0, 0);
            this.dgvDevices.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.ReadOnly = true;
            this.dgvDevices.RowHeadersWidth = 51;
            this.dgvDevices.RowTemplate.Height = 40;
            this.dgvDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevices.Size = new System.Drawing.Size(781, 203);
            this.dgvDevices.TabIndex = 0;
            this.dgvDevices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevices_CellClick);
            // 
            // tabBilling
            // 
            this.tabBilling.Controls.Add(this.dgvAllBilling);
            this.tabBilling.Controls.Add(this.btnExportBilling);
            this.tabBilling.Controls.Add(this.btnLoadBilling);
            this.tabBilling.Controls.Add(this.dtpBillingTo);
            this.tabBilling.Controls.Add(this.dtpBillingFrom);
            this.tabBilling.Controls.Add(this.lblBillingRange);
            this.tabBilling.Controls.Add(this.btnImportBilling);
            this.tabBilling.Controls.Add(this.txtBillingFile);
            this.tabBilling.Controls.Add(this.btnBillingBrowse);
            this.tabBilling.Location = new System.Drawing.Point(4, 22);
            this.tabBilling.Margin = new System.Windows.Forms.Padding(2);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Size = new System.Drawing.Size(781, 489);
            this.tabBilling.TabIndex = 3;
            this.tabBilling.Text = "Billing Management";
            this.tabBilling.UseVisualStyleBackColor = true;
            this.tabBilling.Click += new System.EventHandler(this.tabBilling_Click);
            // 
            // dgvAllBilling
            // 
            this.dgvAllBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllBilling.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAllBilling.Location = new System.Drawing.Point(0, 137);
            this.dgvAllBilling.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAllBilling.Name = "dgvAllBilling";
            this.dgvAllBilling.ReadOnly = true;
            this.dgvAllBilling.RowHeadersWidth = 51;
            this.dgvAllBilling.Size = new System.Drawing.Size(781, 352);
            this.dgvAllBilling.TabIndex = 9;
            // 
            // btnExportBilling
            // 
            this.btnExportBilling.Location = new System.Drawing.Point(652, 42);
            this.btnExportBilling.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportBilling.Name = "btnExportBilling";
            this.btnExportBilling.Size = new System.Drawing.Size(108, 32);
            this.btnExportBilling.TabIndex = 8;
            this.btnExportBilling.Text = "Export to CSV";
            this.btnExportBilling.UseVisualStyleBackColor = true;
            this.btnExportBilling.Click += new System.EventHandler(this.btnExportBilling_Click);
            // 
            // btnLoadBilling
            // 
            this.btnLoadBilling.Location = new System.Drawing.Point(354, 87);
            this.btnLoadBilling.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadBilling.Name = "btnLoadBilling";
            this.btnLoadBilling.Size = new System.Drawing.Size(90, 30);
            this.btnLoadBilling.TabIndex = 7;
            this.btnLoadBilling.Text = "Load Data";
            this.btnLoadBilling.UseVisualStyleBackColor = true;
            this.btnLoadBilling.Click += new System.EventHandler(this.btnLoadBilling_Click);
            // 
            // dtpBillingTo
            // 
            this.dtpBillingTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBillingTo.Location = new System.Drawing.Point(266, 91);
            this.dtpBillingTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtpBillingTo.Name = "dtpBillingTo";
            this.dtpBillingTo.Size = new System.Drawing.Size(84, 20);
            this.dtpBillingTo.TabIndex = 5;
            this.dtpBillingTo.ValueChanged += new System.EventHandler(this.dtpBillingTo_ValueChanged);
            // 
            // dtpBillingFrom
            // 
            this.dtpBillingFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBillingFrom.Location = new System.Drawing.Point(169, 91);
            this.dtpBillingFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpBillingFrom.Name = "dtpBillingFrom";
            this.dtpBillingFrom.Size = new System.Drawing.Size(84, 20);
            this.dtpBillingFrom.TabIndex = 4;
            this.dtpBillingFrom.ValueChanged += new System.EventHandler(this.dtpBillingFrom_ValueChanged);
            // 
            // lblBillingRange
            // 
            this.lblBillingRange.AutoSize = true;
            this.lblBillingRange.Location = new System.Drawing.Point(7, 91);
            this.lblBillingRange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBillingRange.Name = "lblBillingRange";
            this.lblBillingRange.Size = new System.Drawing.Size(147, 15);
            this.lblBillingRange.TabIndex = 6;
            this.lblBillingRange.Text = "Billing Range (From / To):";
            this.lblBillingRange.Click += new System.EventHandler(this.lblBillingRange_Click);
            // 
            // btnImportBilling
            // 
            this.btnImportBilling.Location = new System.Drawing.Point(514, 42);
            this.btnImportBilling.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportBilling.Name = "btnImportBilling";
            this.btnImportBilling.Size = new System.Drawing.Size(112, 32);
            this.btnImportBilling.TabIndex = 2;
            this.btnImportBilling.Text = "Import Billing";
            this.btnImportBilling.UseVisualStyleBackColor = true;
            this.btnImportBilling.Click += new System.EventHandler(this.btnImportBilling_Click);
            // 
            // txtBillingFile
            // 
            this.txtBillingFile.Location = new System.Drawing.Point(8, 49);
            this.txtBillingFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtBillingFile.Name = "txtBillingFile";
            this.txtBillingFile.ReadOnly = true;
            this.txtBillingFile.Size = new System.Drawing.Size(436, 20);
            this.txtBillingFile.TabIndex = 1;
            // 
            // btnBillingBrowse
            // 
            this.btnBillingBrowse.Location = new System.Drawing.Point(8, 12);
            this.btnBillingBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBillingBrowse.Name = "btnBillingBrowse";
            this.btnBillingBrowse.Size = new System.Drawing.Size(90, 24);
            this.btnBillingBrowse.TabIndex = 0;
            this.btnBillingBrowse.Text = "Browse...";
            this.btnBillingBrowse.UseVisualStyleBackColor = true;
            this.btnBillingBrowse.Click += new System.EventHandler(this.btnBillingBrowse_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 515);
            this.Controls.Add(this.tabAdmin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.tabAdmin.ResumeLayout(false);
            this.tabEmployees.ResumeLayout(false);
            this.panelEmployeeDetails.ResumeLayout(false);
            this.panelEmployeeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmpPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.tabDepartments.ResumeLayout(false);
            this.panelDepartmentDetails.ResumeLayout(false);
            this.panelDepartmentDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.tabDevices.ResumeLayout(false);
            this.panelDeviceDetails.ResumeLayout(false);
            this.panelDeviceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.tabBilling.ResumeLayout(false);
            this.tabBilling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBilling)).EndInit();
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

        // Department Controls
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Button btnEditDepartment;
        private System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.Panel panelDepartmentDetails;
        private System.Windows.Forms.TextBox txtDeptDescription;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label lblDeptDescription;
        private System.Windows.Forms.Label lblDeptName;

        // Device Controls
        private System.Windows.Forms.Button btnDeleteDevice;
        private System.Windows.Forms.Button btnEditDevice;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Panel panelDeviceDetails;
        private System.Windows.Forms.TextBox txtDevSerial;
        private System.Windows.Forms.TextBox txtDevInventory;
        private System.Windows.Forms.TextBox txtDevModel;
        private System.Windows.Forms.TextBox txtDevIMEI;
        private System.Windows.Forms.TextBox txtDevMAC;
        private System.Windows.Forms.TextBox txtDevLocation;
        private System.Windows.Forms.TextBox txtDevNotes;
        private System.Windows.Forms.ComboBox cmbDevType;
        private System.Windows.Forms.ComboBox cmbDevStatus;
        private System.Windows.Forms.ComboBox cmbDevEmployee;
        private System.Windows.Forms.DateTimePicker dtpDevIssue;
        private System.Windows.Forms.DateTimePicker dtpDevReplace;
        private System.Windows.Forms.CheckBox chkDevMDM;

        // Device Labels
        private System.Windows.Forms.Label lblDevSerial;
        private System.Windows.Forms.Label lblDevInventory;
        private System.Windows.Forms.Label lblDevModel;
        private System.Windows.Forms.Label lblDevIMEI;
        private System.Windows.Forms.Label lblDevMAC;
        private System.Windows.Forms.Label lblDevLocation;
        private System.Windows.Forms.Label lblDevType;
        private System.Windows.Forms.Label lblDevStatus;
        private System.Windows.Forms.Label lblDevEmployee;
        private System.Windows.Forms.Label lblDevNotes;

        // Billing Controls
        private System.Windows.Forms.Button btnImportBilling;
        private System.Windows.Forms.TextBox txtBillingFile;
        private System.Windows.Forms.Button btnBillingBrowse;
        private Label label6;
        private Label label7;

        private System.Windows.Forms.DateTimePicker dtpBillingFrom;
        private System.Windows.Forms.DateTimePicker dtpBillingTo;
        private System.Windows.Forms.Button btnLoadBilling;
        private System.Windows.Forms.Button btnExportBilling;
        private System.Windows.Forms.Label lblBillingRange;
        private System.Windows.Forms.DataGridView dgvAllBilling;

        //private readonly EventHandler btnAddDepartment_Click;

    }
}

/*using System.Windows.Forms;

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
            this.panelEmployeeDetails = new System.Windows.Forms.Panel();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.picEmpPhoto = new System.Windows.Forms.PictureBox();
            this.cmbEmpDepartment = new System.Windows.Forms.ComboBox();
            this.txtEmpMobile = new System.Windows.Forms.TextBox();
            this.txtEmpPhone = new System.Windows.Forms.TextBox();
            this.txtEmpEmail = new System.Windows.Forms.TextBox();
            this.txtEmpLastName = new System.Windows.Forms.TextBox();
            this.txtEmpFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.tabDepartments = new System.Windows.Forms.TabPage();
            this.tabDevices = new System.Windows.Forms.TabPage();
            this.tabBilling = new System.Windows.Forms.TabPage();
            this.tabAdmin.SuspendLayout();
            this.tabEmployees.SuspendLayout();
            this.panelEmployeeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmpPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
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
            // txtEmpMobile
            // 
            this.txtEmpMobile.Location = new System.Drawing.Point(894, 47);
            this.txtEmpMobile.Name = "txtEmpMobile";
            this.txtEmpMobile.Size = new System.Drawing.Size(121, 22);
            this.txtEmpMobile.TabIndex = 9;
            this.txtEmpMobile.TextChanged += new System.EventHandler(this.txtEmpMobile_TextChanged);
            // 
            // txtEmpPhone
            // 
            this.txtEmpPhone.Location = new System.Drawing.Point(735, 47);
            this.txtEmpPhone.Name = "txtEmpPhone";
            this.txtEmpPhone.Size = new System.Drawing.Size(114, 22);
            this.txtEmpPhone.TabIndex = 8;
            this.txtEmpPhone.TextChanged += new System.EventHandler(this.txtEmpPhone_TextChanged);
            // 
            // txtEmpEmail
            // 
            this.txtEmpEmail.Location = new System.Drawing.Point(534, 47);
            this.txtEmpEmail.Name = "txtEmpEmail";
            this.txtEmpEmail.Size = new System.Drawing.Size(170, 22);
            this.txtEmpEmail.TabIndex = 7;
            this.txtEmpEmail.TextChanged += new System.EventHandler(this.txtEmpEmail_TextChanged);
            // 
            // txtEmpLastName
            // 
            this.txtEmpLastName.Location = new System.Drawing.Point(348, 47);
            this.txtEmpLastName.Name = "txtEmpLastName";
            this.txtEmpLastName.Size = new System.Drawing.Size(177, 22);
            this.txtEmpLastName.TabIndex = 6;
            this.txtEmpLastName.TextChanged += new System.EventHandler(this.txtEmpLastName_TextChanged);
            // 
            // txtEmpFirstName
            // 
            this.txtEmpFirstName.Location = new System.Drawing.Point(184, 47);
            this.txtEmpFirstName.Name = "txtEmpFirstName";
            this.txtEmpFirstName.Size = new System.Drawing.Size(158, 22);
            this.txtEmpFirstName.TabIndex = 5;
            this.txtEmpFirstName.TextChanged += new System.EventHandler(this.txtEmpFirstName_TextChanged);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(732, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
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
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(897, 322);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(120, 52);
            this.btnDeleteEmployee.TabIndex = 3;
            this.btnDeleteEmployee.Text = "Delete Employee";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(426, 322);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(120, 52);
            this.btnEditEmployee.TabIndex = 2;
            this.btnEditEmployee.Text = "Edit Employee";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(8, 322);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(120, 52);
            this.btnAddEmployee.TabIndex = 1;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEmployees.Location = new System.Drawing.Point(3, 3);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.RowTemplate.Height = 250;
            this.dgvEmployees.Size = new System.Drawing.Size(1037, 313);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellContentClick);
            // 
            // tabDepartments
            // 
            this.tabDepartments.Location = new System.Drawing.Point(4, 25);
            this.tabDepartments.Name = "tabDepartments";
            this.tabDepartments.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepartments.Size = new System.Drawing.Size(1043, 563);
            this.tabDepartments.TabIndex = 1;
            this.tabDepartments.Text = "Departments";
            this.tabDepartments.UseVisualStyleBackColor = true;
            // 
            // tabDevices
            //
            this.tabDevices.Controls.Add(this.panelDeviceDetails);
            this.tabDevices.Controls.Add(this.btnDeleteDevice);
            this.tabDevices.Controls.Add(this.btnEditDevice);
            this.tabDevices.Controls.Add(this.btnAddDevice);
            this.tabDevices.Controls.Add(this.dgvDevices);
            this.tabDevices.Location = new System.Drawing.Point(4, 25);
            this.tabDevices.Name = "tabDevices";
            this.tabDevices.Size = new System.Drawing.Size(1043, 563);
            this.tabDevices.TabIndex = 2;
            this.tabDevices.Text = "Devices";
            this.tabDevices.UseVisualStyleBackColor = true;
            // ======================
            // DEVICES – DataGridView
            // ======================
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDevices.Location = new System.Drawing.Point(3, 3);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.RowHeadersWidth = 51;
            this.dgvDevices.RowTemplate.Height = 40;
            this.dgvDevices.Size = new System.Drawing.Size(1037, 250);
            this.dgvDevices.TabIndex = 0;
            this.dgvDevices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevices_CellClick);

            // ================
            // Buttons (bottom)
            // ================
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnAddDevice.Location = new System.Drawing.Point(10, 260);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(120, 40);
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);

            this.btnEditDevice = new System.Windows.Forms.Button();
            this.btnEditDevice.Location = new System.Drawing.Point(300, 260);
            this.btnEditDevice.Name = "btnEditDevice";
            this.btnEditDevice.Size = new System.Drawing.Size(120, 40);
            this.btnEditDevice.Text = "Edit Device";
            this.btnEditDevice.Click += new System.EventHandler(this.btnEditDevice_Click);

            this.btnDeleteDevice = new System.Windows.Forms.Button();
            this.btnDeleteDevice.Location = new System.Drawing.Point(600, 260);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteDevice.Text = "Delete Device";
            this.btnDeleteDevice.Click += new System.EventHandler(this.btnDeleteDevice_Click);

            // ========================================
            // PANEL Device Details (similar to Employee)
            // ========================================
            this.panelDeviceDetails = new System.Windows.Forms.Panel();
            this.panelDeviceDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDeviceDetails.Height = 260;
            this.panelDeviceDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Labels and Inputs
            this.txtDevSerial = new System.Windows.Forms.TextBox();
            this.txtDevSerial.Location = new System.Drawing.Point(140, 20);
            this.txtDevSerial.Size = new System.Drawing.Size(200, 22);

            this.txtDevInventory = new System.Windows.Forms.TextBox();
            this.txtDevInventory.Location = new System.Drawing.Point(140, 55);
            this.txtDevInventory.Size = new System.Drawing.Size(200, 22);

            this.txtDevModel = new System.Windows.Forms.TextBox();
            this.txtDevModel.Location = new System.Drawing.Point(140, 90);
            this.txtDevModel.Size = new System.Drawing.Size(200, 22);

            this.txtDevIMEI = new System.Windows.Forms.TextBox();
            this.txtDevIMEI.Location = new System.Drawing.Point(140, 125);
            this.txtDevIMEI.Size = new System.Drawing.Size(200, 22);

            this.txtDevMAC = new System.Windows.Forms.TextBox();
            this.txtDevMAC.Location = new System.Drawing.Point(140, 160);
            this.txtDevMAC.Size = new System.Drawing.Size(200, 22);

            this.txtDevLocation = new System.Windows.Forms.TextBox();
            this.txtDevLocation.Location = new System.Drawing.Point(140, 195);
            this.txtDevLocation.Size = new System.Drawing.Size(200, 22);

            // Notes
            this.txtDevNotes = new System.Windows.Forms.TextBox();
            this.txtDevNotes.Location = new System.Drawing.Point(580, 120);
            this.txtDevNotes.Multiline = true;
            this.txtDevNotes.Size = new System.Drawing.Size(300, 80);

            // Combo: Device Type
            this.cmbDevType = new System.Windows.Forms.ComboBox();
            this.cmbDevType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevType.Items.AddRange(new object[] {
    "Laptop",
    "Android",
    "iOS",
    "Desk Phone",
    "Tablet",
    "Desktop",
    "Router",
    "Other"
});
            this.cmbDevType.Location = new System.Drawing.Point(580, 20);
            this.cmbDevType.Size = new System.Drawing.Size(200, 24);

            // Combo: Status
            this.cmbDevStatus = new System.Windows.Forms.ComboBox();
            this.cmbDevStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevStatus.Items.AddRange(new object[] {
    "Active",
    "In Repair",
    "Returned",
    "Lost",
    "Deprecated",
    "In Storage"
});
            this.cmbDevStatus.Location = new System.Drawing.Point(580, 55);
            this.cmbDevStatus.Size = new System.Drawing.Size(200, 24);

            // Combo: Employee
            this.cmbDevEmployee = new System.Windows.Forms.ComboBox();
            this.cmbDevEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevEmployee.Location = new System.Drawing.Point(580, 90);
            this.cmbDevEmployee.Size = new System.Drawing.Size(200, 24);

            // Issue Date
            this.dtpDevIssue = new System.Windows.Forms.DateTimePicker();
            this.dtpDevIssue.Location = new System.Drawing.Point(140, 230);
            this.dtpDevIssue.Size = new System.Drawing.Size(200, 22);

            // Replacement Date
            this.dtpDevReplace = new System.Windows.Forms.DateTimePicker();
            this.dtpDevReplace.Location = new System.Drawing.Point(580, 230);
            this.dtpDevReplace.Size = new System.Drawing.Size(200, 22);

            // Checkbox (MDM)
            this.chkDevMDM = new System.Windows.Forms.CheckBox();
            this.chkDevMDM.Text = "Has MDM";
            this.chkDevMDM.Location = new System.Drawing.Point(580, 200);
            this.chkDevMDM.Size = new System.Drawing.Size(120, 20);

            // ---- Labels ----
            this.lblDevSerial = new System.Windows.Forms.Label();
            this.lblDevSerial.Text = "Serial Number:";
            this.lblDevSerial.Location = new System.Drawing.Point(20, 20);

            this.lblDevInventory = new System.Windows.Forms.Label();
            this.lblDevInventory.Text = "Inventory Number:";
            this.lblDevInventory.Location = new System.Drawing.Point(20, 55);

            this.lblDevModel = new System.Windows.Forms.Label();
            this.lblDevModel.Text = "Model:";
            this.lblDevModel.Location = new System.Drawing.Point(20, 90);

            this.lblDevIMEI = new System.Windows.Forms.Label();
            this.lblDevIMEI.Text = "IMEI:";
            this.lblDevIMEI.Location = new System.Drawing.Point(20, 125);

            this.lblDevMAC = new System.Windows.Forms.Label();
            this.lblDevMAC.Text = "MAC Address:";
            this.lblDevMAC.Location = new System.Drawing.Point(20, 160);

            this.lblDevLocation = new System.Windows.Forms.Label();
            this.lblDevLocation.Text = "Location:";
            this.lblDevLocation.Location = new System.Drawing.Point(20, 195);

            this.lblDevType = new System.Windows.Forms.Label();
            this.lblDevType.Text = "Device Type:";
            this.lblDevType.Location = new System.Drawing.Point(450, 20);

            this.lblDevStatus = new System.Windows.Forms.Label();
            this.lblDevStatus.Text = "Status:";
            this.lblDevStatus.Location = new System.Drawing.Point(450, 55);

            this.lblDevEmployee = new System.Windows.Forms.Label();
            this.lblDevEmployee.Text = "Assigned To:";
            this.lblDevEmployee.Location = new System.Drawing.Point(450, 90);

            this.lblDevNotes = new System.Windows.Forms.Label();
            this.lblDevNotes.Text = "Notes:";
            this.lblDevNotes.Location = new System.Drawing.Point(450, 120);

            // Add controls to device panel
            this.panelDeviceDetails.Controls.AddRange(new Control[] 
            {
                lblDevSerial, txtDevSerial,
                lblDevInventory, txtDevInventory,
                lbldevModel, txtDevModel,
                lblDevIMEI, txtDevIMEI,
                lblDevMAC, txtDevMAC,
                lblDevLocation, txtDevLocation,
                lblDevType, cmbDevType,
                lblDevStatus, cmbDevStatus,
                lblDevEmployee, cmbDevEmployee,
                lblDevNotes, txtDevNotes,
                dtpDevIssue, dtpDevReplace,
                chkDevMDM
            });

            // 
            // tabBilling
            // 
            this.tabBilling.Location = new System.Drawing.Point(4, 25);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Size = new System.Drawing.Size(1043, 563);
            this.tabBilling.TabIndex = 3;
            this.tabBilling.Text = "Billing Import";
            this.tabBilling.UseVisualStyleBackColor = true;
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
            this.panelEmployeeDetails.ResumeLayout(false);
            this.panelEmployeeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmpPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
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
        private System.Windows.Forms.TextBox txtDeptDescription;
        private System.Windows.Forms.Label txtDeptName;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Button btnBillingBrowse;
        private System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.Button btnEditDepartment;
        private System.Windows.Forms.Button btnDeleteDevice;
        private System.Windows.Forms.Button btnEditDevice;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.TextBox txtBillingFile;
        private System.Windows.Forms.Button btnImportBilling;
        // Devices
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnEditDevice;
        private System.Windows.Forms.Button btnDeleteDevice;
        private System.Windows.Forms.Panel panelDeviceDetails;

        private System.Windows.Forms.TextBox txtDevSerial;
        private System.Windows.Forms.TextBox txtDevInventory;
        private System.Windows.Forms.TextBox txtDevModel;
        private System.Windows.Forms.TextBox txtDevIMEI;
        private System.Windows.Forms.TextBox txtDevMAC;
        private System.Windows.Forms.TextBox txtDevLocation;
        private System.Windows.Forms.TextBox txtDevNotes;

        private System.Windows.Forms.ComboBox cmbDevType;
        private System.Windows.Forms.ComboBox cmbDevStatus;
        private System.Windows.Forms.ComboBox cmbDevEmployee;

        private System.Windows.Forms.DateTimePicker dtpDevIssue;
        private System.Windows.Forms.DateTimePicker dtpDevReplace;

        private System.Windows.Forms.CheckBox chkDevMDM;

        // Labels
        private System.Windows.Forms.Label lblDevSerial;
        private System.Windows.Forms.Label lblDevInventory;
        private System.Windows.Forms.Label lblDevModel;
        private System.Windows.Forms.Label lblDevIMEI;
        private System.Windows.Forms.Label lblDevMAC;
        private System.Windows.Forms.Label lblDevLocation;
        private System.Windows.Forms.Label lblDevType;
        private System.Windows.Forms.Label lblDevStatus;
        private System.Windows.Forms.Label lblDevEmployee;
        private System.Windows.Forms.Label lblDevNotes;

    }
}
*/