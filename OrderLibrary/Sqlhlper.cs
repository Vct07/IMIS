using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

    /// <summary>
    ///Sqlhlper 的摘要说明
    /// </summary>
    public class Sqlhlper
    {
        public Sqlhlper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //申明一个静态的数据连接引用
        private static SqlConnection con;
        /// <summary>
        /// 实例化数据库连接对象
        /// </summary>
        /// <returns></returns>
        public static SqlConnection IsCon()
        {
            try
            {
                return con = new SqlConnection(ConfigurationManager.AppSettings["SQLConnection"].ToString());
//ConfigurationManager.ConnectionStrings["SQLConnection"].ToString()
            }
            catch (Exception ex)
            {
               // AddErrorLog(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 返回一个静态的SqlCommand对象
        /// </summary>
        /// <param name="Query">sql语句</param>
        /// <returns></returns>
        private static SqlCommand Command(string Query)
        {
            try
            {
                if (con == null)
                    IsCon();
                if (con.State == ConnectionState.Closed)//如果数据库的连接状态为关闭            
                    con.Open();//打开数据库连接
                SqlCommand cmd = new SqlCommand(Query, con);

                return cmd;
            }
            catch (Exception ex)
            {
               // AddErrorLog(ex.Message);
                return null;
            }
        }
        public static int ExcuetQueryNon(string Query)
        {
            return Command(Query).ExecuteNonQuery();
        }
        public static int ExcuteSclor(string Query)
        {
            try
            {
                return Convert.ToInt32(Command(Query).ExecuteScalar());
            }
            catch
            {
                return 0;
            }
        }
        public static SqlDataReader GetReader(string Query)
        {
            return Command(Query).ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static DataSet GetSet(string Query)
        {
            
            try
            {
                IsCon();
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
               // AddErrorLog(ex.Message);
                return null;
            }
        }
        //登录
        public static string ValidateUser(string strUserName, string strPwd,string Role)
        {
            string UserOID = "";
            var Ifadmin = Role=="1"?1: 0;

            try
            {
                string strSql = "select MS_PersonOID from MS_Person where PersonNumber=@UserName and PassWord=@Password and Ifadmin=@Ifadmin";
                if (con == null)
                    IsCon();
                if (con.State == ConnectionState.Closed)//如果数据库的连接状态为关闭            
                    con.Open();//打开数据库连接
                SqlCommand cmd = new SqlCommand(strSql, con);
                cmd.Parameters.AddWithValue("@UserName", strUserName);
                cmd.Parameters.AddWithValue("@Password", strPwd);
                cmd.Parameters.AddWithValue("@Ifadmin", Ifadmin);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UserOID = reader["MS_PersonOID"].ToString();
                   
                }
                else
                {
                    UserOID = "";
                }
                reader.Close();
                con.Close();
                return UserOID;
            }
            catch
            {
                return UserOID;
            }
             
        }
        public static int ModifyPwd(string UserName,string Pwd)
        {
            int flg = 0;
            try
            {
                string sql = "update MS_Person set PassWord='" + Pwd + "' where PersonNumber='" + UserName + "'";
                flg= Sqlhlper.ExcuetQueryNon(sql);
            }
            catch { }
            return flg;
        }
        

        

        public static DataSet GetUserInfo(string OID)
        {
            string SQL = @"select *
                           from MS_Person 
                            where MS_PersonOID='" + OID + "'";
            return Sqlhlper.GetSet(SQL);
        }
         
        /// <summary>
        /// 通用数据操作过程
        /// </summary>
        /// <param name="ParaValue">字段参数</param>
        /// <param name="ComSQL">执行SQL</param>
        /// <returns></returns>
        public static int ComOprateInfo(Dictionary<string, object> ParaValue, string ComSQL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SQLConnection"]))
                {
                    //string strSql = "select * from MS_Person where PersonName=@UserName and PassWord=@Password";
                    if (conn.State == ConnectionState.Closed)//如果数据库的连接状态为关闭  
                    {
                        conn.Open();//打开数据库连接
                    }
                    SqlCommand cmd = new SqlCommand(ComSQL, conn);
                    foreach (KeyValuePair<string, object> kvp in ParaValue)
                    {
                        cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                    }
                    return cmd.ExecuteNonQuery();
                }
            
            }
            catch(Exception ex)
            {
               // AddErrorLog(ex.Message);
                return 0;
            }
        }
        public static void AddErrorLog(string Msg)
        {
            //string sql = "insert into logging(Message,Created) values(@Message,@Created)";
            //Dictionary<string, object> DIC = new Dictionary<string, object>();
            //DIC.Add("Created", DateTime.Now.ToString());
            //DIC.Add("Message", Msg);
            //try
            //{
            //    Sqlhlper.ComOprateInfo(DIC, sql);
            //}
            //catch { }
        }
        
    }
