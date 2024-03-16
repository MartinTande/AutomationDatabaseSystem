namespace AutomationSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtObjectName = new TextBox();
            ObjectName = new Label();
            label2 = new Label();
            btnSave = new Button();
            comboObjectType = new ComboBox();
            dataGridViewObjectTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjectTable).BeginInit();
            SuspendLayout();
            // 
            // txtObjectName
            // 
            txtObjectName.Location = new Point(41, 982);
            txtObjectName.Name = "txtObjectName";
            txtObjectName.Size = new Size(430, 35);
            txtObjectName.TabIndex = 0;
            // 
            // ObjectName
            // 
            ObjectName.AutoSize = true;
            ObjectName.Location = new Point(45, 948);
            ObjectName.Name = "ObjectName";
            ObjectName.Size = new Size(136, 30);
            ObjectName.TabIndex = 2;
            ObjectName.Text = "Object Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 1083);
            label2.Name = "label2";
            label2.Size = new Size(123, 30);
            label2.TabIndex = 3;
            label2.Text = "Object Type";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(41, 1211);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 40);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // comboObjectType
            // 
            comboObjectType.FormattingEnabled = true;
            comboObjectType.Location = new Point(41, 1126);
            comboObjectType.Name = "comboObjectType";
            comboObjectType.Size = new Size(431, 38);
            comboObjectType.TabIndex = 5;
            // 
            // dataGridViewObjectTable
            // 
            dataGridViewObjectTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewObjectTable.Location = new Point(41, 58);
            dataGridViewObjectTable.Name = "dataGridViewObjectTable";
            dataGridViewObjectTable.RowHeadersWidth = 72;
            dataGridViewObjectTable.Size = new Size(2187, 689);
            dataGridViewObjectTable.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2273, 1325);
            Controls.Add(dataGridViewObjectTable);
            Controls.Add(comboObjectType);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(ObjectName);
            Controls.Add(txtObjectName);
            Name = "MainForm";
            Text = "Automation System";
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjectTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtObjectName;
        private Label ObjectName;
        private Label label2;
        private Button btnSave;
        private ComboBox comboObjectType;
        private DataGridView dataGridViewObjectTable;
    }
}
