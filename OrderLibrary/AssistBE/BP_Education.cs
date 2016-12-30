using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BPElement.Model;

namespace BPElement
{
    public class BP_Education
    {
        //获取教育信息
        public static DataSet GetEducationInfo()
        {
            //DataSet ds = new DataSet();
            string sql = "select * from Education";
            return Sqlhlper.GetSet(sql);
        }
        //获取未选教育信息
        public static DataSet GetNoChooseEducationInfo(string id)
        {
            string sql = "select * from Education where id not in(select Education_FK  from StudentEduMap where Student_FK='" + id + "')";
            return Sqlhlper.GetSet(sql);
        }
        //获取我的选教育信息
        public static DataSet GetChooseEducationInfo(string id)
        {
            string sql = "select * from Education where Student_FK='" + id + "'";
            return Sqlhlper.GetSet(sql);
        }

        //获取指定教育信息
        public static DataSet GetEducationInfo(string OID)
        {
            string sql = "select * from Education where ID='" + OID + "'";
            return Sqlhlper.GetSet(sql);
        }


        //添加教育信息
        public static int AddEducationInfo(Education model)
        {
            try
            {
                string SQL = @"INSERT INTO [Education]
                               ([ID]
                               ,[DegreeType]
                               ,[MajorName]
                               ,[GPA]
                               ,[UniversityName]
                               ,[ContryName]
                               ,[CertificateTitle]
                               ,[CertificateOntology],Student_FK
                              )
                         VALUES
                              ( @ID
                               ,@DegreeType
                               ,@MajorName
                               ,@GPA
                               ,@UniversityName
                               ,@ContryName
                               ,@CertificateTitle
                               ,@CertificateOntology,@Student_FK
                              )";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", Guid.NewGuid().ToString());
                DIC.Add("DegreeType", model.DegreeType);
                DIC.Add("MajorName", model.MajorName);
                DIC.Add("GPA", model.GPA);
                DIC.Add("UniversityName", model.UniversityName);
                DIC.Add("ContryName", model.ContryName);
                DIC.Add("CertificateTitle", model.CertificateTitle);
                DIC.Add("CertificateOntology", model.CertificateOntology);
                DIC.Add("Student_FK", model.Student_FK);
                return Sqlhlper.ComOprateInfo(DIC, SQL);
            }
            catch
            {
                return 0;
            }
        }
        //修改教育信息
        public static int ModifyEducationInfo(Education model)
        {
            try
            {
                int flg = 0;
                string SQL = @"UPDATE [Education]
                            SET[DegreeType] = @DegreeType
                              ,[MajorName] = @MajorName
                              ,[GPA] = @GPA
                              ,[UniversityName] = @UniversityName
                              ,[ContryName] = @ContryName
                              ,[CertificateTitle] = @CertificateTitle
                              ,[CertificateOntology] = @CertificateOntology                                              
                             WHERE [ID] = @ID";
                Dictionary<string, object> DIC = new Dictionary<string, object>();
                DIC.Add("ID", model.ID);
                DIC.Add("DegreeType", model.DegreeType);
                DIC.Add("MajorName", model.MajorName);
                DIC.Add("GPA", model.GPA);
                DIC.Add("UniversityName", model.UniversityName);
                DIC.Add("ContryName", model.ContryName);
                DIC.Add("CertificateTitle", model.CertificateTitle);
                DIC.Add("CertificateOntology", model.CertificateOntology);
                flg = Sqlhlper.ComOprateInfo(DIC, SQL);

                return flg;

            }
            catch
            {
                return 0;
            }
        }
        //删除教育信息
        public static int DelEducationInfo(string key)
        {
            return Sqlhlper.ExcuetQueryNon("delete from Education where ID='" + key + "'");
        }
        //删除关联教育信息
        public static int DelEducationMapInfo(string key)
        {
            return Sqlhlper.ExcuetQueryNon("delete from StudentEduMap where ID='" + key + "'");
        }
        /// <summary>
        /// 添加学生教育
        /// </summary>
        /// <returns></returns>
        public static int AddEducationMapInfo(string Student_FK, string Education_FK)
        {
            string sql = "INSERT INTO StudentEduMap(Student_FK,Education_FK) values ('" + Student_FK + "','" + Education_FK + "')";
            return Sqlhlper.ExcuetQueryNon(sql);
        }


    }

}
