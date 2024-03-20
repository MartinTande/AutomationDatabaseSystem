using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using AutomationSystem.Classes;
using System.Data.Common;


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
            try
            {
                DeleteObject();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
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
            if (dataGridViewObjectTable.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("You have not chosen an object to edit");
                return;
            }
            int selectedObjectId = (int)dataGridViewObjectTable.CurrentRow.Cells[0].Value;

            EditObjectForm formEditObject = new EditObjectForm(selectedObjectId);
            formEditObject.ShowDialog();
        }

        private void DeleteObject()
        {
            int selectedObjectId;
            selectedObjectId = (int)dataGridViewObjectTable.CurrentRow.Cells[0].Value;
            TagObject tagObject = new TagObject();
            tagObject.DeleteTagObject(selectedObjectId);
            FillGridView();
            
        }

        private void advDataGridViewObjectTable_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            string sortString = advDataGridViewObjectTable.SortString;
            sortString = sortString.Trim();
            MessageBox.Show(this.advDataGridViewObjectTable.SortString);
        }

        private void advDataGridViewObjectTable_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            /*
             * Finds the Column name and first column value of filtestring, checks in while loop if there are more column values
             */
            string[] separators = { "[", "]", "'" };
            int _COLUMN_NAME_PLACEMENT = 1;
            int _COLUMN_VALUE_PLACEMENT = 3;
            int _FITLER_WORD_INCEREMENT = 2;

            List<string> columnValues = new List<string>();

            string filterString = advDataGridViewObjectTable.FilterString;
            string[] filterWords = filterString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string columnName = filterWords[_COLUMN_NAME_PLACEMENT];

            columnValues.Add(filterWords[_COLUMN_VALUE_PLACEMENT]);

            while (filterWords[_COLUMN_VALUE_PLACEMENT+1].Equals(", "))
            {
                _COLUMN_VALUE_PLACEMENT += _FITLER_WORD_INCEREMENT;
                columnValues.Add(filterWords[_COLUMN_VALUE_PLACEMENT]);
            }
            FillFilteredGridView(columnName, columnValues);
        }

        private void FillFilteredGridView(string columnName, List<string> columnValues)
        {
            List<TagObject> objectList = new List<TagObject>();
            TagObject tagObject = new TagObject();
            objectList = tagObject.GetTagObjects();
            dataGridViewObjectTable.DataSource = objectList;
            advDataGridViewObjectTable.DataSource = objectList;
        }
    }
}
