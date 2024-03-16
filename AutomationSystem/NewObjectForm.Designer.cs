namespace AutomationSystem
{
    partial class NewObjectForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            comboBoxObjectType = new ComboBox();
            comboBoxHierarchy1 = new ComboBox();
            comboBoxHierarchy2 = new ComboBox();
            comboBoxEasGroup = new ComboBox();
            comboBoxOtd = new ComboBox();
            txtBoxName = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 60);
            label2.Name = "label2";
            label2.Size = new Size(69, 30);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 141);
            label3.Name = "label3";
            label3.Size = new Size(123, 30);
            label3.TabIndex = 1;
            label3.Text = "Object Type";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 224);
            label4.Name = "label4";
            label4.Size = new Size(118, 30);
            label4.TabIndex = 1;
            label4.Text = "Hierarchy 1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 322);
            label5.Name = "label5";
            label5.Size = new Size(118, 30);
            label5.TabIndex = 1;
            label5.Text = "Hierarchy 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 412);
            label6.Name = "label6";
            label6.Size = new Size(112, 30);
            label6.TabIndex = 1;
            label6.Text = "EAS Group";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(42, 512);
            label7.Name = "label7";
            label7.Size = new Size(54, 30);
            label7.TabIndex = 1;
            label7.Text = "OTD";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(386, 684);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(131, 40);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(533, 684);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // comboBoxObjectType
            // 
            comboBoxObjectType.FormattingEnabled = true;
            comboBoxObjectType.Location = new Point(44, 174);
            comboBoxObjectType.Name = "comboBoxObjectType";
            comboBoxObjectType.Size = new Size(589, 38);
            comboBoxObjectType.TabIndex = 4;
            // 
            // comboBoxHierarchy1
            // 
            comboBoxHierarchy1.FormattingEnabled = true;
            comboBoxHierarchy1.Location = new Point(45, 257);
            comboBoxHierarchy1.Name = "comboBoxHierarchy1";
            comboBoxHierarchy1.Size = new Size(589, 38);
            comboBoxHierarchy1.TabIndex = 4;
            // 
            // comboBoxHierarchy2
            // 
            comboBoxHierarchy2.FormattingEnabled = true;
            comboBoxHierarchy2.Location = new Point(45, 355);
            comboBoxHierarchy2.Name = "comboBoxHierarchy2";
            comboBoxHierarchy2.Size = new Size(589, 38);
            comboBoxHierarchy2.TabIndex = 4;
            // 
            // comboBoxEasGroup
            // 
            comboBoxEasGroup.FormattingEnabled = true;
            comboBoxEasGroup.Location = new Point(45, 445);
            comboBoxEasGroup.Name = "comboBoxEasGroup";
            comboBoxEasGroup.Size = new Size(589, 38);
            comboBoxEasGroup.TabIndex = 4;
            // 
            // comboBoxOtd
            // 
            comboBoxOtd.FormattingEnabled = true;
            comboBoxOtd.Location = new Point(45, 554);
            comboBoxOtd.Name = "comboBoxOtd";
            comboBoxOtd.Size = new Size(589, 38);
            comboBoxOtd.TabIndex = 4;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(45, 93);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(588, 35);
            txtBoxName.TabIndex = 5;
            // 
            // NewObjectForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 778);
            Controls.Add(txtBoxName);
            Controls.Add(comboBoxOtd);
            Controls.Add(comboBoxEasGroup);
            Controls.Add(comboBoxHierarchy2);
            Controls.Add(comboBoxHierarchy1);
            Controls.Add(comboBoxObjectType);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NewObjectForm";
            Text = "New Object";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnOK;
        private Button btnCancel;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ComboBox comboBoxObjectType;
        private ComboBox comboBoxHierarchy1;
        private ComboBox comboBoxHierarchy2;
        private ComboBox comboBoxEasGroup;
        private ComboBox comboBoxOtd;
        private TextBox txtBoxName;
    }
}