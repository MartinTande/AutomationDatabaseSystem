﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomationSystemUI.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ButtonBar.xaml
    /// </summary>
    public partial class ButtonBar : UserControl
    {
        public ButtonBar()
        {
            InitializeComponent();
        }

        private void btnAddObject_Click(object sender, RoutedEventArgs e)
        {
            AddObjectWindow addObjectWindow = new AddObjectWindow();
            addObjectWindow.Show();
        }

        private void btnEditObject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteObject_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
