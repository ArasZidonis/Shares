using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Shares.Models;


namespace Shares.Repository
{
    public class UserRepository
    {
        public static List<User> GetAllUsers()
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");

            con.Open();
            string sql = "SELECT * FROM User";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            List<User> allUsers = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.userid = reader.GetInt32(reader.GetOrdinal("userid"));
                user.username = reader.GetString(reader.GetOrdinal("username"));
                user.password = reader.GetString(reader.GetOrdinal("password"));
                user.name = reader.GetString(reader.GetOrdinal("name"));
                user.surname = reader.GetString(reader.GetOrdinal("surname"));
                user.email = reader.GetString(reader.GetOrdinal("email"));

                allUsers.Add(user);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            return allUsers;
        }

        public static List<User> GetUserByID(int userid)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");

            con.Open();
            string sql = "SELECT * FROM User WHERE userid=@userid";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.Parameters.AddWithValue("@userid", userid);
            SqliteDataReader reader = command.ExecuteReader();
            List<User> allUsers = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.userid = reader.GetInt32(reader.GetOrdinal("userid"));
                user.username = reader.GetString(reader.GetOrdinal("username"));
                user.password = reader.GetString(reader.GetOrdinal("password"));
                user.name = reader.GetString(reader.GetOrdinal("name"));
                user.surname = reader.GetString(reader.GetOrdinal("surname"));
                user.email = reader.GetString(reader.GetOrdinal("email"));

                allUsers.Add(user);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            return allUsers;
        }

        public void AddNewUser(User newUser)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");
            con.Open();
            string sql = "INSERT INTO User(username, password, name, surname, email) VALUES "
            + "(@username, @password, @name, @surname, @email)";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@username", newUser.username);
            command.Parameters.AddWithValue("@password", newUser.password);
            command.Parameters.AddWithValue("@name", newUser.name);
            command.Parameters.AddWithValue("@surname", newUser.surname);
            command.Parameters.AddWithValue("@email", newUser.email);

            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteUser(int userid)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=Shares.db");
            con.Open();
            string sql = "DELETE FROM User WHERE userid = @userid";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.Parameters.AddWithValue("@userid", userid);

            SqliteDataReader reader = command.ExecuteReader();

            reader.Close();
            con.Close();
            con.Dispose();
        }
    }
}
