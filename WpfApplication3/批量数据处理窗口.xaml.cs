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

using System.Data;
using System.Data.SqlClient;
using MathSoftCommonLib;
using MathSoftModelLib;

namespace WpfApplication3
{
    /// <summary>
    /// 批量数据处理窗口.xaml 的交互逻辑
    /// </summary>
    public partial class 批量数据处理窗口 : Window
    {

        public string conString
        {
            get
            {
                return txtconString.Text;
            }
        }

        public List<String> ListDBName
        {
            get;
            set;
        }

        public 批量数据处理窗口()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            try
            {
                String sql = txtSql.Text;
                var SelectedItems = caonima.SelectedItems;
                foreach (var item in SelectedItems)
                {
                    try
                    {
                        var dbName = item.ToString();

                        string sqlcommand = string.Format("use {0}  {1}  ", dbName, sql);

                        SqlHelper helper = new SqlHelper(conString);

                        helper.ExeQuery(sqlcommand);
                    }
                    catch (Exception ex)
                    {
                        i++;
                        builder.AppendLine(DateTime.Now.ToString()+ex.Message);
                    }
                }
                if (i > 0)
                {
                    builder.AppendLine(DateTime.Now.ToString()+"执行完毕");
                }
                else
                {
                    builder.AppendLine(DateTime.Now.ToString() + "执行成功");
                }
            }
            catch (Exception ex)
            {
                builder.AppendLine(DateTime.Now.ToString() + ex.Message);
            }
            finally
            {
                txtres.Text = builder.ToString();
            }

        }

        //查询数据库列表
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                List<String> list = new List<string>();
                SqlHelper helper = new SqlHelper(conString);
                DataTable dt = helper.ExeQueryGetDataSet(@" SELECT 
      name 
  FROM master.sys.databases WITH(NOLOCK) 
  --WHERE  name like 'gwamcc%'").Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    list.Add(item["name"].ToString());
                }
                ListDBName = list;
                foreach (var item in ListDBName)
                {
                    caonima.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchRes = ListDBName.ToList();
                if (string.IsNullOrEmpty(dbName.Text.Trim()))
                {

                }
                else
                {
                    searchRes = ListDBName.Where(item => item.ToLower().Contains(dbName.Text.ToLower())).ToList();

                }

                caonima.Items.Clear();
                foreach (var item in searchRes)
                {
                    caonima.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                caonima.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                caonima.UnselectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            try
            {
              
                var SelectedItems = caonima.SelectedItems;
                foreach (var item in SelectedItems)
                {
                    try
                    {
                        var dbName = item.ToString();

                        String sql = string.Format(@"update {0}.dbo.JCPT_JGXX set ZWMC = A.ZWMC
			from {0}.dbo.JCPT_JGXX_HISTORY A where A.JGID =JCPT_JGXX. JGID  ", dbName);



                        SqlHelper helper = new SqlHelper(conString);

                        helper.ExeQuery(sql);
                    }
                    catch (Exception ex)
                    {
                        i++;
                        builder.AppendLine(DateTime.Now.ToString() + ex.Message);
                    }
                }
                if (i > 0)
                {
                    builder.AppendLine(DateTime.Now.ToString() + "执行完毕");
                }
                else
                {
                    builder.AppendLine(DateTime.Now.ToString() + "执行成功");
                }
            }
            catch (Exception ex)
            {
                builder.AppendLine(DateTime.Now.ToString() + ex.Message);
            }
            finally
            {
                txtres.Text = builder.ToString();
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            List<String> list = new List<string>()
            {
               "drop table [OrgConfig] -- 删除配置表",
               "drop proc [dbo].[Usp_UpdateGwamcc_XX] -- 删除储存过程",
               "drop   FUNCTION [dbo].[GetOrgName] --删除函数",
               "update dbo.JCPT_JGXX set ZWMC = A.ZWMC from dbo.JCPT_JGXX_HISTORY A where A.JGID =JCPT_JGXX. JGID -- 从机构恢复到表",

               @"update dbo.jcpt_jgdz  set  jgmc= A.jgmc from gwamcc.dbo.OrgConfig A where  convert(varchar(6),A.jgbm) = bscbm -- 后台操作"

               ,"  UPDATE [dbo].[JCPT_JGXX_HISTORY] SET [ZWMC]= REPLACE([ZWMC],'分公司','办事处')  WHERE  [ZWMC] like '%分公司%'--生产上别用"
            };
            this.txtSql.Text = string.Join("\r\n", list.ToArray());
        }
    }
}
