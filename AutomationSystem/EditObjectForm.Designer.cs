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
            txtDataBlock = new TextBox();
            txtObjectDescription = new TextBox();
            txtEqNumber = new TextBox();
            txtMainEqNumber = new TextBox();
            txtSfiNumber = new TextBox();
            comboBoxCabinet = new ComboBox();
            comboBoxNode = new ComboBox();
            comboBoxAlwaysVisible = new ComboBox();
            comboBoxAcknowledgeAllowed = new ComboBox();
            comboBoxOtd = new ComboBox();
            comboBoxAlarmGroup = new ComboBox();
            comboBoxVduGroup = new ComboBox();
            comboBoxHierarchy2 = new ComboBox();
            label14 = new Label();
            comboBoxHierarchy1 = new ComboBox();
            label13 = new Label();
            btnCancel = new Button();
            label12 = new Label();
            btnOK = new Button();
            label11 = new Label();
            label10 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label9 = new Label();
            label4 = new Label();
            label15 = new Label();
            label8 = new Label();
            label3 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtDataBlock
            // 
            txtDataBlock.Location = new Point(32, 775);
            txtDataBlock.Name = "txtDataBlock";
            txtDataBlock.Size = new Size(688, 35);
            txtDataBlock.TabIndex = 44;
            // 
            // txtObjectDescription
            // 
            txtObjectDescription.Location = new Point(35, 173);
            txtObjectDescription.Name = "txtObjectDescription";
            txtObjectDescription.Size = new Size(688, 35);
            txtObjectDescription.TabIndex = 34;
            // 
            // txtEqNumber
            // 
            txtEqNumber.Location = new Point(510, 80);
            txtEqNumber.Name = "txtEqNumber";
            txtEqNumber.Size = new Size(213, 35);
            txtEqNumber.TabIndex = 33;
            // 
            // txtMainEqNumber
            // 
            txtMainEqNumber.Location = new Point(273, 80);
            txtMainEqNumber.Name = "txtMainEqNumber";
            txtMainEqNumber.Size = new Size(213, 35);
            txtMainEqNumber.TabIndex = 32;
            // 
            // txtSfiNumber
            // 
            txtSfiNumber.Location = new Point(36, 80);
            txtSfiNumber.Name = "txtSfiNumber";
            txtSfiNumber.Size = new Size(213, 35);
            txtSfiNumber.TabIndex = 29;
            // 
            // comboBoxCabinet
            // 
            comboBoxCabinet.FormattingEnabled = true;
            comboBoxCabinet.Location = new Point(388, 692);
            comboBoxCabinet.Name = "comboBoxCabinet";
            comboBoxCabinet.Size = new Size(335, 38);
            comboBoxCabinet.TabIndex = 43;
            // 
            // comboBoxNode
            // 
            comboBoxNode.FormattingEnabled = true;
            comboBoxNode.Location = new Point(36, 692);
            comboBoxNode.Name = "comboBoxNode";
            comboBoxNode.Size = new Size(338, 38);
            comboBoxNode.TabIndex = 42;
            // 
            // comboBoxAlwaysVisible
            // 
            comboBoxAlwaysVisible.FormattingEnabled = true;
            comboBoxAlwaysVisible.Location = new Point(36, 604);
            comboBoxAlwaysVisible.Name = "comboBoxAlwaysVisible";
            comboBoxAlwaysVisible.Size = new Size(687, 38);
            comboBoxAlwaysVisible.TabIndex = 41;
            // 
            // comboBoxAcknowledgeAllowed
            // 
            comboBoxAcknowledgeAllowed.FormattingEnabled = true;
            comboBoxAcknowledgeAllowed.Location = new Point(35, 513);
            comboBoxAcknowledgeAllowed.Name = "comboBoxAcknowledgeAllowed";
            comboBoxAcknowledgeAllowed.Size = new Size(688, 38);
            comboBoxAcknowledgeAllowed.TabIndex = 40;
            // 
            // comboBoxOtd
            // 
            comboBoxOtd.FormattingEnabled = true;
            comboBoxOtd.Location = new Point(35, 425);
            comboBoxOtd.Name = "comboBoxOtd";
            comboBoxOtd.Size = new Size(688, 38);
            comboBoxOtd.TabIndex = 39;
            // 
            // comboBoxAlarmGroup
            // 
            comboBoxAlarmGroup.FormattingEnabled = true;
            comboBoxAlarmGroup.Location = new Point(385, 339);
            comboBoxAlarmGroup.Name = "comboBoxAlarmGroup";
            comboBoxAlarmGroup.Size = new Size(338, 38);
            comboBoxAlarmGroup.TabIndex = 38;
            // 
            // comboBoxVduGroup
            // 
            comboBoxVduGroup.FormattingEnabled = true;
            comboBoxVduGroup.Location = new Point(35, 339);
            comboBoxVduGroup.Name = "comboBoxVduGroup";
            comboBoxVduGroup.Size = new Size(339, 38);
            comboBoxVduGroup.TabIndex = 37;
            // 
            // comboBoxHierarchy2
            // 
            comboBoxHierarchy2.FormattingEnabled = true;
            comboBoxHierarchy2.Location = new Point(384, 256);
            comboBoxHierarchy2.Name = "comboBoxHierarchy2";
            comboBoxHierarchy2.Size = new Size(339, 38);
            comboBoxHierarchy2.TabIndex = 36;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(388, 657);
            label14.Name = "label14";
            label14.Size = new Size(84, 30);
            label14.TabIndex = 20;
            label14.Text = "Cabinet";
            // 
            // comboBoxHierarchy1
            // 
            comboBoxHierarchy1.FormattingEnabled = true;
            comboBoxHierarchy1.Location = new Point(36, 256);
            comboBoxHierarchy1.Name = "comboBoxHierarchy1";
            comboBoxHierarchy1.Size = new Size(339, 38);
            comboBoxHierarchy1.TabIndex = 35;
            comboBoxHierarchy1.TextChanged += comboBoxHierarchy1_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(33, 657);
            label13.Name = "label13";
            label13.Size = new Size(64, 30);
            label13.TabIndex = 18;
            label13.Text = "Node";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(592, 839);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(131, 40);
            btnCancel.TabIndex = 46;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(33, 570);
            label12.Name = "label12";
            label12.Size = new Size(143, 30);
            label12.TabIndex = 31;
            label12.Text = "Always Visible";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(446, 839);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(131, 40);
            btnOK.TabIndex = 45;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(32, 478);
            label11.Name = "label11";
            label11.Size = new Size(217, 30);
            label11.TabIndex = 30;
            label11.Text = "Acknowledge Allowed";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(383, 306);
            label10.Name = "label10";
            label10.Size = new Size(131, 30);
            label10.TabIndex = 21;
            label10.Text = "Alarm Group";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 391);
            label7.Name = "label7";
            label7.Size = new Size(54, 30);
            label7.TabIndex = 22;
            label7.Text = "OTD";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 306);
            label6.Name = "label6";
            label6.Size = new Size(118, 30);
            label6.TabIndex = 23;
            label6.Text = "VDU Group";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(384, 223);
            label5.Name = "label5";
            label5.Size = new Size(118, 30);
            label5.TabIndex = 24;
            label5.Text = "Hierarchy 2";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(510, 47);
            label9.Name = "label9";
            label9.Size = new Size(118, 30);
            label9.TabIndex = 25;
            label9.Text = "Eq Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 223);
            label4.Name = "label4";
            label4.Size = new Size(118, 30);
            label4.TabIndex = 26;
            label4.Text = "Hierarchy 1";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(32, 738);
            label15.Name = "label15";
            label15.Size = new Size(174, 30);
            label15.TabIndex = 27;
            label15.Text = "Data Block Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(269, 47);
            label8.Name = "label8";
            label8.Size = new Size(171, 30);
            label8.TabIndex = 28;
            label8.Text = "Main Eq Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 136);
            label3.Name = "label3";
            label3.Size = new Size(185, 30);
            label3.TabIndex = 19;
            label3.Text = "Object Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 47);
            label2.Name = "label2";
            label2.Size = new Size(122, 30);
            label2.TabIndex = 17;
            label2.Text = "SFI Number";
            // 
            // EditObjectForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 933);
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
            Name = "EditObjectForm";
            Text = "EditObjectForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDataBlock;
        private TextBox txtObjectDescription;
        private TextBox txtEqNumber;
        private TextBox txtMainEqNumber;
        private TextBox txtSfiNumber;
        private ComboBox comboBoxCabinet;
        private ComboBox comboBoxNode;
        private ComboBox comboBoxAlwaysVisible;
        private ComboBox comboBoxAcknowledgeAllowed;
        private ComboBox comboBoxOtd;
        private ComboBox comboBoxAlarmGroup;
        private ComboBox comboBoxVduGroup;
        private ComboBox comboBoxHierarchy2;
        private Label label14;
        private ComboBox comboBoxHierarchy1;
        private Label label13;
        private Button btnCancel;
        private Label label12;
        private Button btnOK;
        private Label label11;
        private Label label10;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label9;
        private Label label4;
        private Label label15;
        private Label label8;
        private Label label3;
        private Label label2;
    }
}