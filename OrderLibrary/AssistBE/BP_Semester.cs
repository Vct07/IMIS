using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BPElement.Model;

namespace BPElement
{
    public class BP_Semester
    {
        //获取学期学年信息
        public static DataSet GetSemesterInfo()
        {
            string sql = "select * from Semester";
            return Sqlhlper.GetSet(sql);            
        }
        //获取学期学年信息
        public static DataSet GetSemesterByDP()
        {
            string sql = "select ID,SYear + CASE Stype WHEN 1 THEN '-Fall' ELSE '-Winter' end as Name from Semester  order by Name";
            return Sqlhlper.GetSet(sql);
        }
        //获取指定学期学年信息
        public static DataSet GetSemesterInfo(string OID)
        {
            string sql = "select * from Semester where ID='" + OID + "'";
            return Sqlhlper.GetSet(sql);
        }
         
        
        //添加学期学年信息
        public static int AddSemesterInfo(Semester model)
        {
            try
            {
                string SQL = @"INSERT INTO [Semester]
                               ([ID]
                               ,[SYear]
                               ,[Stype]                                
                              )
                         VALUES
                              ( @ID
                               ,@SYear
                               ,@Stype                               
                              )";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", Guid.NewGuid().ToString());
                DIC.Add("SYear", model.SYear);
                DIC.Add("Stype", model.Stype);                              
                return Sqlhlper.ComOprateInfo(DIC, SQL);
            }
            catch
            {
                return 0;
            }
        }
        //修改学期学年信息
        public static int ModifySemesterInfo(Semester model)
        {
            try
            {
                int flg = 0;
                string SQL = @"UPDATE [Semester]
                            SET[SYear] = @SYear
                              ,[Stype] = @Stype                                                                          
                             WHERE [ID] = @ID";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", model.ID);
                DIC.Add("SYear", model.SYear);
                DIC.Add("Stype", model.Stype);                
                flg= Sqlhlper.ComOprateInfo(DIC, SQL); 
                
                return flg;

            }
            catch
            {
                return 0;
            }
        }
        //删除学期学年信息
        public static int DelSemesterInfo(string key)
        {
            return Sqlhlper.ExcuetQueryNon("delete from Semester where ID='" + key + "'");
        }
        
    }
   
}
