
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
            components = new System.ComponentModel.Container();
            dataGridViewObjectTable = new DataGridView();
            btnNewForm = new Button();
            btnEditForm = new Button();
            btnDeleteObject = new Button();
            tabControl1 = new TabControl();
            IOList = new TabPage();
            advDataGridViewObjectTable = new Zuby.ADGV.AdvancedDataGridView();
            PictureHierarchy = new TabPage();
            ObjectTypes = new TabPage();
            EASGroup = new TabPage();
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjectTable).BeginInit();
            tabControl1.SuspendLayout();
            IOList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advDataGridViewObjectTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewObjectTable
            // 
            dataGridViewObjectTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewObjectTable.Location = new Point(29, 40);
            dataGridViewObjectTable.Name = "dataGridViewObjectTable";
            dataGridViewObjectTable.RowHeadersWidth = 72;
            dataGridViewObjectTable.Size = new Size(2068, 338);
            dataGridViewObjectTable.TabIndex = 6;
            // 
            // btnNewForm
            // 
            btnNewForm.Location = new Point(1943, 925);
            btnNewForm.Name = "btnNewForm";
            btnNewForm.Size = new Size(131, 40);
            btnNewForm.TabIndex = 7;
            btnNewForm.Text = "New";
            btnNewForm.UseVisualStyleBackColor = true;
            btnNewForm.Click += btnNewForm_Click;
            // 
            // btnEditForm
            // 
            btnEditForm.Location = new Point(1790, 925);
            btnEditForm.Name = "btnEditForm";
            btnEditForm.Size = new Size(131, 40);
            btnEditForm.TabIndex = 8;
            btnEditForm.Text = "Edit";
            btnEditForm.UseVisualStyleBackColor = true;
            btnEditForm.Click += btnEditForm_Click;
            // 
            // btnDeleteObject
            // 
            btnDeleteObject.Location = new Point(1621, 925);
            btnDeleteObject.Name = "btnDeleteObject";
            btnDeleteObject.Size = new Size(131, 40);
            btnDeleteObject.TabIndex = 9;
            btnDeleteObject.Text = "Delete";
            btnDeleteObject.UseVisualStyleBackColor = true;
            btnDeleteObject.Click += btnDeleteObject_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(IOList);
            tabControl1.Controls.Add(PictureHierarchy);
            tabControl1.Controls.Add(ObjectTypes);
            tabControl1.Controls.Add(EASGroup);
            tabControl1.Location = new Point(29, 25);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2198, 1071);
            tabControl1.TabIndex = 10;
            // 
            // IOList
            // 
            IOList.Controls.Add(advDataGridViewObjectTable);
            IOList.Controls.Add(dataGridViewObjectTable);
            IOList.Controls.Add(btnDeleteObject);
            IOList.Controls.Add(btnEditForm);
            IOList.Controls.Add(btnNewForm);
            IOList.Location = new Point(4, 39);
            IOList.Name = "IOList";
            IOList.Padding = new Padding(3);
            IOList.Size = new Size(2190, 1028);
            IOList.TabIndex = 0;
            IOList.Text = "IO List";
            IOList.UseVisualStyleBackColor = true;
            // 
            // advDataGridViewObjectTable
            // 
            advDataGridViewObjectTable.AllowUserToOrderColumns = true;
            advDataGridViewObjectTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            advDataGridViewObjectTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            advDataGridViewObjectTable.FilterAndSortEnabled = true;
            advDataGridViewObjectTable.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            advDataGridViewObjectTable.Location = new Point(29, 406);
            advDataGridViewObjectTable.Name = "advDataGridViewObjectTable";
            advDataGridViewObjectTable.RightToLeft = RightToLeft.No;
            advDataGridViewObjectTable.RowHeadersWidth = 72;
            advDataGridViewObjectTable.Size = new Size(2068, 393);
            advDataGridViewObjectTable.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            advDataGridViewObjectTable.TabIndex = 10;
            advDataGridViewObjectTable.SortStringChanged += advDataGridViewObjectTable_SortStringChanged;
            advDataGridViewObjectTable.FilterStringChanged += advDataGridViewObjectTable_FilterStringChanged;
            // 
            // PictureHierarchy
            // 
            PictureHierarchy.Location = new Point(4, 39);
            PictureHierarchy.Name = "PictureHierarchy";
            PictureHierarchy.Padding = new Padding(3);
            PictureHierarchy.Size = new Size(2190, 1028);
            PictureHierarchy.TabIndex = 1;
            PictureHierarchy.Text = "Picture Hierarchy";
            PictureHierarchy.UseVisualStyleBackColor = true;
            // 
            // ObjectTypes
            // 
            ObjectTypes.Location = new Point(4, 39);
            ObjectTypes.Name = "ObjectTypes";
            ObjectTypes.Padding = new Padding(3);
            ObjectTypes.Size = new Size(2190, 1028);
            ObjectTypes.TabIndex = 2;
            ObjectTypes.Text = "Object Types";
            ObjectTypes.UseVisualStyleBackColor = true;
            // 
            // EASGroup
            // 
            EASGroup.Location = new Point(4, 39);
            EASGroup.Name = "EASGroup";
            EASGroup.Size = new Size(2190, 1028);
            EASGroup.TabIndex = 3;
            EASGroup.Text = "EAS Group";
            EASGroup.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2273, 1134);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Automation System";
            Activated += MainForm_Activated;
            ((System.ComponentModel.ISupportInitialize)dataGridViewObjectTable).EndInit();
            tabControl1.ResumeLayout(false);
            IOList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)advDataGridViewObjectTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridViewObjectTable;
        private Button btnNewForm;
        private Button btnEditForm;
        private Button btnDeleteObject;
        private TabControl tabControl1;
        private TabPage IOList;
        private TabPage PictureHierarchy;
        private TabPage ObjectTypes;
        private TabPage EASGroup;
        private Zuby.ADGV.AdvancedDataGridView advDataGridViewObjectTable;
        private BindingSource bindingSource1;
    }
}
