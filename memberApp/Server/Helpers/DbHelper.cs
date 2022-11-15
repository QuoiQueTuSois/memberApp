using memberApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using Dapper;
using System.Runtime.InteropServices;
using System.Text.Unicode;


namespace memberApp.Server.Helpers
{
    public class DbHelper
    {
        public static string conn = "Server=127.0.0.1;Database=test;Uid=root;Pwd=2671als1;charset=utf8;";

        /// <summary>
        /// 멤버리스트 가져오기
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<MemberModel>> GetMemberlist()
        {

            using (var db = new MySqlConnection(conn))
            {
                var sql = @"
                            SELECT 
                                SEQ, 
                                ID, 
                                NICKNAME, 
                                LEVEL, 
                                POINT, 
                                REG_DATE, 
                                EXPIRE_DATE,
                                MEMBER_CLASS
                            FROM 
                                TB_BOARD";

                return await db.QueryAsync<MemberModel>(sql);
            }

        }

        /// <summary>
        /// 시퀀스 번호 가져오기
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        public static async Task<MemberModel> GetSeq(int seq)
        {
            using (var db = new MySqlConnection(conn))
            {
                var sql = @"SELECT * FROM TB_BOARD WHERE SEQ =@SEQ";

                return await db.QueryFirstOrDefaultAsync<MemberModel>(sql, new { SEQ = seq });
                
            }
        }

        /// <summary>
        /// 멤버추가
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static int InsertMember(MemberModel member)
        {
            using (var db = new MySqlConnection(conn))
            {
                var sql = @"INSERT INTO 
                              TB_BOARD
                                (
                                 SEQ,
                                 ID, 
                                 NICKNAME,
                                 LEVEL,
                                 POINT,
                                 REG_DATE,
                                 EXPIRE_DATE
                                
                                ) VALUES ( 
                                @SEQ,
                                @ID, 
                                @NICKNAME,
                                @LEVEL, 
                                @POINT, 
                                @REG_DATE,
                                @EXPIRE_DATE
                                
                               )";

                return db.Execute(sql, member);
            }
        }

        /// <summary>
        /// 멤버수정
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static int UpdateMember(MemberModel member)
        {
            using (var db = new MySqlConnection(conn))
            {
                var sql = @"UPDATE 
                              TB_BOARD
                                SET    
                                   ID = @ID,
                                   NICKNAME = @NICKNAME,
                                   LEVEL= @LEVEL,
                                   POINT= @POINT,
                                   REG_DATE= @REG_DATE,
                                   EXPIRE_DATE= @EXPIRE_DATE
                                   WHERE 
                                        SEQ= @SEQ;
                                ";


                return db.Execute(sql, member);
            }
        }

        public static int DeleteMember(int seq)
        {
            using (var db = new MySqlConnection(conn))
            {
                var sql = @"DELETE FROM TB_BOARD WHERE SEQ= @SEQ";
                return db.Execute(sql, new { SEQ = seq });
            }

        }


        /// <summary>
        /// 멤버등급 변경
        /// </summary>
        /// <param name="seq"></param>
        /// <param name="cls"></param>
        /// <returns></returns>
        public static int UpdateClass(int seq, string cls)
        {
            using (var db = new MySqlConnection(conn))
            {
                var sql = @"UPDATE TB_BOARD SET MEMBER_CLASS = @CLASS WHERE SEQ =@SEQ";
                return db.Execute(sql, new { SEQ = seq, CLASS = cls });
            }
        }


        public static int IsDuplicatedId(string id)
        {
            using (var db = new MySqlConnection(conn))
            {
                var sql = @"SELECT 

                                COUNT(@ID) AS cnt
                            FROM
                                tb_board
                            GROUP BY ID
                            HAVING COUNT(ID) > 1;
                                "
                                    ;
         
                return db.Execute(sql, new {ID = id});


            }




        }

    }
}
