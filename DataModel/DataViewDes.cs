using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace DataModel
{
    /// <summary>
    /// 用于描述表和视图
    /// </summary>
    public class DataViewDes : INotifyPropertyChanged
    {

        public DataViewDes()
        { 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #region 类型
        private string _Type;

        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Type"));
                }
            }
        }

        #endregion


        private string _DataViewName;

        /// <summary>
        /// 英文名称
        /// </summary>
        public string DataViewName
        {
            get { return _DataViewName; }
            set
            {
                _DataViewName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataViewName"));
                }
            }
        }


        private string _DataViewId;
        /// <summary>
        /// 主键DataViewId
        /// </summary>
        public string DataViewId
        {
            get { return _DataViewId; }
            set
            {
                _DataViewId = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataViewId"));
                }
            }
        }


        private string _ChineseName;
        /// <summary>
        /// 中文名称
        /// </summary>
        public string ChineseName
        {
            get { return _ChineseName; }
            set
            {
                _ChineseName = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChineseName"));
                }
            }
        }



        private List<DataFeild> _DataFeildList;

        /// <summary>
        /// 字段列表
        /// </summary>
        public List<DataFeild> DataFeildList
        {
            get { return _DataFeildList; }
            set
            {
                _DataFeildList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataFeildList"));
                }
            }
        }

        private bool _IsRemoteGetData = false;
        /// <summary>
        /// 是否从远程获取数据
        /// </summary>
        public bool IsRemoteGetData
        {
            get { return _IsRemoteGetData; }
            set
            {
                _IsRemoteGetData = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsRemoteGetData"));
                }

            }
        }
    }

    /// <summary>
    /// 字段
    /// </summary>
    public class DataFeild : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _DataFeildID;

        /// <summary>
        /// 主键
        /// </summary>
        public string DataFeildID
        {
            get { return _DataFeildID; }
            set
            {
                _DataFeildID = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataFeildID"));
                }
            }
        }


        private string _ChineseName;

        /// <summary>
        /// 中文名称
        /// </summary>
        public string ChineseName
        {
            get { return _ChineseName; }
            set
            {
                _ChineseName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChineseName"));
                }
            }
        }


        private string _DataFeildName;

        /// <summary>
        /// 英文名称
        /// </summary>
        public string DataFeildName
        {
            get { return _DataFeildName; }
            set
            {
                _DataFeildName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataFeildName"));
                }
            }
        }

        private string _DataFeildDataType;

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataFeildDataType
        {
            get { return _DataFeildDataType; }
            set
            {
                _DataFeildDataType = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataFeildDataType"));
                }
            }
        }
        private int _DataFeildLength;

        /// <summary>
        /// 数据长度
        /// </summary>
        public int DataFeildLength
        {
            get { return _DataFeildLength; }
            set
            {
                _DataFeildLength = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DataFeildLength"));
                }
            }
        }

        private string _DataViewType;

        /// <summary>
        /// 表的类型
        /// </summary>
        public string DataViewType
        {
            get { return _DataViewType; }
            set { _DataViewType = value; }
        }
    }
}
