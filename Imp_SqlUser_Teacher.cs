using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace InterfaceImplement
{
    public class Imp_SqlUser_Teacher : IUser_Teacher
    {
        DataBase db = new DataBase();
        public int DeleteTeacher(string id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@tea_id",SqlDbType.VarChar,36,id),
            };
            string sql = string.Empty;
            sql = "delete from user_teacher where tea_id=@tea_id";
            return db.RunProc(sql, prams);
        }

        public DataSet GetAllTeacher()
        {
            string sql = string.Empty;
            sql = "select * from user_teacher";
            return db.GetDataSet(sql, "tb_allt");
        }

        public DataSet GetTeacher(string id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@tea_id",SqlDbType.VarChar,36,id),
            };
            string sql = string.Empty;
            sql = "select * from user_teacher where tea_id=@tea_id";
            return db.RunProcReturn(sql, prams, "tb_tea");
        }

        public int InsertTeacher(User_Teacher t)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@tea_id",SqlDbType.VarChar,36,t.TeaId1),
                db.MakeInParam("@tea_name",SqlDbType.VarChar,20,t.TeaName1),
            };
            string sql = string.Empty;
            sql = "insert into user_teacher(tea_id,tea_name) values(@tea_id,@tea_name)";
            return db.RunProc(sql, prams);
        }

        public int UpdateTeacher(User_Teacher t)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@tea_id",SqlDbType.VarChar,36,t.TeaId1),
                db.MakeInParam("@tea_name",SqlDbType.VarChar,20,t.TeaName1),
                db.MakeInParam("@tea_sex",SqlDbType.VarChar,10,t.TeaSex1),
                db.MakeInParam("@tea_age",SqlDbType.Int,0,t.TeaAge1),
                db.MakeInParam("@tea_photourl",SqlDbType.VarChar,100,t.TeaPhotoUrl1),
                db.MakeInParam("@tea_colloge",SqlDbType.VarChar,50,t.Tea_Colloge1),
            };
            string sql = string.Empty;
            sql = "update user_teacher set tea_name=@tea_name,tea_sex=@tea_sex,tea_age=@tea_age,tea_photourl=@tea_photourl,tea_colloge=@tea_colloge where tea_id=@tea_id";
            return db.RunProc(sql, prams);
        }
    }
}
