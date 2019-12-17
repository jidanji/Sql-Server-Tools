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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using MathSoftCommonLib;
using MathSoftModelLib;

namespace WpfApplication3
{
    /// <summary>
    /// Window5.xaml 的交互逻辑
    /// </summary>
    public partial class Window5 : Window
    {

        List<Maliang> list = new List<Maliang>();

        IEnumerable<Maliang> source = new List<Maliang>();

        public Window5()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string aaa = txtName.Text;
            var array1 = aaa.Split(new string[] { "\r\n", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
            if (array1.Count() != 0)
            {
                source = list.Where(item => array1.Contains(item.Name));
            }
            else
            {
                source = list.ToList();
            }



            var Cunguo = CheckBoxCunguo.IsChecked.Value;
            List<String> Search = new List<string>();
            if (Cunguo)
            {
                Search.Add("存储过程");
            }


            var shitu = CheckBoxShitu.IsChecked.Value;

            if (shitu)
            {
                Search.Add("视图");
            }

            var Hanshu = CheckBoxHanshu.IsChecked.Value;

            if (Hanshu)
            {
                Search.Add("函数");
            }


            source = source.Where(jj => Search.Contains(jj.DataType));
            for (int i = 1; i <= source.Count(); i++)
            {
                list[i - 1].Id = i;
            }

            this.listBox2.ItemsSource = source;

            int ij = 0;
            foreach (var item in source)
            {
                ij++;
                item.Id = ij;
            }



            this.lblShow.Content = string.Format("已经找到{0}条数据", source.Count());

        }

        private void LoadData()
        {
            var conString = ConfigurationManager.AppSettings["conString"];



            SqlDataAdapter adapter = new SqlDataAdapter(@"select name,type from sys.all_objects where 1=1
and  type in ('V','P','FN') 
and is_ms_shipped='0'", new SqlConnection(conString));
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "dt1");
            DataTable dt1 = dataSet.Tables["dt1"];
            foreach (DataRow row in dt1.Rows)
            {
                string name = row["name"].ToString();
                string typeA = row["type"].ToString();


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
                        var datata = new Maliang { Name = name, Value = ddd };
                        if (typeA.Trim() == "V")
                        {
                            datata.DataType = "视图";
                        }
                        else if (typeA.Trim() == "P")
                        {
                            datata.DataType = "存储过程";
                        }
                        else if (typeA.Trim() == "U")
                        {
                            datata.DataType = "表";
                        }
                        else if (typeA.Trim() == "FN")
                        {
                            datata.DataType = "函数";
                        }
                        list.Add(datata);
                    }
                }
            }
            for (int i = 1; i <= list.Count; i++)
            {
                list[i - 1].Id = i;
            }

            this.listBox2.ItemsSource = list;



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

            source = list.ToList();
        }

        #region 写文件
        protected void Write_Txt(string Name, string Content, String path)
        {
            Encoding code = Encoding.GetEncoding("gb2312");
            string htmlfilename = System.Environment.CurrentDirectory + "\\" + path + "\\" + Name + ".sql";　//保存文件的路径
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
            try
            {
                sw.Close();
                sw.Dispose();
            }
            catch { }

        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listBox2.SelectedItem as Maliang;
            if (item != null)
            {
                this.TextBox1.Text = item.Value;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in source)
                {

                    string value = item.Value;
                    value = value.Replace("create", "ALTER");
                    value = value.Replace("CREATE", "ALTER");



                    Write_Txt(item.Name, value, item.DataType);

                  
                }
                MessageBox.Show("导出成功！！！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckBoxShitu_Click(object sender, RoutedEventArgs e)
        {
            button1_Click(null, null);
        }

        private void CheckBoxCunguo_Click(object sender, RoutedEventArgs e)
        {
            button1_Click(null, null);
        }

        private void CheckBoxHanshu_Click(object sender, RoutedEventArgs e)
        {
            button1_Click(null, null);
        }

 
    }

    public class Maliang
    {
        public string DataType
        {
            get;
            set;
        }


        public int Id
        {
            get;
            set;
        }

        private Guid _ClientId = new Guid();

        public Guid ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
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
