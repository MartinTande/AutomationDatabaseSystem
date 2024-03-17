namespace AutomationSystem
{
    partial class EditObjectForm
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
            txtBoxName = new TextBox();
            comboBoxOtd = new ComboBox();
            comboBoxEasGroup = new ComboBox();
            comboBoxHierarchy2 = new ComboBox();
            comboBoxHierarchy1 = new ComboBox();
            comboBoxObjectType = new ComboBox();
            btnCancel = new Button();
            btnOK = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(47, 93);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(588, 35);
            txtBoxName.TabIndex = 19;
            // 
            // comboBoxOtd
            // 
            comboBoxOtd.FormattingEnabled = true;
            comboBoxOtd.Location = new Point(47, 554);
            comboBoxOtd.Name = "comboBoxOtd";
            comboBoxOtd.Size = new Size(589, 38);
            comboBoxOtd.TabIndex = 14;
            // 
            // comboBoxEasGroup
            // 
            comboBoxEasGroup.FormattingEnabled = true;
            comboBoxEasGroup.Location = new Point(47, 445);
            comboBoxEasGroup.Name = "comboBoxEasGroup";
            comboBoxEasGroup.Size = new Size(589, 38);
            comboBoxEasGroup.TabIndex = 15;
            // 
            // comboBoxHierarchy2
            // 
            comboBoxHierarchy2.FormattingEnabled = true;
            comboBoxHierarchy2.Location = new Point(47, 355);
            comboBoxHierarchy2.Name = "comboBoxHierarchy2";
            comboBoxHierarchy2.Size = new Size(589, 38);
            comboBoxHierarchy2.TabIndex = 16;
            // 
            // comboBoxHierarchy1
            // 
            comboBoxHierarchy1.FormattingEnabled = true;
            comboBoxHierarchy1.Location = new Point(47, 257);
            comboBoxHierarchy1.Name = "comboBoxHierarchy1";
            comboBoxHierarchy1.Size = new Size(589, 38);
            comboBoxHierarchy1.TabIndex = 17;
            // 
            // comboBoxObjectType
            // 
            comboBoxObjectType.FormattingEnabled = true;
            comboBoxObjectType.Location = new Point(46, 174);
            comboBoxObjectType.Name = "comboBoxObjectType";
            comboBoxObjectType.Size = new Size(589, 38);
            comboBoxObjectType.TabIndex = 18;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(508, 684);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 40);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(361, 684);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(131, 40);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 512);
            label7.Name = "label7";
            label7.Size = new Size(54, 30);
            label7.TabIndex = 6;
            label7.Text = "OTD";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 412);
            label6.Name = "label6";
            label6.Size = new Size(112, 30);
            label6.TabIndex = 7;
            label6.Text = "EAS Group";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 322);
            label5.Name = "label5";
            label5.Size = new Size(118, 30);
            label5.TabIndex = 8;
            label5.Text = "Hierarchy 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 224);
            label4.Name = "label4";
            label4.Size = new Size(118, 30);
            label4.TabIndex = 9;
            label4.Text = "Hierarchy 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 141);
            label3.Name = "label3";
            label3.Size = new Size(123, 30);
            label3.TabIndex = 10;
            label3.Text = "Object Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 60);
            label2.Name = "label2";
            label2.Size = new Size(69, 30);
            label2.TabIndex = 11;
            label2.Text = "Name";
            // 
            // EditObjectForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 795);
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
            Name = "EditObjectForm";
            Text = "EditObjectForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxName;
        private ComboBox comboBoxOtd;
        private ComboBox comboBoxEasGroup;
        private ComboBox comboBoxHierarchy2;
        private ComboBox comboBoxHierarchy1;
        private ComboBox comboBoxObjectType;
        private Button btnCancel;
        private Button btnOK;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}