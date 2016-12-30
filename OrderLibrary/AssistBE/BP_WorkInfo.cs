using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BPElement.Model;
using System.Data.SqlClient;

namespace BPElement
{
    public class BP_WorkInfo
    {
        //获取工作信息
        public static DataSet GetWorkInfoInfo(string key)
        {
            string where = key == "" ? "1=1" : "PostName like '%" + key + "%' or Responsibility like '%" + key + "%' or WorkInfo.Remark like '%" + key + "%' or Requirement like '%" + key + "%' or WorkCompany.CompanyName ='" + key + "'";
            if (key.Contains("="))
            {
                where = key;
            }
            string sql = "select WorkInfo.* from WorkInfo inner join WorkCompany on WorkCompany.ID=WorkInfo.Company_FK WHERE Flg=1 and (" + where + ")";
            return Sqlhlper.GetSet(sql);
        }
        public static int GetWorkInfoCount()
        {
            string sql = "select count(*) from WorkInfo where Flg=1";
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
        //获取指定工作信息
        public static DataSet GetWorkInfoInfoByID(string OID)
        {
            string sql = "select * from WorkInfo where ID='" + OID + "'";
            return Sqlhlper.GetSet(sql);
        }
         
        
        //添加工作信息
        public static int AddWorkInfoInfo(WorkInfo model)
        {
            try
            {
                string SQL = @"INSERT INTO [WorkInfo]
                               ([ID]
                               ,[PostName]
                               ,[Remark]
                               ,[Responsibility]
                               ,[Requirement]
                               ,[CreateDate]
                               ,[Num],[ObjNum]
                               ,[Company_FK]
                               ,[WorkType]
                               ,[Wages],[flg]                                
                              )
                         VALUES
                              ( @ID
                               ,@PostName
                               ,@Remark,@Responsibility ,@Requirement ,@CreateDate,@Num,0,@Company_FK,@WorkType,@Wages,1                            
                              )";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", Guid.NewGuid().ToString());
                DIC.Add("PostName", model.PostName);
                DIC.Add("Remark", model.Remark);
                DIC.Add("Responsibility", model.Responsibility);
                DIC.Add("Requirement", model.Requirement);
                DIC.Add("CreateDate", model.CreateDate);
                DIC.Add("Num", model.Num);
                DIC.Add("Company_FK", model.Company_FK);
                DIC.Add("WorkType", model.WorkType);
                DIC.Add("Wages", model.Wages);                
                return Sqlhlper.ComOprateInfo(DIC, SQL);
            }
            catch
            {
                return 0;
            }
        }
        //修改工作信息
        public static int ModifyWorkInfoInfo(WorkInfo model)
        {
            try
            {
                int flg = 0;
                string SQL = @"UPDATE [WorkInfo]
                            SET [PostName] = @PostName
                                ,[Remark] = @Remark
                                ,[Responsibility] = @Responsibility
                                ,[Requirement] = @Requirement
                                ,[CreateDate] = @CreateDate
                                ,[Num] = @Num                                 
                                ,[WorkType] = @WorkType
                                ,[Wages] = @Wages                                                                        
                             WHERE [ID] = @ID";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", model.ID);
                DIC.Add("PostName", model.PostName);
                DIC.Add("Remark", model.Remark);
                DIC.Add("Responsibility", model.Responsibility);
                DIC.Add("Requirement", model.Requirement);
                DIC.Add("CreateDate", model.CreateDate);
                DIC.Add("Num", model.Num);                
                DIC.Add("WorkType", model.WorkType);
                DIC.Add("Wages", model.Wages);                        
                flg= Sqlhlper.ComOprateInfo(DIC, SQL); 
                
                return flg;

            }
            catch
            {
                return 0;
            }
        }
        //删除工作信息
        public static int DelWorkInfoInfo(string key)
        {
            return Sqlhlper.ExcuetQueryNon("update WorkInfo set Flg=0 where ID='" + key + "'");
        }


        //申请工作信息
        public static int AddWorkObjInfo(WorkObj model)
        {
            try
            {
                string SQL = @"INSERT INTO [WorkObj]
                               ([ID]
                               ,[MS_Person_FK]
                               ,[WorkInfo_FK]
                               ,[CreateDate]           
                               ,[Type]                               
                              )
                         VALUES
                              ( @ID
                               ,@MS_Person_FK
                               ,@WorkInfo_FK,@CreateDate,1                            
                              )
                               "
                               ;
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", Guid.NewGuid().ToString());
                DIC.Add("MS_Person_FK", model.MS_Person_FK);
                DIC.Add("WorkInfo_FK", model.WorkInfo_FK);
                DIC.Add("CreateDate", DateTime.Now.ToString());                
                return Sqlhlper.ComOprateInfo(DIC, SQL);
            }
            catch
            {
                return 0;
            }
        }
        //同意申请工作信息
        public static int AggreeWorkObj(string ID)
        {
            try
            {
                string SQL = @"Update [WorkObj] SET Type=2                                                  
                              WHERE [ID] = @ID 
                             Update WorkInfo set ObjNum=ObjNum+1 where id=(select WorkInfo_FK FROM WorkObj WHERE ID=@ID)";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", ID); 
                return Sqlhlper.ComOprateInfo(DIC, SQL);
            }
            catch
            {
                return 0;
            }
        }
        //update WorkInfo set ObjNum=ObjNum+1 where id='" + model.WorkInfo_FK + "'
        //验证工作是否已被申请满额
        public static bool ValiWorkObjInfo(string id)
        {
            bool flg = false;
            string SQL = @"select Num-ObjNum AS ANum FROM [WorkInfo] WHERE id='" +id+ "'";
            try
            {
                var d = Sqlhlper.GetSet(SQL);
                if (d != null && d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
                {
                    var num = d.Tables[0].Rows[0][0].ToString();
                    if (Convert.ToInt32(num) <= 0)
                    {
                        flg = false;
                    }
                    else
                    {
                        flg = true;
                    }
                }

                return flg;
            }
            catch { return false; }
            
        }
        public static bool ValiWorkObjByID(string id)
        {
            bool flg = false;
            string SQL = @"select Num-ObjNum AS ANum FROM [WorkInfo] WHERE id=(select WorkInfo_FK from WorkObj WHERE ID='"+id+"')";
            try
            {
                var d = Sqlhlper.GetSet(SQL);
                if (d != null && d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
                {
                    var num = d.Tables[0].Rows[0][0].ToString();
                    if (Convert.ToInt32(num) <= 0)
                    {
                        flg = false;
                    }
                    else
                    {
                        flg = true;
                    }
                }

                return flg;
            }
            catch { return false; }

        }
    }
   
}
