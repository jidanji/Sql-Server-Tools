using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataModel;

using MathSoftCommonLib;
using MathSoftModelLib;

namespace BLL
{
    public class BLLTableOper
    {
        private DALTableOper dal = null;
        public BLLTableOper()
        {
            dal = new DALTableOper();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<DataViewDes> GetList()
        {
            return dal.GetList();
        }
    }
}
