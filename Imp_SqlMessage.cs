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
    public class Imp_SqlMessage : IMessage
    {
        DataBase db = new DataBase();
        public DataSet GetMessageOfUser(string id1,string id2,int num=0)
        {
            DataSet dset = new DataSet();
            SqlParameter[] prams =
            {
                db.MakeInParam("@send_id",SqlDbType.VarChar,36,id1),
                db.MakeInParam("@recv_id",SqlDbType.VarChar,36,id2),
            };
            string sql = string.Empty;
            sql = "select * from message where send_id = @send_id and recv_id = @recv_id or send_id = @recv_id and recv_id = @send_id";
            if (num != 0)
            {
                sql += " limit " + num.ToString();
            }
            dset = db.RunProcReturn(sql, prams, "tb_message");
            return dset;
        }

        public int InsertMessage(Message meg)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@send_id",SqlDbType.VarChar,36,meg.SendId),
                db.MakeInParam("@recv_id",SqlDbType.VarChar,36,meg.RecvId),
                db.MakeInParam("@meg",SqlDbType.Text,500,meg.Meg),
                db.MakeInParam("@time",SqlDbType.DateTime,4,meg.Time),
        };
            string sql = string.Empty;
            sql = "INSERT INTO message VALUES(@recv_id,@send_id,@time,@meg)";
            return (db.RunProc(sql, prams));
        }
    }
}
