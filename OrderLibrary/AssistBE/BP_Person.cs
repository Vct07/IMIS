using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BPElement
{
    public class BP_Person
    {
        //获取账户信息
        public static DataSet GetPersonInfo(string key)
        {
            var Shere = "PersonNumber ='" + key + "' or NickName like '%" + key + "%' or Email='" + key + "' or Phone='" + key + "'";
            if (key.ToLower().Contains("gpa"))
            {
                Shere = "Education.GPA" + key.ToLower().Replace("gpa", "");
            }
            if (key.ToLower().Contains("="))
            {
                Shere = key;
            }
            string sql = "select distinct MS_Person.* from MS_Person left join Education on Education.Student_FK=MS_Person.MS_PersonOID where IfAdmin=0 and (" + Shere + ")";
            return Sqlhlper.GetSet(sql);
        }
        //获取指定账户信息
        public static DataSet GetPersonInfoByid(string OID)
        {
            string sql = "select * from MS_Person where MS_PersonOID='" + OID + "'";
            return Sqlhlper.GetSet(sql);
        }
         
        //验证账户信息
        public static DataSet ValiPersonInfo(string PersonNumber)
        {
            string sql = "select * from MS_Person where PersonNumber='" + PersonNumber + "'";
            return Sqlhlper.GetSet(sql);
        }
        //初始化账户密码
        public static int InitPwdInfo(string OID)
        {
            string sql = "update MS_Person set PassWord='" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("888888", "MD5") + "' where MS_PersonOID='" + OID + "'";
            return Sqlhlper.ExcuetQueryNon(sql);
        }
        //添加账户信息
        public static int AddPersonInfo(string PersonNumber, string FirstName, string MiddleName, string NickName, string Email, string Phone, string Sex,string Semester_FK, string Status)
        {
            try
            {
                string SQL = @"INSERT INTO [MS_Person]
                               ([MS_PersonOID]
                               ,[PersonNumber]
                               ,[PassWord]
                               ,[IfAdmin]
                               ,[NickName]
                               ,[CreateTime]
                               ,[MiddleName]
                               ,[FirstName]
                               ,[Email]
                               ,[Phone]
                               ,[Sex]
                               ,[Status]
                               ,[WorkStatus],[Semester_FK]
                              )
                         VALUES
                              (@MS_PersonOID
                               ,@PersonNumber
                               ,@PassWord
                               ,0
                               ,@NickName
                               ,@CreateTime
                               ,@MiddleName
                               ,@FirstName,@Email,@Phone,@Sex,@Status,0,@Semester_FK
                              )";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("MS_PersonOID", Guid.NewGuid().ToString());
                DIC.Add("PersonNumber", PersonNumber);
                DIC.Add("PassWord", System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("888888", "MD5"));
                DIC.Add("NickName", NickName);
                DIC.Add("FirstName", FirstName);
                DIC.Add("MiddleName", MiddleName);
                DIC.Add("Email", Email);
                DIC.Add("Phone", Phone);
                DIC.Add("Status", Status);
                DIC.Add("Sex", Sex);
                DIC.Add("Semester_FK", Semester_FK);
                DIC.Add("CreateTime", DateTime.Now.ToString());
                return Sqlhlper.ComOprateInfo(DIC, SQL);
            }
            catch
            {
                return 0;
            }
        }
        //修改账户信息
        public static int ModifyPersonInfo(string NickName, string MiddleName, string FirstName, string Email, string Phone, string Sex, string S_Semester, string S_Status, string Key)
        {
            try
            {
                int flg = 0;
                string SQL = @"UPDATE [MS_Person]
                            SET [NickName] = @NickName,                                
                                [MiddleName] = @MiddleName,
                                [FirstName] = @FirstName,
                                [Email] = @Email,
                                [Phone] = @Phone,  [Status] = @Status, 
                                [Sex] = @Sex,[Semester_FK] = @Semester_FK                                                            
                             WHERE [MS_PersonOID] = @MS_PersonOID";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("MS_PersonOID", Key);
                DIC.Add("NickName", NickName);
                DIC.Add("MiddleName", MiddleName);
                DIC.Add("FirstName", FirstName);
                DIC.Add("Email", Email);
                DIC.Add("Phone", Phone);
                DIC.Add("Sex", Sex);
                DIC.Add("Status", S_Status);
                DIC.Add("Semester_FK", S_Semester);
                flg= Sqlhlper.ComOprateInfo(DIC, SQL); 
                
                return flg;

            }
            catch
            {
                return 0;
            }
        }
        //删除账户信息
        public static int DelPersonInfo(string key)
        {
            return Sqlhlper.ExcuetQueryNon("delete from MS_Person where MS_PersonOID='" + key + "'");
        }
        
    }
   
}
