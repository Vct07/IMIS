using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPElement.Model
{
    /// <summary>
    /// 工作实例信息
    /// </summary>
    public class WorkObj
    {
        public string ID { get; set; }
        /// <summary>
        /// 学生外键
        /// </summary>
        public string MS_Person_FK { get; set; }
        /// <summary>
        /// 工作外键
        /// </summary>
        public string WorkInfo_FK { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }         
        /// <summary>
        /// 类型(1:有意向;2:已分配)
        /// </summary>
        public int Type { get; set; }
        
         
    }
}
