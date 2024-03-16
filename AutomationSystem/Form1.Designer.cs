namespace AutomationSystem
{
    partial class Form1
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
            SuspendLayout();
            // 
            // txtObjectName
            // 
            txtObjectName.Location = new Point(350, 184);
            txtObjectName.Name = "txtObjectName";
            txtObjectName.Size = new Size(430, 35);
            txtObjectName.TabIndex = 0;
            // 
            // ObjectName
            // 
            ObjectName.AutoSize = true;
            ObjectName.Location = new Point(354, 150);
            ObjectName.Name = "ObjectName";
            ObjectName.Size = new Size(136, 30);
            ObjectName.TabIndex = 2;
            ObjectName.Text = "Object Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(354, 285);
            label2.Name = "label2";
            label2.Size = new Size(123, 30);
            label2.TabIndex = 3;
            label2.Text = "Object Type";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(350, 413);
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
            comboObjectType.Location = new Point(350, 328);
            comboObjectType.Name = "comboObjectType";
            comboObjectType.Size = new Size(431, 38);
            comboObjectType.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1744, 1122);
            Controls.Add(comboObjectType);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(ObjectName);
            Controls.Add(txtObjectName);
            Name = "Form1";
            Text = "Automation System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtObjectName;
        private Label ObjectName;
        private Label label2;
        private Button btnSave;
        private ComboBox comboObjectType;
    }
}
