
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
            dataGridViewObjectTable = new DataGridView();
            btnNewForm = new Button();
            btnEditForm = new Button();
            btnDeleteObject = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjectTable).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewObjectTable
            // 
            dataGridViewObjectTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewObjectTable.Location = new Point(41, 58);
            dataGridViewObjectTable.Name = "dataGridViewObjectTable";
            dataGridViewObjectTable.RowHeadersWidth = 72;
            dataGridViewObjectTable.Size = new Size(2187, 956);
            dataGridViewObjectTable.TabIndex = 6;
            // 
            // btnNewForm
            // 
            btnNewForm.Location = new Point(2097, 1045);
            btnNewForm.Name = "btnNewForm";
            btnNewForm.Size = new Size(131, 40);
            btnNewForm.TabIndex = 7;
            btnNewForm.Text = "New";
            btnNewForm.UseVisualStyleBackColor = true;
            btnNewForm.Click += btnNewForm_Click;
            // 
            // btnEditForm
            // 
            btnEditForm.Location = new Point(1944, 1045);
            btnEditForm.Name = "btnEditForm";
            btnEditForm.Size = new Size(131, 40);
            btnEditForm.TabIndex = 8;
            btnEditForm.Text = "Edit";
            btnEditForm.UseVisualStyleBackColor = true;
            btnEditForm.Click += btnEditForm_Click;
            // 
            // btnDeleteObject
            // 
            btnDeleteObject.Location = new Point(1775, 1045);
            btnDeleteObject.Name = "btnDeleteObject";
            btnDeleteObject.Size = new Size(131, 40);
            btnDeleteObject.TabIndex = 9;
            btnDeleteObject.Text = "Delete";
            btnDeleteObject.UseVisualStyleBackColor = true;
            btnDeleteObject.Click += btnDeleteObject_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2273, 1134);
            Controls.Add(btnDeleteObject);
            Controls.Add(btnEditForm);
            Controls.Add(btnNewForm);
            Controls.Add(dataGridViewObjectTable);
            Name = "MainForm";
            Text = "Automation System";
            Activated += MainForm_Activated;
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjectTable).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridViewObjectTable;
        private Button btnNewForm;
        private Button btnEditForm;
        private Button btnDeleteObject;
    }
}
