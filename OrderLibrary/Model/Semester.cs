using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPElement.Model
{
    /// <summary>
    /// 学期学年
    /// </summary>
    public class Semester
    {
        public string ID { get; set; }
        /// <summary>
        /// 学期（秋季/冬季，默认秋季）
        /// </summary>
        public string Stype { get; set; }
        /// <summary>
        /// 学年
        /// </summary>
        public string SYear { get; set; }
         

    }
}
