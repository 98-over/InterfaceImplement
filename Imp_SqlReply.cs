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
    public class Imp_SqlReply : IReply
    {
        DataBase db = new DataBase();
        public int DeleteReply(string rp_no)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@rp_no",SqlDbType.VarChar,15,rp_no)
            };
            string sql = string.Empty;
            sql = "delete from reply where r_no = @rp_no";
            return (db.RunProc(sql, prams));
        }

        public DataSet GetReplyOfRemark(string r_no)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@r_no",SqlDbType.VarChar,15,r_no)
            };
            string sql = string.Empty;
            sql = "select u1.stu_name 'name1',u2.stu_name 'name2',r1.send_id,r1.recv_id,r1.rp_no,r1.r_no,r1.rp_text,r1.rp_time "
                    + "from user_student u1 "
                    + "join reply r1 on u1.id = r1.send_id "
                    + "inner join user_student u2 on u2.id = r1.recv_id and r1.r_no = @r_no "
                    + "union "
                    + "select u1.tea_name 'name1',u2.tea_name 'name2',r1.send_id,r1.recv_id,r1.rp_no,r1.r_no,r1.rp_text,r1.rp_time "
                    + "from user_teacher u1 "
                    + "join reply r1 on u1.id = r1.send_id "
                    + "inner join user_teacher u2 on u2.id = r1.recv_id and r1.r_no = @r_no ";
            return (db.RunProcReturn(sql, prams,"tb_reply"));
        }

        public DataSet GetReplyOfRemark(string r_no, int rp_num=0)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@r_no",SqlDbType.VarChar,15,r_no)
            };
            string sql = string.Empty;
            sql = "select u1.stu_name 'name1',u2.stu_name 'name2',r1.send_id,r1.recv_id,r1.rp_no,r1.r_no,r1.rp_text,r1.rp_time "
                    + "from user_student u1 "
                    + "join reply r1 on u1.id = r1.send_id "
                    + "inner join user_student u2 on u2.id = r1.recv_id and r1.r_no = @r_no "
                    + "union "
                    + "select u1.tea_name 'name1',u2.tea_name 'name2',r1.send_id,r1.recv_id,r1.rp_no,r1.r_no,r1.rp_text,r1.rp_time "
                    + "from user_teacher u1 "
                    + "join reply r1 on u1.id = r1.send_id "
                    + "inner join user_teacher u2 on u2.id = r1.recv_id and r1.r_no = @r_no ";
            if(rp_num != 0)
            {
                sql = "select top "+ rp_num.ToString() + " u1.stu_name 'name1',u2.stu_name 'name2',r1.send_id,r1.recv_id,r1.rp_no,r1.r_no,r1.rp_text,r1.rp_time "
                    + "from user_student u1 "
                    + "join reply r1 on u1.id = r1.send_id "
                    + "inner join user_student u2 on u2.id = r1.recv_id and r1.r_no = @r_no "
                    + "union "
                    + "select top "+ rp_num.ToString() + " u1.tea_name 'name1',u2.tea_name 'name2',r1.send_id,r1.recv_id,r1.rp_no,r1.r_no,r1.rp_text,r1.rp_time "
                    + "from user_teacher u1 "
                    + "join reply r1 on u1.id = r1.send_id "
                    + "inner join user_teacher u2 on u2.id = r1.recv_id and r1.r_no = @r_no ";
            }
            return (db.RunProcReturn(sql, prams, "tb_reply"));
        }

        public int InsertReply(Reply reply)
        {
            SqlParameter[] prams =
            {
                db.MakeInParam("@rp_no",SqlDbType.VarChar,10,reply.Rp_no),
                db.MakeInParam("@r_no",SqlDbType.VarChar,15,reply.R_no),
                db.MakeInParam("@send_id",SqlDbType.VarChar,36,reply.Send_id),
                db.MakeInParam("@recv_id",SqlDbType.VarChar,36,reply.Recv_id),
                db.MakeInParam("@rp_text",SqlDbType.VarChar,255,reply.Rp_text),
                db.MakeInParam("@rp_time",SqlDbType.DateTime,4,reply.Rp_time)
            };
            string sql = string.Empty;
            sql = "insert into reply values(@rp_no,@r_no,@send_id,@recv_id,@rp_text,@rp_time)";
            return (db.RunProc(sql, prams));
        }
    }
}
