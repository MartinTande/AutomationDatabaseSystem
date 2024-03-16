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
    public partial class NewObjectForm : Form
    {
        public NewObjectForm()
        {
            InitializeComponent();
            FillEasGroupComboBox();
            FillHierarchy1ComboBox();
            FillHierarchy2ComboBox();
            FillObjectTypeComboBox();
            FillOtdComboBox();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveObjectData();
        }

        private void SaveObjectData()
        {
            TagObject tagObject = new TagObject();

            tagObject.ObjectName = txtBoxName.Text;
            tagObject.ObjectType = comboBoxObjectType.Text;
            tagObject.Hierarchy_1 = comboBoxHierarchy1.Text;
            tagObject.Hierarchy_2 = comboBoxHierarchy2.Text;
            tagObject.EasGroup = comboBoxEasGroup.Text;
            tagObject.Otd = comboBoxOtd.Text;

            tagObject.CreateTagObject(tagObject);
        }

        private void FillObjectTypeComboBox()
        {
            ObjectType objectType = new ObjectType();
            List<ObjectType> objectTypeList = new List<ObjectType>();
            objectTypeList = objectType.GetObjectTypes();

            foreach (ObjectType objectTypeItem in objectTypeList)
            {
                comboBoxObjectType.Items.Add(objectTypeItem.ObjectTypeName);
            }
        }

        private void FillHierarchy1ComboBox()
        {
            Hierarchy1 hierarchy1 = new Hierarchy1();
            List<Hierarchy1> hierarchy1List = new List<Hierarchy1>();
            hierarchy1List = hierarchy1.GetHierarchy1Types();

            foreach (Hierarchy1 hierarchy1Item in hierarchy1List)
            {
                comboBoxHierarchy1.Items.Add(hierarchy1Item.Hierarchy1Name);
            }
        }

        private void FillHierarchy2ComboBox()
        {
            Hierarchy2 hierarchy2 = new Hierarchy2();
            List<Hierarchy2> hierarchy2List = new List<Hierarchy2>();
            hierarchy2List = hierarchy2.GetHierarchy2Types();

            foreach (Hierarchy2 hierarchy2Item in hierarchy2List)
            {
                comboBoxHierarchy2.Items.Add(hierarchy2Item.Hierarchy2Name);
            }
        }

        private void FillEasGroupComboBox()
        {
            EasGroup easGroup = new EasGroup();
            List<EasGroup> easGroupList = new List<EasGroup>();
            easGroupList = easGroup.GetEasGroups();

            foreach (EasGroup easGroupItem in easGroupList)
            {
                comboBoxEasGroup.Items.Add(easGroupItem.EasGroupName);
            }
        }

        private void FillOtdComboBox()
        {
            Otd otd = new Otd();
            List<Otd> otdList = new List<Otd>();
            otdList = otd.GetOTDs();

            foreach (Otd otdItem in otdList)
            {
                comboBoxOtd.Items.Add(otdItem.OtdName);
            }
        }
    }
}
