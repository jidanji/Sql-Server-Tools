using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using MathSoftModelLib;
using MathSoftCommonLib;
using System.Data;


namespace DAL
{
    public class DAL_DataFeild
    {
        public List<DataFeild> GetList(string id)
        {
            string sql = string.Format(@"		declare	@dbname	sysname
		,@no varchar(35), @yes varchar(35), @none varchar(35)
	select @no = 'no', @yes = 'yes', @none = 'none'
	declare @precscaletypes nvarchar(150)
		select @precscaletypes = N'tinyint,smallint,decimal,int,bigint,real,money,float,numeric,smallmoney,date,time,datetime2,datetimeoffset,'
		
		select a.*,b.value ChineseName,
		
	case	c.type
	when 'U' then '1'  
	when 'V' then '2'  
 end
	as DataViewType
	 from (
select
			'DataFeildName'			= name,
			'DataFeildDataType'					= type_name(user_type_id),
			'Computed'				= case when ColumnProperty(object_id, name, 'IsComputed') = 0 then @no else @yes end,
			'DataFeildLength'					= convert(int, max_length),
			-- for prec/scale, only show for those types that have valid precision/scale
			-- Search for type name + ',', because 'datetime' is actually a substring of 'datetime2' and 'datetimeoffset'
			'Prec'					= case when charindex(type_name(system_type_id) + ',', @precscaletypes) > 0
										then convert(char(5),ColumnProperty(object_id, name, 'precision'))
										else '     ' end,
			'Scale'					= case when charindex(type_name(system_type_id) + ',', @precscaletypes) > 0
										then convert(char(5),OdbcScale(system_type_id,scale))
										else '     ' end,
			'Nullable'				= case when is_nullable = 0 then @no else @yes end,
			'TrimTrailingBlanks'	= case ColumnProperty(object_id, name, 'UsesAnsiTrim')
										when 1 then @no
										when 0 then @yes
										else '(n/a)' end,
			'FixedLenNullInSource'	= case
						when type_name(system_type_id) not in ('varbinary','varchar','binary','char')
							then '(n/a)'
						when is_nullable = 0 then @no else @yes end,
			'Collation'		= collation_name,
			'DataFeildID'=column_id,
			is_identity,
			object_id
		from sys.all_columns where object_id = '{0}'
		)a 

				left join
		( select * from sys.extended_properties b where b.major_id='{0}')b
		on b.minor_id=a.DataFeildID
		
		left join SysObjects c on c.id=a.object_id
		
		", id);

            List<DataFeild> list = new List<DataFeild>();

            SqlHelper helper = new SqlHelper();
            DataSet set = helper.ExeQueryGetDataSet(sql);
            DataTable dt = set.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                DataFeild obj = new DataFeild
                {
                    ChineseName = row["ChineseName"].ToString(),
                    DataFeildDataType = row["DataFeildDataType"].ToString(),
                    DataFeildID = row["DataFeildID"].ToString(),
                    DataFeildLength = Convert.ToInt32(row["DataFeildLength"]),
                    DataFeildName = row["DataFeildName"].ToString(),
                    DataViewType = row["DataViewType"].ToString()
                };
                list.Add(obj);
            }
            return list;
        }
    }
}
