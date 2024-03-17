using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using AutomationSystem.Classes;


namespace AutomationSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FillGridView();
        }
        private void MainForm_Activated(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            OpenNewObjectForm();
        }

        private void btnEditForm_Click(object sender, EventArgs e)
        {
            OpenEditObjectForm();
        }

        private void btnDeleteObject_Click(object sender, EventArgs e)
        {
            DeleteObject();
        }

        private void FillGridView()
        {
            List<TagObject> objectList = new List<TagObject>();
            TagObject tagObject = new TagObject();
            objectList = tagObject.GetTagObjects();
            dataGridViewObjectTable.DataSource = objectList;
            advDataGridViewObjectTable.DataSource = objectList;
        }

        private void OpenNewObjectForm()
        {
            NewObjectForm newObjectForm = new NewObjectForm();
            newObjectForm.ShowDialog();
        }
        private void OpenEditObjectForm()
        {
            int selectedObjectId = (int)dataGridViewObjectTable.CurrentRow.Cells[0].Value;

            EditObjectForm formEditObject = new EditObjectForm(selectedObjectId);
            formEditObject.ShowDialog();
        }

        private void DeleteObject()
        {
            int selectedObjectId = (int)dataGridViewObjectTable.CurrentRow.Cells[0].Value;
            TagObject tagObject = new TagObject();
            tagObject.DeleteTagObject(selectedObjectId);
            FillGridView();
        }

        private void advDataGridViewObjectTable_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            MessageBox.Show(this.advDataGridViewObjectTable.SortString);
        }

        private void advDataGridViewObjectTable_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            MessageBox.Show(this.advDataGridViewObjectTable.FilterString);
        }
    }
}
