using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using Shares.Models;
using Microsoft.Data.Sqlite;

namespace Shares.Repository

{    /// <summary>
     /// CryptoRepository is used for all actions that contain Shares.
     /// </summary>
    public class ShareRepository
    {

        /// <summary>
        /// Method used to get all stocks from the database.
        /// </summary>
        /// <returns>Returns a list of all Stocks</returns>
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
                stock.boughtValue = stock.boughtPrice * stock.stocks;
                stock.actualValue = stock.actualValue * stock.stocks;
                stock.profit = stock.boughtValue - stock.actualValue;

                allStocks.Add(stock);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            return allStocks;
        }

        /// <summary>
        /// Method used to add a new stock to the database.
        /// </summary>
        /// <param name="postShare">new crypto object which will be added to the database</param>
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
        /// <summary>
        /// Method to update an existing stock in the database.
        /// </summary>
        /// <param name="shareId">id of the stock which will be updated</param>
        /// <param name="postShare">stock object with all required information for the stock update</param>
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
        /// <summary>
        /// Method to update an existing stock in the database.
        /// </summary>
        /// <param name="shareId">id of the stock which will be updated</param>
        /// <param name="postShare">stock object with all required information in order to  update value of the stock</param>
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

        /// <summary>
        /// Method to delete a stock from the database using it's id.
        /// </summary>
        /// <param name="shareid">id of the stock which will be removed</param>
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
