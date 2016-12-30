using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BPElement.Model;

namespace BPElement
{
    public class BP_Company
    {
        //获取公司信息
        public static DataSet GetCompanyInfo()
        {
            //DataSet ds = new DataSet();
            string sql = "select * from WorkCompany";
            return Sqlhlper.GetSet(sql);            
        }
        //获取指定公司信息
        public static DataSet GetCompanyInfo(string OID)
        {
            string sql = "select * from WorkCompany where ID='" + OID + "'";
            return Sqlhlper.GetSet(sql);
        }
         
        //验证公司信息
        public static DataSet ValiCompanyInfo(string CompanyName)
        {
            string sql = "select * from WorkCompany where CompanyName='" + CompanyName + "'";
            return Sqlhlper.GetSet(sql);
        }
         
        //添加公司信息
        public static int AddCompanyInfo(Company model)
        {
            try
            {
                string SQL = @"INSERT INTO [WorkCompany]
                               ([ID]
                               ,[CompanyName]
                               ,[Address]
                               ,[City]
                               ,[PostCode]
                               ,[Contry]
                               ,[ContactMiddleName]
                               ,[ContactFirstName]
                               ,[ContactPost]
                               ,[Phone]
                               ,[WebSite]
                               ,[Remark],Email
                              )
                         VALUES
                              (@ID
                               ,@CompanyName
                               ,@Address
                               ,@City
                               ,@PostCode
                               ,@Contry
                               ,@ContactMiddleName,@ContactFirstName,@ContactPost,@Phone,@WebSite,@Remark,@Email
                              )";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", Guid.NewGuid().ToString());
                DIC.Add("CompanyName", model.CompanyName);
                DIC.Add("Address", model.Address);
                DIC.Add("City", model.City);
                DIC.Add("PostCode", model.PostCode);
                DIC.Add("Contry", model.Contry);
                DIC.Add("ContactMiddleName", model.ContactMiddleName);
                DIC.Add("ContactFirstName", model.ContactFirstName);
                DIC.Add("ContactPost", model.ContactPost);
                DIC.Add("Phone", model.Phone);
                DIC.Add("WebSite", model.WebSite);
                DIC.Add("Remark", model.Remark);
                DIC.Add("Email", model.Email);
                return Sqlhlper.ComOprateInfo(DIC, SQL);
            }
            catch
            {
                return 0;
            }
        }
        //修改公司信息
        public static int ModifyCompanyInfo(Company model)
        {
            try
            {
                int flg = 0;
                string SQL = @"UPDATE [MS_Company]
                            SET[CompanyName] = @CompanyName
                              ,[Address] = @Address
                              ,[City] = @City
                              ,[PostCode] = @PostCode
                              ,[Contry] = @Contry
                              ,[ContactMiddleName] = @ContactMiddleName
                              ,[ContactFirstName] = @ContactFirstName
                              ,[ContactPost] = @ContactPost
                              ,[Phone] = @Phone
                              ,[WebSite] = @WebSite
                              ,[Remark] = @Remark,[Email] = @Email                                                         
                             WHERE [ID] = @ID";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", model.ID);
                DIC.Add("CompanyName", model.CompanyName);
                DIC.Add("Address", model.Address);
                DIC.Add("City", model.City);
                DIC.Add("PostCode", model.PostCode);
                DIC.Add("Contry", model.Contry);
                DIC.Add("ContactMiddleName", model.ContactMiddleName);
                DIC.Add("ContactFirstName", model.ContactFirstName);
                DIC.Add("ContactPost", model.ContactPost);
                DIC.Add("Phone", model.Phone);
                DIC.Add("WebSite", model.WebSite);
                DIC.Add("Remark", model.Remark);
                DIC.Add("Email", model.Email);
                flg= Sqlhlper.ComOprateInfo(DIC, SQL); 
                
                return flg;

            }
            catch
            {
                return 0;
            }
        }
        //删除公司信息
        public static int DelCompanyInfo(string key)
        {
            return Sqlhlper.ExcuetQueryNon("delete from WorkCompany where ID='" + key + "'");
        }
        
    }
   
}
