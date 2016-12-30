using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPElement.Model
{
   public class User
    {

        public string MS_PersonOID { get; set; }
        /// <summary>
        /// 登陆账号
        /// </summary>
        public string PersonNumber { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// 性
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IfAdmin { get; set; }
    

    }
}
