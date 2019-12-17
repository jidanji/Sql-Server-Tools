using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MathSoftModelLib;
using MathSoftCommonLib;
using DataModel;

namespace DAL
{
    public class DALTableOper
    {
        public DALTableOper()
        { }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<DataViewDes> GetList()
        {
            string sql = @"select 1 Type,a.name
 DataViewName,
 a.object_id DataViewId,
ISNULL( b.ChineseName,   a.name)ChineseName
 from
sys.tables a 
left join
(select 1 Type,a.name DataViewName,a.object_id DataViewId,value ChineseName  from sys.tables a
left join  sys.extended_properties b 
on a.object_id=b.major_id
where b.minor_id=0)
b
on
b.DataViewId=a.object_id
union
select 2 Type,a.name
 DataViewName,
 a.object_id DataViewId,
ISNULL( b.ChineseName,   a.name)ChineseName
 from
sys.views a 
left join
(select 1 Type,a.name DataViewName,a.object_id DataViewId,value ChineseName  from sys.views a
left join  sys.extended_properties b 
on a.object_id=b.major_id
where b.minor_id=0)
b
on
b.DataViewId=a.object_id
order by DataViewName
";
            SqlHelper helper = new SqlHelper();
            DataSet set = helper.ExeQueryGetDataSet(sql);
            List<DataViewDes> list = Tras(set.Tables[0]);
            return list;
        }

        public List<DataViewDes> Tras(DataTable dt)
        {
            List<DataViewDes> list = new List<DataViewDes>();

            foreach (DataRow row in dt.Rows)
            {
                DataViewDes obj = new DataViewDes
                {
                    ChineseName = row["ChineseName"].ToString(),
                    DataViewId = row["DataViewId"].ToString(),
                    DataViewName = row["DataViewName"].ToString(),
                    Type = row["Type"].ToString(),
                };
                list.Add(obj);
            }
            return list;
        }
    }
}
