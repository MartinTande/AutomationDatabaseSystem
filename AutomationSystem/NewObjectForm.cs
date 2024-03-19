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
    public partial class NewObjectForm : Form
    {
        public NewObjectForm()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveObjectData();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveObjectData()
        {
            TagObject tagObject = new TagObject();

            tagObject.ObjectDescription = txtSfiNumber.Text;
            tagObject.Hierarchy_1 = comboBoxHierarchy1.Text;
            tagObject.Hierarchy_2 = comboBoxHierarchy2.Text;
            tagObject.VduGroup = comboBoxVduGroup.Text;
            tagObject.Otd = comboBoxOtd.Text;

            tagObject.CreateTagObject(tagObject);
        }

        private void FillComboBoxes()
        {
            Hierarchy1 hierarchy1 = new Hierarchy1();
            Hierarchy2 hierarchy2 = new Hierarchy2();
            VduGroup vduGroup = new VduGroup();
            AlarmGroup alarmGroup = new AlarmGroup();
            Otd otd = new Otd();
            AcknowledgeAllowed ackAllowed = new AcknowledgeAllowed();
            AlwaysVisible alwaysVisible = new AlwaysVisible();
            Node node = new Node();
            Cabinet cabinet = new Cabinet();

            ComboBoxUtil.FillComboBox(comboBoxHierarchy1, hierarchy1.GetNames());
            ComboBoxUtil.FillUnderCategoryComboBox(comboBoxHierarchy2, comboBoxHierarchy1.Text, hierarchy2);
            ComboBoxUtil.FillComboBox(comboBoxVduGroup, vduGroup.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxVduGroup, alarmGroup.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxOtd, otd.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxOtd, ackAllowed.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxOtd, alwaysVisible.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxOtd, node.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxOtd, cabinet.GetNames());
        }

        private void comboBoxHierarchy1_TextChanged(object sender, EventArgs e)
        {
            Hierarchy2 hierarchy2 = new Hierarchy2();
            ComboBoxUtil.FillUnderCategoryComboBox(comboBoxHierarchy2, comboBoxHierarchy1.Text, hierarchy2);
        }
    }
}
