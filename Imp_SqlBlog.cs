using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using IDAL;

namespace InterfaceImplement
{
    public class Imp_SqlBlog : IBlog
    {
        DataBase db = new DataBase();
        public int deleteBlog(Blog blog)
        {
            SqlParameter[] prams ={
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,blog.B_no)
            };
            string sql = string.Empty;
            sql = "delete from blog where b_no = @b_no";
            return (db.RunProc(sql, prams));
        }

        public DataSet GetAllBlog(int num = 0)
        {
            DataSet dset = new DataSet();
            string sql = string.Empty;
            sql = "select * from user_student,blog where user_student.stu_id=blog.u_id union select* from user_teacher,blog where user_teacher.tea_id = blog.u_id";
            if (num != 0)
            {
                sql += " limit " + num.ToString();
            }
            dset = db.GetDataSet(sql, "tbAllBlog");
            return dset;

        }

        public DataSet getBlog(string b_no)
        {
            SqlParameter[] prames =
            {
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,b_no)
            };
            string sql = "select * from blog where b_no = @b_no";
            return (db.GetDataSet(sql, "tbBlog"));
            throw new NotImplementedException();
        }

        public int insertBlog(Blog blog)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,blog.B_no),
                db.MakeInParam("@b_text",SqlDbType.VarChar,255,blog.B_text),
                db.MakeInParam("@b_img",SqlDbType.VarChar,255,blog.B_img),
                db.MakeInParam("@b_time",SqlDbType.DateTime,4,blog.B_time),
                db.MakeInParam("@u_id",SqlDbType.VarChar,36,blog.U_id),
                db.MakeInParam("@b_favour",SqlDbType.Int,0,0)
        };
            string sql = string.Empty;
            sql = "INSERT INTO blog VALUES(@b_no,@b_text,@b_img,@b_time,@u_id,@b_favour)";
            return (db.RunProc(sql, prams));
        }

        public int updateBlog(Blog blog)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@b_text",SqlDbType.VarChar,255,blog.B_text),
                db.MakeInParam("@b_img",SqlDbType.VarChar,25,blog.B_img),
                db.MakeInParam("@b_time",SqlDbType.DateTime,4,blog.B_time),
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,blog.B_no),
        };
            string sql = string.Empty;
            sql = "update blog set b_text=@b_text,b_img=@b_img,b_time=@b_time where b_no=@b_no";
            return (db.RunProc(sql, prams));
        }

        public int AddFavour(string b_no, string f_id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,b_no),
                db.MakeInParam("@u_id",SqlDbType.VarChar,36,f_id),
            };
            string sql = string.Empty;
            sql = "insert into favour values(@b_no,@u_id)";
            SqlParameter[] prams1 =
            {
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,b_no),
            };
            string sql2 = string.Empty;
            sql2 = "update blog set b_favour = b_favour+1 where b_no = @b_no";
            db.RunProc(sql2, prams1);
            return (db.RunProc(sql, prams));
        }

        public int DelFavour(string b_no, string f_id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,b_no),
                db.MakeInParam("@u_id",SqlDbType.VarChar,36,f_id),
            };
            string sql = string.Empty;
            sql = "delete from favour where b_no=@b_no and u_id=@u_id";
            SqlParameter[] prams1 =
            {
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,b_no),
            };
            string sql2 = string.Empty;
            sql2 = "update blog set b_favour = b_favour-1 where b_no = @b_no";
            db.RunProc(sql2, prams1);
            return (db.RunProc(sql, prams));
        }

        public bool IsFavour(string b_no, string f_id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@b_no",SqlDbType.VarChar,15,b_no),
                db.MakeInParam("@u_id",SqlDbType.VarChar,36,f_id),
            };
            string sql = string.Empty;
            sql = "select * from favour where b_no=@b_no and u_id=@u_id";
            DataSet ds = db.RunProcReturn(sql, prams,"tb_favour");
            if ((ds == null) || (ds.Tables.Count == 0) || (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
