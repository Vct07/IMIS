using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BPElement.Model;
using System.Data.SqlClient;

namespace BPElement
{
    public class BP_ApplyWork
    {
        //获取总已申请总数
        public static int GetWorkInfoApplyCount(string type)
        {
            string sql = "select count(*) from WorkObj where [Type]=" + type;
            using (SqlDataReader sdr = Sqlhlper.GetReader(sql))
            {
                if (sdr.Read())
                {
                    return Convert.ToInt32(sdr[0]);
                }
                else
                {
                    return 0;
                }
            }
        }
        //获取我的已申请总数
        public static int GetMyWorkInfoApplyCount(string pid)
        {
            string sql = "select count(*) from WorkObj where MS_Person_FK='" + pid + "'";
            using (SqlDataReader sdr = Sqlhlper.GetReader(sql))
            {
                if (sdr.Read())
                {
                    return Convert.ToInt32(sdr[0]);
                }
                else
                {
                    return 0;
                }
            }
        }
        
    }
   
}
