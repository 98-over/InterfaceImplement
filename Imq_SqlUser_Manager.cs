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
    public class Imq_SqlUser_Manager : IUser_Manager
    {
        DataBase db = new DataBase();
        public int DeleteManager(string id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@man_id",SqlDbType.VarChar,36,id),
            };
            string sql = string.Empty;
            sql = "delete from user_manager where man_id=@man_id";
            return db.RunProc(sql, prams);
        }

        public DataSet GetAllManager()
        {
            string sql = string.Empty;
            sql = "select * from user_maneger";
            return db.GetDataSet(sql,"tb_allm");
        }

        public DataSet GetManager(string id)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@man_id",SqlDbType.VarChar,36,id),
            };
            string sql = string.Empty;
            sql = "select * from user_manager where man_id=@man_id";
            return db.RunProcReturn(sql, prams, "tb_man");
        }

        public int InsertManager(User_Manager m)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@man_id",SqlDbType.VarChar,36,m.ManId1),
                db.MakeInParam("@man_name",SqlDbType.VarChar,20,m.ManName1),
            };
            string sql = string.Empty;
            sql = "insert into user_manager(man_id,man_name) values(@man_id,@man_name)";
            return db.RunProc(sql, prams);
        }

        public int UpdateManager(User_Manager m)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@man_id",SqlDbType.VarChar,36,m.ManId1),
                db.MakeInParam("@man_name",SqlDbType.VarChar,20,m.ManName1),
                db.MakeInParam("@man_sex",SqlDbType.VarChar,10,m.ManSex1),
                db.MakeInParam("@man_age",SqlDbType.Int,0,m.ManAge1),
                db.MakeInParam("@man_photourl",SqlDbType.VarChar,100,m.ManPhotoUrl1),
            };
            string sql = string.Empty;
            sql = "update user_manager set man_name=@man_name,man_sex=@man_sex,man_age=@man_age,man_photourl=@man_photourl where man_id=@man_id";
            return db.RunProc(sql, prams);
        }
    }
}
