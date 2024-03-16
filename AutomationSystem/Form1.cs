using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using AutomationSystem.Classes;


namespace AutomationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillObjectTypeComboBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        void SaveData()
        {
            TagObject tagObject = new TagObject();
            MessageBox.Show(comboObjectType.Text);
            tagObject.SaveData(txtObjectName.Text, comboObjectType.Text);
        }

        private void FillObjectTypeComboBox()
        {
            ObjectType objectType = new ObjectType();
            List<ObjectType> objectTypeList = new List<ObjectType>();
            objectTypeList = objectType.GetObjectTypes();

            foreach (ObjectType objectTypeItem in objectTypeList)
            {
                comboObjectType.Items.Add(objectTypeItem.ObjectTypeName);
            }
        }
    }
}
