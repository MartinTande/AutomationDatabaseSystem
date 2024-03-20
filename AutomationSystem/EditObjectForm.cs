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
            txtSfiNumber.Text = tagObject.SfiNumber.ToString();
            txtMainEqNumber.Text = tagObject.MainEqNumber;
            txtEqNumber.Text = tagObject.EqNumber;
            txtObjectDescription.Text = tagObject.ObjectDescription;
            comboBoxHierarchy1.Text = tagObject.Hierarchy_1;
            comboBoxHierarchy2.Text = tagObject.Hierarchy_2;
            comboBoxVduGroup.Text = tagObject.VduGroup;
            comboBoxAlarmGroup.Text = tagObject.AlarmGroup;
            comboBoxOtd.Text = tagObject.Otd;
            comboBoxAlwaysVisible.Text = tagObject.AlwaysVisible;
            comboBoxAcknowledgeAllowed.Text = tagObject.AcknowledgeAllowed;
            comboBoxNode.Text = tagObject.Node;
            comboBoxCabinet.Text = tagObject.Cabinet;
            txtDataBlock.Text = tagObject.DataBlock;
        }

        private void EditObjectData()
        {
            TagObject tagObject = new TagObject();
            tagObject.Id = selectedObjectId;
            tagObject.SfiNumber = Convert.ToInt32(txtSfiNumber.Text);
            tagObject.MainEqNumber = txtMainEqNumber.Text;
            tagObject.EqNumber = txtEqNumber.Text;
            tagObject.ObjectDescription = txtObjectDescription.Text;
            tagObject.Hierarchy_1 = comboBoxHierarchy1.Text;
            tagObject.Hierarchy_2 = comboBoxHierarchy2.Text;
            tagObject.VduGroup = comboBoxVduGroup.Text;
            tagObject.AlarmGroup = comboBoxAlarmGroup.Text;
            tagObject.Otd = comboBoxOtd.Text;
            tagObject.AlwaysVisible = comboBoxAlwaysVisible.Text;
            tagObject.AcknowledgeAllowed = comboBoxAcknowledgeAllowed.Text;
            tagObject.Node = comboBoxNode.Text;
            tagObject.Cabinet = comboBoxCabinet.Text;
            tagObject.DataBlock = txtDataBlock.Text;

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
            ComboBoxUtil.FillComboBox(comboBoxAlarmGroup, alarmGroup.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxOtd, otd.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxAcknowledgeAllowed, ackAllowed.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxAlwaysVisible, alwaysVisible.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxNode, node.GetNames());
            ComboBoxUtil.FillComboBox(comboBoxCabinet, cabinet.GetNames());
        }

        private void comboBoxHierarchy1_TextChanged(object sender, EventArgs e)
        {
            Hierarchy2 hierarchy2 = new Hierarchy2();
            ComboBoxUtil.FillUnderCategoryComboBox(comboBoxHierarchy2, comboBoxHierarchy1.Text, hierarchy2);
        }
    }
}
