using System;
using System.Data;
using System.Collections.Generic;
using RuRo.Common;
using RuRo.Model;
namespace RuRo.BLL
{
    /// <summary>
    /// TB_CONVERT
    /// </summary>
    public partial class TB_CONVERT
    {
        private readonly RuRo.DAL.TB_CONVERT dal = new RuRo.DAL.TB_CONVERT();
        public TB_CONVERT()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.TB_CONVERT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(RuRo.Model.TB_CONVERT model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(RuRo.Common.PageValidate.SafeLongFilter(IDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RuRo.Model.TB_CONVERT GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public RuRo.Model.TB_CONVERT GetModelByCache(int ID)
        {

            string CacheKey = "TB_CONVERTModel-" + ID;
            object objModel = RuRo.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = RuRo.Common.ConfigHelper.GetConfigInt("ModelCache");
                        RuRo.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (RuRo.Model.TB_CONVERT)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RuRo.Model.TB_CONVERT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RuRo.Model.TB_CONVERT> DataTableToList(DataTable dt)
        {
            List<RuRo.Model.TB_CONVERT> modelList = new List<RuRo.Model.TB_CONVERT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RuRo.Model.TB_CONVERT model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 将页面列转化为系统列
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="datalist"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> PageForSource(Dictionary<string,string> dic,List<Dictionary<string,string>> datalist) 
        {
            //转换页面数据，添加name,description
            List<Dictionary<string, string>> listdic=new List<Dictionary<string,string>>();
            //遍历datalist数据
            foreach (var datadic in datalist)
            {
                Dictionary<string, string> newdic = new Dictionary<string, string>();
                //遍历数据中的字段
                foreach (var datadicvalue in datadic)
                {
                    //匹配从数据库查到的字段
                    foreach (var dicvalue in dic)
                    {
                        if (dicvalue.Key == datadicvalue.Key)
                        {
                            newdic.Add(dicvalue.Value, datadicvalue.Value);
                        }
                    }
                }
                if (newdic.ContainsKey("Name")){}
                else
                {
                    newdic.Add("Name", datadic["患者编号"]);
                }
                if (newdic.ContainsKey("Description")){}
                else
                {
                    newdic.Add("Description", datadic["姓名"]);
                }
                listdic.Add(newdic);
            }
            return listdic;
        }

        #endregion  ExtensionMethod
    }
}

