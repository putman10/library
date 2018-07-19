using System;
using MySql.Data.MySqlClient;

namespace Library.Models
{
    public class Checkout
    {
        public int id { get; set; }
        public int patronId { get; set; }
        public int copyId { get; set; }
        public DateTime checkoutDate { get; set; }

        public Checkout(int pId, int cId, DateTime cODate)
        {
            patronId = pId;
            copyId = cId;
            checkoutDate = cODate;
        }

        public static int Find(int bookId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT MIN(id) FROM copies WHERE books_Id = @bookId and available = true;";

            cmd.Parameters.AddWithValue("@bookId", bookId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int foundCopyId = 0;

            while (rdr.Read())
            {
                foundCopyId = rdr.GetInt32(0);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundCopyId;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO checkout (copies_Id, patrons_Id, checkout_date) VALUES ( @CopyId, @PatronId, @CheckoutDate);";

            cmd.Parameters.AddWithValue("@CopyId", copyId);
            cmd.Parameters.AddWithValue("@PatronId", patronId);
            cmd.Parameters.AddWithValue("@CheckoutDate", checkoutDate);
       

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
