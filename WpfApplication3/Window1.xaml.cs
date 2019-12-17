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
using MathSoftCommonLib;
using MathSoftModelLib;
using DataModel;
using BLL;
using System.Linq.Expressions;
namespace WpfApplication3
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        List<DataViewDes> list = null;
        public Window1()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;
            list = new BLLTableOper().GetList();
            listBox2.ItemsSource = list;
            lblBIaoCOunt.Content = list.Count(item => item.Type == "1");
            lblShituCount.Content = list.Count(item => item.Type == "2");

            lblSumCount.Content = list.Count();

            //将字段全部找到
            list.ForEach(item =>
            {
                if (item.IsRemoteGetData)
                {
                }
                else
                {
                    item.DataFeildList = new BLL_DataFeild().GetList(item.DataViewId);
                    item.IsRemoteGetData = true;

                }
            });



            txtName.Focus();
        }
        private void listBox2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          
        }
        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataViewDes obj = listBox2.SelectedItem as DataViewDes;
            if (obj != null)
            {
                if (obj.IsRemoteGetData)
                {
                    DataGrid1.ItemsSource = obj.DataFeildList;
                    lblCount1.Content = obj.DataFeildList.Count;

                }
                else
                {
                    List<DataFeild> list = new BLL_DataFeild().GetList(obj.DataViewId);
                    obj.DataFeildList = list;
                    obj.IsRemoteGetData = true;
                    DataGrid1.ItemsSource = list;
                    lblCount1.Content = list.Count;
                }
            }
            else
            {
                DataGrid1.ItemsSource = null;
                lblCount1.Content = "0";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox2.ItemsSource = list.Where(item => item.ChineseName.Contains(txtName.Text));
        }
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
 

            //筛选是表还是视图
            bool biao = cbkbiao.IsChecked.Value;
            bool shitu = cbkView.IsChecked.Value;

            Expression<Func<DataViewDes, bool>> biaoExp = null;
            Expression<Func<DataViewDes, bool>> shituExp = null;
            Expression<Func<DataViewDes, bool>> cao = null;

            if (biao)
            {
                biaoExp = (i => i.Type == "1");
            }
            else
            {
                biaoExp = (i => i.Type != "1");
            }

            if (shitu)
            {
                shituExp = (i => i.Type == "2");
            }
            else
            {
                shituExp = (i => i.Type != "2");
            }

            if (biao & shitu)
            {
                cao = biaoExp.Or(shituExp);
            }
            else
            {
                cao = biaoExp.And(shituExp);
            }
            Expression<Func<DataViewDes, bool>> jiba = item =>
                (
                  item.DataViewName.ToUpper().Contains(txtName.Text.Trim().ToUpper())
                  || item.ChineseName.ToUpper().Contains(txtName.Text.Trim().ToUpper()
                  )
                  ) &&
                  (
                 item.DataFeildList.Any(subitem => item.ChineseName.ToUpper().IndexOf(txtFieldName.Text.Trim().ToUpper())>=0) ||
                    item.DataFeildList.Any(subitem => subitem.ChineseName.ToUpper().IndexOf(txtFieldName.Text.Trim().ToUpper())>=0) ||
                    item.DataFeildList.Any(subitem => subitem.DataFeildName.ToUpper().IndexOf(txtFieldName.Text.Trim().ToUpper())>=0)
                 );

            var search = list.Where((jiba.And(cao).Compile()));

            List<DataViewDes> res = search.ToList();
            listBox2.ItemsSource = res;
            lblBIaoCOunt.Content = res.Count(item => item.Type == "1");
            lblShituCount.Content = res.Count(item => item.Type == "2");

            lblSumCount.Content = res.Count();
        }
        private void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGridRow row = e.Row;
            DataFeild model = e.Row.Item as DataFeild;
            if (!string.IsNullOrEmpty(txtFieldName.Text.Trim().ToUpper()))
            {
                if (model.DataFeildName.ToUpper().IndexOf(txtFieldName.Text.Trim().ToUpper()) >= 0
                    ||
                    model.ChineseName.ToUpper().IndexOf(txtFieldName.Text.Trim().ToUpper()) >= 0
                    )
                {

                    row.Background = Brushes.Maroon;
                    row.Foreground = Brushes.White;
                }
                else
                {
                    row.Background = Brushes.White;
                    row.Foreground = Brushes.Black;
                }
            }
        }
        private void cbkbiao_Click(object sender, RoutedEventArgs e)
        {
            txtName_KeyUp(null, null);
        }

        private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void cbkbiao_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
