using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Frame.xaml 的交互逻辑
    /// </summary>
    public partial class Frame : Window
    {
        public Frame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            f1.Content = new Page1() {  Name="清华"};
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            f1.Content = new Page2();
        }
    }
}
