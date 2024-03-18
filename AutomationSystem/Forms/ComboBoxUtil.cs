using AutomationSystem.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSystem.Forms
{
    public static class ComboBoxUtil
    {
        public static void FillComboBox(ComboBox comboBox, List<string> items)
        {
            comboBox.Items.Clear();
            foreach (string item in items)
            {
                comboBox.Items.Add(item);
            }
        }

        public static void FillComboBox<T>(ComboBox comboBox, ICategory<T> type)
        {
            comboBox.Items.Clear();
            List<string> items = type.GetNames();
            foreach (string item in items)
            {
                comboBox.Items.Add(item);
            }
        }

        public static void FillUnderCategoryComboBox<T>(ComboBox comboBox, string hierarchy1, ICategory<T> undercategory)
        {
            comboBox.Items.Clear();
            List<string> itemList = new List<string>();
            itemList = undercategory.GetNames(hierarchy1);

            foreach (string item in itemList)
            {
                comboBox.Items.Add(item);
            }
        }
    }
}
