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


        public static List<Copy> GetAllOfOneBook(int booksId)
        {
            List<Copy> allCopies= new List<Copy> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM copies WHERE books_id = @BookID;";

            cmd.Parameters.AddWithValue("@BookId", booksId);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int idRdr = rdr.GetInt32(0);
                int bookIdRdr = rdr.GetInt32(1);
                bool available = rdr.GetBoolean(2);
                Copy newCopy = new Copy(bookIdRdr, available, idRdr);
                allCopies.Add(newCopy);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCopies;
        }

        public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM copies WHERE id = @CopyId;";

            cmd.Parameters.AddWithValue("@CopyId", id);

            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }

    }
}