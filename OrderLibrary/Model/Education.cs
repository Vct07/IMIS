using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPElement.Model
{
    public class Education
    {
        public string ID { get; set; }
        /// <summary>
        /// 学位种类（0:毕业前/1:毕业后）
        /// </summary>
        public string DegreeType { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        public string MajorName { get; set; }
        /// <summary>
        /// GPA
        /// </summary>
        public string GPA { get; set; }
        /// <summary>
        /// 学位所在大学
        /// </summary>
        public string UniversityName { get; set; }
        /// <summary>
        /// 大学所在地（国家名）
        /// </summary>
        public string ContryName { get; set; }
        /// <summary>
        /// 证书称谓（例如CCNA）
        /// </summary>
        public string CertificateTitle { get; set; }
        /// <summary>
        /// 证书本体（例如CISCO）
        /// </summary>
        public string CertificateOntology { get; set; }
        /// <summary>
        /// 学生外键
        /// </summary>
        public string Student_FK { get; set; }

    }
}
