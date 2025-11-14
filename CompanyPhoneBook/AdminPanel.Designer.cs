namespace CompanyPhoneBook
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
            LogiTab = new TabPage();
            BillingTab = new TabPage();
            DevicesTab = new TabPage();
            EmployeesTab = new TabPage();
            tabControl1 = new TabControl();
            dataGridView1 = new DataGridView();
            pracownik = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            gridEmployees = new DataGridViewTextBoxColumn();
            btnAddEmployee = new Button();
            btnEditEmployee = new Button();
            btnDeleteEmployee = new Button();
            btnRefreshEmployees = new Button();
            BillingTab.SuspendLayout();
            DevicesTab.SuspendLayout();
            EmployeesTab.SuspendLayout();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // LogiTab
            // 
            LogiTab.Location = new Point(4, 29);
            LogiTab.Name = "LogiTab";
            LogiTab.Size = new Size(654, 171);
            LogiTab.TabIndex = 3;
            LogiTab.Text = "Logi Systemowe";
            LogiTab.UseVisualStyleBackColor = true;
            // 
            // BillingTab
            // 
            BillingTab.Controls.Add(dataGridView2);
            BillingTab.Location = new Point(4, 37);
            BillingTab.Name = "BillingTab";
            BillingTab.Size = new Size(465, 246);
            BillingTab.TabIndex = 2;
            BillingTab.Text = "Bilingi";
            BillingTab.UseVisualStyleBackColor = true;
            // 
            // DevicesTab
            // 
            DevicesTab.Controls.Add(button8);
            DevicesTab.Controls.Add(button7);
            DevicesTab.Controls.Add(button6);
            DevicesTab.Controls.Add(dataGridView1);
            DevicesTab.Location = new Point(4, 37);
            DevicesTab.Name = "DevicesTab";
            DevicesTab.Padding = new Padding(3);
            DevicesTab.Size = new Size(486, 248);
            DevicesTab.TabIndex = 1;
            DevicesTab.Text = "Urządzenia";
            DevicesTab.UseVisualStyleBackColor = true;
            // 
            // EmployeesTab
            // 
            EmployeesTab.Controls.Add(btnRefreshEmployees);
            EmployeesTab.Controls.Add(btnDeleteEmployee);
            EmployeesTab.Controls.Add(btnEditEmployee);
            EmployeesTab.Controls.Add(btnAddEmployee);
            EmployeesTab.Controls.Add(dataGridView3);
            EmployeesTab.Location = new Point(4, 37);
            EmployeesTab.Name = "EmployeesTab";
            EmployeesTab.Padding = new Padding(3);
            EmployeesTab.Size = new Size(486, 248);
            EmployeesTab.TabIndex = 0;
            EmployeesTab.Text = "Pracownicy";
            EmployeesTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(EmployeesTab);
            tabControl1.Controls.Add(DevicesTab);
            tabControl1.Controls.Add(BillingTab);
            tabControl1.Controls.Add(LogiTab);
            tabControl1.Font = new Font("Segoe UI", 12F);
            tabControl1.Location = new Point(0, -11);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(494, 289);
            tabControl1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { pracownik, status });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(480, 242);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // pracownik
            // 
            pracownik.HeaderText = "pracownik";
            pracownik.MinimumWidth = 6;
            pracownik.Name = "pracownik";
            pracownik.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.Width = 125;
            // 
            // button6
            // 
            button6.Location = new Point(3, 70);
            button6.Name = "button6";
            button6.Size = new Size(302, 51);
            button6.TabIndex = 1;
            button6.Text = "Dodaj urządzenie";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(3, 127);
            button7.Name = "button7";
            button7.Size = new Size(302, 51);
            button7.TabIndex = 2;
            button7.Text = "Edytuj urządzenie";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(3, 184);
            button8.Name = "button8";
            button8.Size = new Size(302, 51);
            button8.TabIndex = 3;
            button8.Text = "Przypisz / Odepnij";
            button8.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(8, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(300, 188);
            dataGridView2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { gridEmployees });
            dataGridView3.Dock = DockStyle.Top;
            dataGridView3.Location = new Point(3, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(480, 247);
            dataGridView3.TabIndex = 0;
            // 
            // gridEmployees
            // 
            gridEmployees.HeaderText = "lista";
            gridEmployees.MinimumWidth = 6;
            gridEmployees.Name = "gridEmployees";
            gridEmployees.Width = 125;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Location = new Point(10, 203);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(113, 40);
            btnAddEmployee.TabIndex = 1;
            btnAddEmployee.Text = "Dodaj";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += button5_Click;
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.Location = new Point(129, 203);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(113, 40);
            btnEditEmployee.TabIndex = 2;
            btnEditEmployee.Text = "Edytuj";
            btnEditEmployee.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEmployee
            // 
            btnDeleteEmployee.Location = new Point(248, 203);
            btnDeleteEmployee.Name = "btnDeleteEmployee";
            btnDeleteEmployee.Size = new Size(113, 40);
            btnDeleteEmployee.TabIndex = 3;
            btnDeleteEmployee.Text = "Usuń";
            btnDeleteEmployee.UseVisualStyleBackColor = true;
            // 
            // btnRefreshEmployees
            // 
            btnRefreshEmployees.Location = new Point(367, 203);
            btnRefreshEmployees.Name = "btnRefreshEmployees";
            btnRefreshEmployees.Size = new Size(113, 40);
            btnRefreshEmployees.TabIndex = 4;
            btnRefreshEmployees.Text = "Odśwież";
            btnRefreshEmployees.UseVisualStyleBackColor = true;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "AdminPanel";
            Text = "AdminPanel";
            BillingTab.ResumeLayout(false);
            DevicesTab.ResumeLayout(false);
            EmployeesTab.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabPage LogiTab;
        private TabPage BillingTab;
        private TabPage DevicesTab;
        private TabPage EmployeesTab;
        private TabControl tabControl1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn pracownik;
        private DataGridViewTextBoxColumn status;
        private Button button6;
        private Button button7;
        private Button button8;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn gridEmployees;
        private Button btnAddEmployee;
        private Button btnRefreshEmployees;
        private Button btnDeleteEmployee;
        private Button btnEditEmployee;
    }
}