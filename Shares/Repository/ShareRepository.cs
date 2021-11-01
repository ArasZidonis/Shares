using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using Shares.Models;
using Microsoft.Data.Sqlite;

namespace Shares.Repository
{
    public class ShareRepository
    {
        
        // Stocks stocks = new Stocks();
        public static double GetTest()
        {
            double ok;
            // List<Global_Quote> share = new List<Global_Quote>();

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=BP0AVHFI85Y2G129");
                var data = JsonConvert.DeserializeObject<Global_Quote>(json);
             
               
                ok = data.globalQuote.price;
            }
            //stocks = new Stocks();
           // stocks.Price = actualValue;
            
            return ok;

        }

        public static List<Stock> GetAllShares()
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");

            con.Open();
            string sql = "SELECT * FROM Share";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            List<Stock> allStocks = new List<Stock>();
            while (reader.Read())
            {



                Stock stock = new Stock();
                stock.shareId = reader.GetInt32(reader.GetOrdinal("shareid"));
                stock.shareName = reader.GetString(reader.GetOrdinal("shareName"));
                stock.shareSymbol = reader.GetString(reader.GetOrdinal("shareSymbol"));
                stock.boughtPrice = reader.GetDouble(reader.GetOrdinal("boughtPrice"));

                double actualValue = 0;
                string shareSymbol = reader.GetString(reader.GetOrdinal("shareSymbol"));
                using (var webClient = new System.Net.WebClient())
                {
                
                    var json = webClient.DownloadString("https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=" + shareSymbol + "&apikey=BP0AVHFI85Y2G129");
                    var data = JsonConvert.DeserializeObject<Global_Quote>(json);
                    actualValue = data.globalQuote.price;
                }
                stock.actualValue = actualValue; 
                stock.stocks = reader.GetDouble(reader.GetOrdinal("stocks"));
                stock.date = reader.GetDateTime(reader.GetOrdinal("date"));
                stock.userid = reader.GetInt32(reader.GetOrdinal("userid"));
                allStocks.Add(stock);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            return allStocks;
        }
        public void InsertTheShare(PostShare postShare)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");
            con.Open();
            string sql = "INSERT INTO Share(shareName, shareSymbol, boughtPrice, stocks, date, userid) VALUES "
            + "(@shareName, @shareSymbol, @boughtPrice, @stocks, @date, @userid)";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@shareName", postShare.shareName);
            command.Parameters.AddWithValue("@shareSymbol", postShare.shareSymbol);
            command.Parameters.AddWithValue("@boughtPrice", postShare.boughtPrice);
            command.Parameters.AddWithValue("@stocks", postShare.stocks);
            command.Parameters.AddWithValue("@userid", postShare.userid);
            command.Parameters.AddWithValue("@date", DateTime.Now);

            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateShare(int shareId, PostShare postShare)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");
            con.Open();
            string sql = "UPDATE Share SET stocks=@stocks, date=@date WHERE shareid = @shareid";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@shareid", shareId);
            command.Parameters.AddWithValue("@stocks", postShare.stocks);
            command.Parameters.AddWithValue("@date", DateTime.Now);

            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateShareValue(int shareId, PostShare postShare)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");
            con.Open();
            string sql = "UPDATE Share SET boughtPrice=@boughtPrice, date=@date WHERE shareid = @shareid";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@shareid", shareId);
            command.Parameters.AddWithValue("@boughtPrice", postShare.boughtPrice);
            command.Parameters.AddWithValue("@date", DateTime.Now);

            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteShare(int shareid)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");
            con.Open();
            string sql = "DELETE FROM Share WHERE shareid = @shareid";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.Parameters.AddWithValue("@shareid", shareid);

            SqliteDataReader reader = command.ExecuteReader();

            reader.Close();
            con.Close();
            con.Dispose();

        }
    }
}
