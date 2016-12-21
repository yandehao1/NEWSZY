using System;
namespace RuRo.Model
{
    /// <summary>
    /// TB_CONVERT:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TB_CONVERT
    {
        public TB_CONVERT()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _cn_name;
        private string _in_name;
        private string _report_name;
        private string _type;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 字段中文名称
        /// </summary>
        public string CN_Name
        {
            set { _cn_name = value; }
            get { return _cn_name; }
        }
        /// <summary>
        /// 接口字段
        /// </summary>
        public string IN_Name
        {
            set { _in_name = value; }
            get { return _in_name; }
        }
        /// <summary>
        /// 生成报表名称
        /// </summary>
        public string REPORT_NAME
        {
            set { _report_name = value; }
            get { return _report_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model

    }
}

