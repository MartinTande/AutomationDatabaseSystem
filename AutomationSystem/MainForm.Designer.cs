
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
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjectTable).BeginInit();
            SuspendLayout();
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2273, 1325);
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
    }
}
