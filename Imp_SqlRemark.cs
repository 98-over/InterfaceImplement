using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Data.SqlClient;

namespace InterfaceImplement
{
    public class Imp_SqlRemark : IRemark
    {
        DataBase db = new DataBase();

        public int deleteRemark(string r_no)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@r_no",SqlDbType.VarChar,15,r_no)
            };
            string sql = string.Empty;
            sql = "delete from remark where r_no = @r_no";
            return (db.RunProc(sql, prams));
        }

        public DataSet getRemark(string r_no)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@r_no",SqlDbType.VarChar,15,r_no)
            };
            string sql = string.Empty;
            sql = "selete * from remark where r_no = @r_no";
            return (db.GetDataSet(sql, "tbRemark"));
        }

        public DataSet GetRemarkOfBlog(string b_no)
        {
            string sql = string.Empty;
            sql = "select * from remark,user_student where remark.b_no=" + b_no + " and user_student.stu_id=remark.u_remark union select * from remark,user_teacher where remark.b_no=" + b_no + " and user_teacher.tea_id=remark.u_remark";
            return (db.GetDataSet(sql, "tbAllRemark"));
        }

        public DataSet GetRemarkOfBlog(string b_no, int r_num)
        {
            string sql = string.Empty;
            sql = "select top "+r_num.ToString()+ " * from remark,user_student where remark.b_no=" + b_no + " and user_student.stu_id=remark.u_remark union select top " + r_num.ToString() + " * from remark,user_teacher where remark.b_no=" + b_no + " and user_teacher.tea_id=remark.u_remark";
            return (db.GetDataSet(sql, "tbAllRemark"));
        }

        public int insertRemark(Remark remark)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@r_no",SqlDbType.VarChar,15,remark.R_no),
                db.MakeInParam("@r_text",SqlDbType.VarChar,255,remark.R_text),
                db.MakeInParam("@r_time",SqlDbType.DateTime,4,remark.R_time),
                db.MakeInParam("@u_remark",SqlDbType.VarChar,36,remark.U_remark),
                db.MakeInParam("@u_deremark",SqlDbType.VarChar,36,remark.U_deremark),
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,remark.B_no)
            };
            string sql = string.Empty;
            sql = "insert into remark values(@r_no,@r_text,@r_time,@u_remark,@u_deremark,@b_no)";
            return (db.RunProc(sql, prams));
        }

        /// <summary>
        /// 评论不支持修改
        /// </summary>
        /// <param name="remark"></param>
        /// <returns></returns>
        public int updateRemark(Remark remark)
        {
            return 0;
        }
    }
}
