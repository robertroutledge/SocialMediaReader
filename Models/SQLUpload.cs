//using SocialMediaReader.Models.SocialMedia.Facebook;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace SocialMediaReader.Models
//{
//    public class SQLUpload
//    {


//        public void FacebookSQLUpload(postss posts)
//        {
//            //Paramaters to connect to SQL Database
//            string sqlparams = "Server=tcp:robertroutledgegeorgian.database.windows.net,1433;Initial Catalog=BDAT1007;Persist Security Info=False;User ID=admin123;Password=Essc1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
//            SqlConnection sqlconn;
//            sqlconn = new SqlConnection(sqlparams);
//            sqlconn.Open();
//            //using my SQL connection, with a try/catch to print on the screen if the connection fails
//            //drops the table if it exists, creates it with the appropriate columns

//                SqlCommand cmd1 = new SqlCommand("IF OBJECT_ID ('FBData','U') is null CREATE TABLE FBData (ID int IDENTITY(1,1) PRIMARY KEY, Name varchar(50),FBId int, Birthday varchar(50), LikesName varchar(50), LikesId varchar(50), LikesDate varchar(50));", sqlconn);
//                cmd1.ExecuteNonQuery();

//                //Creates the insertion query as a string variable, then interates over the e
//                string InsertQuery = "INSERT INTO FBData (Name, FBId, Birthday, LikesName, LikesId, LikesDate) VALUES (@Name, @FBId, @Birthday, @LikesName, @LikesId, @LikesDate)";

//                //Add the Teams data to SQL Database
//                foreach (var item in posts.jsonObj.data)
//                {
//                    SqlCommand cmd2 = new SqlCommand(InsertQuery, sqlconn);
//                    cmd2.Parameters.AddWithValue("@Name", item.name);
//                    cmd2.Parameters.AddWithValue("@FBId", posts.id);
//                    cmd2.Parameters.AddWithValue("@Birthday", posts.birthday);
//                    cmd2.Parameters.AddWithValue("@LikesName", posts.name);
//                    cmd2.Parameters.AddWithValue("@LikesId", item.LikesId);
//                    cmd2.Parameters.AddWithValue("@LikesDate", item.LikesDate);
//                    cmd2.ExecuteNonQuery();
//                }

//                sqlconn.Close();

//        }
//    }
//}