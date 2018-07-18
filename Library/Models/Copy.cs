using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Library.Models
{
    public class Copy
    {
        public int id { get; set; }
        public int bookId { get; set; }
        public bool available { get; set; }

        public Copy(int bookIdCopy, bool availableCopy, int idCopy = 0)
        {
            id = idCopy;
            bookId = bookIdCopy;
            available = availableCopy;
        }

        public void Save()
        {

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO copies (books_id, available) VALUES (@BookId., @AvailableStatus);";

            cmd.Parameters.AddWithValue("@BookId", bookId);
            cmd.Parameters.AddWithValue("@AvailableStatus", available);

            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}