using AutomationSystem.Classes;
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
        }

        private void GetObjectData()
        {
            TagObject tagObject = new TagObject();
            tagObject = tagObject.GetTagObjectData(selectedObjectId);

            txtBoxName.Text = tagObject.ObjectName;
            comboBoxObjectType.Text = tagObject.ObjectType;
            comboBoxHierarchy1.Text = tagObject.Hierarchy_1;
            comboBoxHierarchy2.Text = tagObject.Hierarchy_2;
            comboBoxEasGroup.Text = tagObject.EasGroup;
            comboBoxOtd.Text = tagObject.Otd;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditObjectData()
        {
            TagObject tagObject = new TagObject();

            tagObject.ObjectId = selectedObjectId;
            tagObject.ObjectName = txtBoxName.Text;
            tagObject.ObjectType = comboBoxObjectType.Text;
            tagObject.Hierarchy_1 = comboBoxHierarchy1.Text;
            tagObject.Hierarchy_2 = comboBoxHierarchy2.Text;
            tagObject.EasGroup = comboBoxEasGroup.Text;
            tagObject.Otd = comboBoxOtd.Text;

            tagObject.EditTagObject(tagObject);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EditObjectData();
            Close();
        }
    }
}
