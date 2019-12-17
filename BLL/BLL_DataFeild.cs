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
    public class BLL_DataFeild
    {
        DAL_DataFeild dal = null;
        public BLL_DataFeild()
        {
            dal = new DAL_DataFeild();
        }
        public List<DataFeild> GetList(string id)
        {
            return dal.GetList(id);
        }
    }
}
