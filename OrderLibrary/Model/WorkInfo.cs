using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPElement.Model
{
    /// <summary>
    /// 工作信息
    /// </summary>
    public class WorkInfo
    {
        public string ID { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string PostName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 公司外键
        /// </summary>
        public string Company_FK { get; set; }
        /// <summary>
        /// 责任
        /// </summary>
        public string Responsibility { get; set; }
        /// <summary>
        /// 要求
        /// </summary>
        public string Requirement { get; set; }
        /// <summary>
        /// 工资
        /// </summary>
        public int Wages { get; set; }
        
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 已招数量
        /// </summary>
        public int ObjNum { get; set; }
        /// <summary>
        /// 工种
        /// </summary>
        public string WorkType { get; set; }
          
    }
}
