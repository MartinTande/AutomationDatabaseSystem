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


        private void FillGridView()
        {
            List<TagObject> objectList = new List<TagObject>();

            TagObject tagObject = new TagObject();

            objectList = tagObject.GetTagObjects();
 
            dataGridViewObjectTable.DataSource = objectList;
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            NewObjectForm newObjectForm = new NewObjectForm();
            newObjectForm.ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FillGridView();
        }
    }
}
