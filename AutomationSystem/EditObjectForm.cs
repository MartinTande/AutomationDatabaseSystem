using AutomationSystem.Categories;
using AutomationSystem.Classes;
using AutomationSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomationSystem
{
    public partial class EditObjectForm : Form
    {
        int selectedObjectId;

        public EditObjectForm(int selectedObjectId)
        {
            this.selectedObjectId = selectedObjectId;
            InitializeComponent();
            GetObjectData();
            FillComboBoxes();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            EditObjectData();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetObjectData()
        {
            TagObject tagObject = new TagObject();
            tagObject = tagObject.GetTagObjectData(selectedObjectId);

            txtBoxName.Text = tagObject.Name;
            comboBoxObjectType.Text = tagObject.ObjectType;
            comboBoxHierarchy1.Text = tagObject.Hierarchy_1;
            comboBoxHierarchy2.Text = tagObject.Hierarchy_2;
            comboBoxEasGroup.Text = tagObject.EasGroup;
            comboBoxOtd.Text = tagObject.Otd;
        }

        private void EditObjectData()
        {
            TagObject tagObject = new TagObject();

            tagObject.Id = selectedObjectId;
            tagObject.Name = txtBoxName.Text;
            tagObject.ObjectType = comboBoxObjectType.Text;
            tagObject.Hierarchy_1 = comboBoxHierarchy1.Text;
            tagObject.Hierarchy_2 = comboBoxHierarchy2.Text;
            tagObject.EasGroup = comboBoxEasGroup.Text;
            tagObject.Otd = comboBoxOtd.Text;

            tagObject.EditTagObject(tagObject);
        }

        private void FillComboBoxes()
        {
            ObjectType objectType = new ObjectType();
            Hierarchy1 hierarchy1 = new Hierarchy1();
            Hierarchy2 hierarchy2 = new Hierarchy2();
            EasGroup easGroup = new EasGroup();
            Otd otd = new Otd();

            ComboBoxUtil.FillComboBox(comboBoxObjectType, objectType.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxHierarchy1, hierarchy1.GetNames());
            ComboBoxUtil.FillUnderCategoryComboBox(comboBoxHierarchy2, comboBoxHierarchy1.Text, hierarchy2);
            ComboBoxUtil.FillComboBox(comboBoxEasGroup, easGroup.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxOtd, otd.GetNames());
        }

        private void comboBoxHierarchy1_TextChanged(object sender, EventArgs e)
        {
            Hierarchy2 hierarchy2 = new Hierarchy2();
            ComboBoxUtil.FillUnderCategoryComboBox(comboBoxHierarchy2, comboBoxHierarchy1.Text, hierarchy2);
        }
    }
}
