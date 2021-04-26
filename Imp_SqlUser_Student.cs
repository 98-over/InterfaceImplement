using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Data;
using System.Data.SqlClient;

namespace InterfaceImplement
{
    public class Imp_SqlUser_Student : IUser_Student
    {
        DataBase db = new DataBase();
        public int DeleteStudent(string id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@stu_id",SqlDbType.VarChar,36,id),
            };
            string sql = string.Empty;
            sql = "delete from user_student where stu_id=@stu_id";
            return db.RunProc(sql, prams);
        }
        public DataSet GetAllStudent()
        {
            string sql = string.Empty;
            sql = "select * from user_student";
            return db.GetDataSet(sql, "tb_alls");
        }
        public DataSet GetStudent(string id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@stu_id",SqlDbType.VarChar,36,id),
            };
            string sql = string.Empty;
            sql = "select * from user_student where stu_id=@stu_id";
            return db.RunProcReturn(sql, prams,"tb_stu");
        }

        public int InsertStudent(User_Student s)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@stu_id",SqlDbType.VarChar,36,s.StuId1),
                db.MakeInParam("@stu_name",SqlDbType.VarChar,20,s.StuName1),
            };
            string sql = string.Empty;
            sql = "insert into user_student(stu_id,stu_name) values(@stu_id,@stu_name)";
            return db.RunProc(sql, prams);
        }

        public int UpdateStudent(User_Student s)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@stu_id",SqlDbType.VarChar,36,s.StuId1),
                db.MakeInParam("@stu_name",SqlDbType.VarChar,20,s.StuName1),
                db.MakeInParam("@stu_sex",SqlDbType.VarChar,10,s.StuSex1),
                db.MakeInParam("@stu_age",SqlDbType.Int,0,s.StuAge1),
                db.MakeInParam("@stu_photourl",SqlDbType.VarChar,100,s.StuPhotoUrl1),
                db.MakeInParam("@stu_colloge",SqlDbType.VarChar,50,s.Stu_Colloge1),
            };
            string sql = string.Empty;
            sql = "update user_student set stu_name=@stu_name,stu_sex=@stu_sex,stu_age=@stu_age,stu_photourl=@stu_photourl,stu_colloge=@stu_colloge where stu_id=@stu_id";
            return db.RunProc(sql, prams);
        }
    }
}
