using AutomationSystem.Categories;
using AutomationSystem.Classes;
using AutomationSystem.Forms;

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

            comboBoxHierarchy1.Text = tagObject.Hierarchy_1;
            comboBoxHierarchy2.Text = tagObject.Hierarchy_2;
            comboBoxVduGroup.Text = tagObject.VduGroup;
            comboBoxOtd.Text = tagObject.Otd;
        }

        private void EditObjectData()
        {
            TagObject tagObject = new TagObject();

            tagObject.Id = selectedObjectId;
            tagObject.ObjectDescription = txtObjectDescription.Text;
            tagObject.Hierarchy_1 = comboBoxHierarchy1.Text;
            tagObject.Hierarchy_2 = comboBoxHierarchy2.Text;
            tagObject.VduGroup = comboBoxVduGroup.Text;
            tagObject.Otd = comboBoxOtd.Text;

            tagObject.EditTagObject(tagObject);
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
