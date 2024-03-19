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
            comboBoxHierarchy1 = new ComboBox();
            comboBoxHierarchy2 = new ComboBox();
            comboBoxVduGroup = new ComboBox();
            comboBoxOtd = new ComboBox();
            txtSfiNumber = new TextBox();
            txtObjectDescription = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            comboBoxAlarmGroup = new ComboBox();
            label11 = new Label();
            comboBoxAcknowledgeAllowed = new ComboBox();
            label12 = new Label();
            comboBoxAlwaysVisible = new ComboBox();
            label13 = new Label();
            comboBoxNode = new ComboBox();
            label14 = new Label();
            comboBoxCabinet = new ComboBox();
            txtMainEqNumber = new TextBox();
            txtEqNumber = new TextBox();
            label15 = new Label();
            txtDataBlock = new TextBox();
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
            label2.Size = new Size(122, 30);
            label2.TabIndex = 1;
            label2.Text = "SFI Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 149);
            label3.Name = "label3";
            label3.Size = new Size(185, 30);
            label3.TabIndex = 1;
            label3.Text = "Object Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 236);
            label4.Name = "label4";
            label4.Size = new Size(118, 30);
            label4.TabIndex = 1;
            label4.Text = "Hierarchy 1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(393, 236);
            label5.Name = "label5";
            label5.Size = new Size(118, 30);
            label5.TabIndex = 1;
            label5.Text = "Hierarchy 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 319);
            label6.Name = "label6";
            label6.Size = new Size(118, 30);
            label6.TabIndex = 1;
            label6.Text = "VDU Group";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(41, 404);
            label7.Name = "label7";
            label7.Size = new Size(54, 30);
            label7.TabIndex = 1;
            label7.Text = "OTD";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(455, 852);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(131, 40);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(601, 852);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // comboBoxHierarchy1
            // 
            comboBoxHierarchy1.FormattingEnabled = true;
            comboBoxHierarchy1.Location = new Point(45, 269);
            comboBoxHierarchy1.Name = "comboBoxHierarchy1";
            comboBoxHierarchy1.Size = new Size(339, 38);
            comboBoxHierarchy1.TabIndex = 4;
            comboBoxHierarchy1.TextChanged += comboBoxHierarchy1_TextChanged;
            // 
            // comboBoxHierarchy2
            // 
            comboBoxHierarchy2.FormattingEnabled = true;
            comboBoxHierarchy2.Location = new Point(393, 269);
            comboBoxHierarchy2.Name = "comboBoxHierarchy2";
            comboBoxHierarchy2.Size = new Size(339, 38);
            comboBoxHierarchy2.TabIndex = 4;
            // 
            // comboBoxVduGroup
            // 
            comboBoxVduGroup.FormattingEnabled = true;
            comboBoxVduGroup.Location = new Point(44, 352);
            comboBoxVduGroup.Name = "comboBoxVduGroup";
            comboBoxVduGroup.Size = new Size(339, 38);
            comboBoxVduGroup.TabIndex = 4;
            // 
            // comboBoxOtd
            // 
            comboBoxOtd.FormattingEnabled = true;
            comboBoxOtd.Location = new Point(44, 438);
            comboBoxOtd.Name = "comboBoxOtd";
            comboBoxOtd.Size = new Size(688, 38);
            comboBoxOtd.TabIndex = 4;
            // 
            // txtSfiNumber
            // 
            txtSfiNumber.Location = new Point(45, 93);
            txtSfiNumber.Name = "txtSfiNumber";
            txtSfiNumber.Size = new Size(213, 35);
            txtSfiNumber.TabIndex = 5;
            // 
            // txtObjectDescription
            // 
            txtObjectDescription.Location = new Point(44, 186);
            txtObjectDescription.Name = "txtObjectDescription";
            txtObjectDescription.Size = new Size(688, 35);
            txtObjectDescription.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(278, 60);
            label8.Name = "label8";
            label8.Size = new Size(171, 30);
            label8.TabIndex = 1;
            label8.Text = "Main Eq Number";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(519, 60);
            label9.Name = "label9";
            label9.Size = new Size(118, 30);
            label9.TabIndex = 1;
            label9.Text = "Eq Number";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(392, 319);
            label10.Name = "label10";
            label10.Size = new Size(131, 30);
            label10.TabIndex = 1;
            label10.Text = "Alarm Group";
            // 
            // comboBoxAlarmGroup
            // 
            comboBoxAlarmGroup.FormattingEnabled = true;
            comboBoxAlarmGroup.Location = new Point(394, 352);
            comboBoxAlarmGroup.Name = "comboBoxAlarmGroup";
            comboBoxAlarmGroup.Size = new Size(338, 38);
            comboBoxAlarmGroup.TabIndex = 4;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(41, 491);
            label11.Name = "label11";
            label11.Size = new Size(217, 30);
            label11.TabIndex = 1;
            label11.Text = "Acknowledge Allowed";
            // 
            // comboBoxAcknowledgeAllowed
            // 
            comboBoxAcknowledgeAllowed.FormattingEnabled = true;
            comboBoxAcknowledgeAllowed.Location = new Point(44, 526);
            comboBoxAcknowledgeAllowed.Name = "comboBoxAcknowledgeAllowed";
            comboBoxAcknowledgeAllowed.Size = new Size(688, 38);
            comboBoxAcknowledgeAllowed.TabIndex = 4;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(42, 583);
            label12.Name = "label12";
            label12.Size = new Size(143, 30);
            label12.TabIndex = 1;
            label12.Text = "Always Visible";
            // 
            // comboBoxAlwaysVisible
            // 
            comboBoxAlwaysVisible.FormattingEnabled = true;
            comboBoxAlwaysVisible.Location = new Point(45, 617);
            comboBoxAlwaysVisible.Name = "comboBoxAlwaysVisible";
            comboBoxAlwaysVisible.Size = new Size(687, 38);
            comboBoxAlwaysVisible.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(42, 670);
            label13.Name = "label13";
            label13.Size = new Size(64, 30);
            label13.TabIndex = 1;
            label13.Text = "Node";
            // 
            // comboBoxNode
            // 
            comboBoxNode.FormattingEnabled = true;
            comboBoxNode.Location = new Point(45, 705);
            comboBoxNode.Name = "comboBoxNode";
            comboBoxNode.Size = new Size(338, 38);
            comboBoxNode.TabIndex = 4;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(397, 670);
            label14.Name = "label14";
            label14.Size = new Size(84, 30);
            label14.TabIndex = 1;
            label14.Text = "Cabinet";
            // 
            // comboBoxCabinet
            // 
            comboBoxCabinet.FormattingEnabled = true;
            comboBoxCabinet.Location = new Point(397, 705);
            comboBoxCabinet.Name = "comboBoxCabinet";
            comboBoxCabinet.Size = new Size(335, 38);
            comboBoxCabinet.TabIndex = 4;
            // 
            // txtMainEqNumber
            // 
            txtMainEqNumber.Location = new Point(282, 93);
            txtMainEqNumber.Name = "txtMainEqNumber";
            txtMainEqNumber.Size = new Size(213, 35);
            txtMainEqNumber.TabIndex = 5;
            // 
            // txtEqNumber
            // 
            txtEqNumber.Location = new Point(519, 93);
            txtEqNumber.Name = "txtEqNumber";
            txtEqNumber.Size = new Size(213, 35);
            txtEqNumber.TabIndex = 5;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(41, 751);
            label15.Name = "label15";
            label15.Size = new Size(174, 30);
            label15.TabIndex = 1;
            label15.Text = "Data Block Name";
            // 
            // txtDataBlock
            // 
            txtDataBlock.Location = new Point(41, 788);
            txtDataBlock.Name = "txtDataBlock";
            txtDataBlock.Size = new Size(688, 35);
            txtDataBlock.TabIndex = 5;
            // 
            // NewObjectForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 948);
            Controls.Add(txtDataBlock);
            Controls.Add(txtObjectDescription);
            Controls.Add(txtEqNumber);
            Controls.Add(txtMainEqNumber);
            Controls.Add(txtSfiNumber);
            Controls.Add(comboBoxCabinet);
            Controls.Add(comboBoxNode);
            Controls.Add(comboBoxAlwaysVisible);
            Controls.Add(comboBoxAcknowledgeAllowed);
            Controls.Add(comboBoxOtd);
            Controls.Add(comboBoxAlarmGroup);
            Controls.Add(comboBoxVduGroup);
            Controls.Add(comboBoxHierarchy2);
            Controls.Add(label14);
            Controls.Add(comboBoxHierarchy1);
            Controls.Add(label13);
            Controls.Add(btnCancel);
            Controls.Add(label12);
            Controls.Add(btnOK);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label9);
            Controls.Add(label4);
            Controls.Add(label15);
            Controls.Add(label8);
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
        private ComboBox comboBoxHierarchy1;
        private ComboBox comboBoxHierarchy2;
        private ComboBox comboBoxVduGroup;
        private ComboBox comboBoxOtd;
        private TextBox txtSfiNumber;
        private TextBox txtObjectDescription;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox comboBoxAlarmGroup;
        private Label label11;
        private ComboBox comboBoxAcknowledgeAllowed;
        private Label label12;
        private ComboBox comboBoxAlwaysVisible;
        private Label label13;
        private ComboBox comboBoxNode;
        private Label label14;
        private ComboBox comboBoxCabinet;
        private TextBox txtMainEqNumber;
        private TextBox txtEqNumber;
        private Label label15;
        private TextBox txtDataBlock;
    }
}