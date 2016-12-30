using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPElement.Model
{
    public class Company
    {
        public string ID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Contry { get; set; }
        /// <summary>
        /// 联系人名
        /// </summary>
        public string ContactMiddleName { get; set; }
        /// <summary>
        /// 联系人姓
        /// </summary>
        public string ContactFirstName { get; set; }
        /// <summary>
        /// 联系人职位
        /// </summary>
        public string ContactPost { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 公司网址
        /// </summary>
        public string WebSite { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
          /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }  

    }
}
