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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// KeyValueInfo.xaml 的交互逻辑
    /// </summary>
    public partial class KeyValueInfo : UserControl
    {
        public KeyValueInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 标题
        /// </summary>
        public String KVTitle
        {
            get
            {
                return this.lblName.Content.ToString();
            }
            set
            {

                this.lblName.Content = value;
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string KVContent
        {
            get
            {
                return this.txtContent.Text; 
            }
            set
            {
                this.txtContent.Text = value;
            }
        }

       
    }
}
