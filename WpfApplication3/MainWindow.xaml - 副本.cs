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

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;





namespace WpfApplication3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var conString = ConfigurationManager.AppSettings["conString"];

            List<Maliang> list = new List<Maliang>();

            SqlDataAdapter adapter = new SqlDataAdapter(@"select name from sys.all_objects where 1=1
and  type in ('V') 
and name not like 'crm_%' and name not like 'V_thd_%'
and is_ms_shipped='0'", new SqlConnection(conString));
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "dt1");
            DataTable dt1 = dataSet.Tables["dt1"];
            foreach (DataRow row in dt1.Rows)
            {
                string name = row["name"].ToString();


                SqlDataAdapter adapter1 = new SqlDataAdapter(string.Format(@"select definition from sys.sql_modules where object_id=object_id('{0}')",
                    name
                    ), new SqlConnection(conString));
                DataSet dataSet1 = new DataSet();
                adapter1.Fill(dataSet1, "dt11");
                DataTable dt11 = dataSet1.Tables["dt11"];
                if (dt11 == null)
                {
                    continue;
                }
                foreach (DataRow tempRow in dt11.Rows)
                {
                    if (tempRow["definition"] == DBNull.Value)
                    {
                        continue;
                    }
                    else
                    {
                        string ddd = tempRow["definition"].ToString();
                        if (ddd.Contains("/*") || ddd.Contains("*/"))
                        {
                            continue;
                        }
                        else if (ddd.Contains("*") || ddd.Contains(".*"))
                        {
                            list.Add(new Maliang { Name = name, Value = ddd });
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
            }
            for (int i = 1; i <= list.Count; i++)
            {
                list[i - 1].Id = i;
            }

            this.dataGrid1.ItemsSource = list;



            this.lblShow.Content = string.Format("已经找到{0}条数据", list.Count);

            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("Id", typeof(int)));
            //dt.Columns.Add(new DataColumn("Name", typeof(string)));
            //dt.Columns.Add(new DataColumn("Value", typeof(string)));

            //foreach (Maliang item in list)
            //{
            //    DataRow row = dt.NewRow();
            //    row["Id"] = item.Id;
            //    row["Name"] = item.Name;
            //    row["Value"] = item.Value;

            //    dt.Rows.Add(row);
            //}

            int j = 0;
            foreach (var item in list)
            {
                j++;
                string value = item.Value;
                value = value.Replace("create", "ALTER");
                value = value.Replace("CREATE", "ALTER");

                value = "--" + j + "、" + item.Name + "\r\n" + value;

                Write_Txt(value);
            }
        }

        #region 写文件
        protected void Write_Txt( string Content)
        {
            Encoding code = Encoding.GetEncoding("gb2312");
            string htmlfilename = "1.txt";　//保存文件的路径
            string str = Content;
            StreamWriter sw = null;
            {
                try
                {
                    sw = new StreamWriter(htmlfilename, true, code);
                    sw.Write(str);
                    sw.Flush();
                }
                catch { }
            }
            sw.Close();
            sw.Dispose();

        }
        #endregion
    }


    public class Maliang
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        private bool _Status = true;

        #region 状态
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion

    }
}
