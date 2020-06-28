using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace SocialMediaReader.Models.SocialMedia.Linkedin
{
    //inherits the social media client
    public class LinkedinClient : SocialMediaClient
    {
        //there will be an equivalent to this URL in other sites, but the terminology is different so it isnt in socialmediaclient
        public string PostUrl { get; set; } = "?projection=(id,firstName,lastName)";
        
        public LinkedinClient() 
        {
            ProviderKey = "linkedin";
            baseUrl = "https://api.linkedin.com/v2/me";
        }

        public async Task<info> posts()
        {
            //need to use Access Token
            await GetAccessToken();
            
            //this url may look different for each social media source
            string url = String.Format("{0}{1}", baseUrl, PostUrl);

            //get data
            dynamic jsonObj = await GetLI(url,AccessToken);
            
            //fills out info model from LinkedIn jsonObj, data then used to display to webpage and populate SQL server
            info info = new info(jsonObj);

            //Paramaters to connect to SQL Database, opens the connection
            string sqlparams = "Server=tcp:robertroutledgegeorgian.database.windows.net,1433;Initial Catalog=BDAT1007;Persist Security Info=False;User ID=admin123;Password=Essc1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection sqlconn = new SqlConnection(sqlparams);
            sqlconn.Open();
            using (sqlconn)
            {
                //checks to see if the LIData table exists, creates it if not.
                SqlCommand cmd1 = new SqlCommand("IF OBJECT_ID ('LIData','U') is null CREATE TABLE LIData (ID int IDENTITY(1,1) PRIMARY KEY, firstName varchar(50), lastName varchar(50),LinkedinID varchar (50));IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_LinkedinID') BEGIN CREATE UNIQUE NONCLUSTERED INDEX IX_LinkedinID ON LIData (LinkedinID) WITH (IGNORE_DUP_KEY = ON) END;", sqlconn);
                cmd1.ExecuteNonQuery();

                //Add info model to SQL Database ensuring no duplicate entries based on Unique Like IDs

                string InsertQuery = @"INSERT INTO LIData (firstName, lastName, LinkedinID) VALUES " + "('" + info.firstName + "','" + info.lastName + "','" + info.id + "')";

                SqlCommand cmd2 = new SqlCommand(InsertQuery, sqlconn);
                cmd2.ExecuteNonQuery();

            }
            sqlconn.Close();

            return (info);
        }
    }
}