using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Library.Models
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }   
        public int qty { get; set; }

        public Book(string bookName, int bookQty = 0, int bookId = 0)
        {
            id = bookId;
            qty = bookQty;
            name = bookName;

        }


        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO books (title) VALUES ( @BookTitle);";

            cmd.Parameters.AddWithValue("@BookTitle", name);
    
            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Book> GetAll()
        {
            List<Book> allBooks = new List<Book> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM books;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int idRdr = rdr.GetInt32(0);
                string titleRdr = rdr.GetString(1);
                Book newBook = new Book(titleRdr, idRdr);
                allBooks.Add(newBook);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allBooks;
        }

        public void SaveCopies()
        {

            MySqlConnection conn = DB.Connection();
            conn.Open();

            for (int i = qty; i <= qty; i++)
            {
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO copies (books_id, available) VALUES (@BookId, @AvailableStatus);";

                cmd.Parameters.AddWithValue("@BookId", id);
                cmd.Parameters.AddWithValue("@AvailableStatus", true);

                cmd.ExecuteNonQuery();
                id = (int)cmd.LastInsertedId;
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM books WHERE id = @BookId; DELETE FROM copies WHERE books_id = @BookId;";

            cmd.Parameters.AddWithValue("@BookId", id);

            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
