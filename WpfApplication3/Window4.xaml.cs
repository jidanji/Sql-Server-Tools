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
using System.IO;

namespace WpfApplication3
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] a = Directory.GetDirectories(textBox1.Text, "*", SearchOption.TopDirectoryOnly);


                List<A> list = new List<A>();
                foreach (var item in a)
                {
                    DirectoryInfo info = new DirectoryInfo(item);

                    FileInfo[] files = info.GetFiles("*.*", SearchOption.AllDirectories);
                    list.Add(new A { Key = item, Number = files.Count(), Size = files.Sum(a1 => a1.Length) });
                }

                this.dataGrid1.ItemsSource = list.OrderByDescending(item => item.Number).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

  

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
        }

        private void windowsFormsHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

 
    }

    public class A
    {
        public string Key { get; set; }
        public int Number { get; set; }

        private long _Size;
        
        public long Size
        {
            get { return _Size; }
            set { _Size = value / (1024*1024); }
        }
    }
}
