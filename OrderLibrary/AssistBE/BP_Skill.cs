using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BPElement.Model;

namespace BPElement
{
    public class BP_Skill
    {
        //获取技能信息
        public static DataSet GetSkillInfo()
        {
            string sql = "select * from Skill";
            return Sqlhlper.GetSet(sql);            
        }
        public static DataSet GetMySkillInfo(string Person_FK)
        {
            string sql = "select Skill_FK from PersonSkillMap where Person_FK='" + Person_FK + "'";
            return Sqlhlper.GetSet(sql);
        }

        public static bool SetSkill(string skill_FK,string Person_FK,string T)
        {
            string sql = "select * from PersonSkillMap WHERE Skill_FK=" + skill_FK + " AND Person_FK='" + Person_FK + "'";
            var ds= Sqlhlper.GetSet(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (T == "0")
                {
                    sql = "delete from PersonSkillMap where Skill_FK=" + skill_FK + " AND Person_FK='" + Person_FK + "'";
                    return Sqlhlper.ExcuetQueryNon(sql) > 0;
                }
                return true;
            }
            else
            {
                sql = "insert into PersonSkillMap(ID,Skill_FK,Person_FK) values ('"+Guid.NewGuid().ToString()+"'," + skill_FK + ",'" + Person_FK + "')";
                return Sqlhlper.ExcuetQueryNon(sql) > 0; 

            }
        }
          
    }
   
}
