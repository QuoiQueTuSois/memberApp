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
        public static async Task<IEnumerable<MemberModel>> GetMemberlist()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.Port = 3306;
            sb.UserID = "root";
            sb.Password = "2671als1";
            sb.CharacterSet = "utf8";
            sb.Database = "test";
            conn = sb.ConnectionString;

            using (var db = new MySqlConnection(conn))
            {
                db.Open();
                //var sql = @"SELECT SEQ, ID, NICKNAME, LEVEL, POINT, REG_DATE, EXPIRE_DATE FROM TB_BOARD";
                var sql = @"SELECT SEQ FROM TB_BOARD";

                return await db.QueryAsync<MemberModel>(sql);
                 
            }
            
        }



        public static string conn = "Server=127.0.0.1;Database=test;Uid=root;Pwd=2671als1;charset=utf8;";
        public static string dbconn = "Server=localhost;Port=3306;Database=test;Uid=root;Pwd=2671als1;charset=utf8;";

        

    }

}
