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

        public Book(string bookName, int bookId = 0, int bookQty = 0)
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

            for (int i = 1; i <= qty; i++)
            {
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO copies (books_id, available) VALUES (@BookId, @AvailableStatus);";

                cmd.Parameters.AddWithValue("@BookId", id);
                cmd.Parameters.AddWithValue("@AvailableStatus", true);

                cmd.ExecuteNonQuery();
                //id = (int)cmd.LastInsertedId;
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

        public static List<Book> AvailableBooks()
        {
            List<Book> allAvailableBooks = new List<Book> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT DISTINCT books.* FROM copies JOIN books on (copies.books_id = books.id) WHERE copies.available = true;";

            //cmd.CommandText = @"SELECT items.* FROM categories
                //JOIN categories_items ON (categories.id = categories_items.category_id)
                //JOIN items ON (categories_items.item_id = items.id)
                //WHERE categories.id = @CategoryId;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int idRdr = rdr.GetInt32(0);
                string titleRdr = rdr.GetString(1);
                Book newBook = new Book(titleRdr, idRdr);
                allAvailableBooks.Add(newBook);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allAvailableBooks;

        }

        public static List<Book> PatronsCheckedOutBooks(int patronId)
        {
            List<Book> patronsCheckedOutBooks = new List<Book> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT books.* FROM copies JOIN books on (copies.books_Id = books.id)
             JOIN checkout ON (checkout.copies_Id = copies.id)
             WHERE checkout.patrons_id= @PatronId;";

            cmd.Parameters.AddWithValue("@PatronId",patronId);

   
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int idRdr = rdr.GetInt32(0);
                string titleRdr = rdr.GetString(1);
                Book newbook = new Book(titleRdr, idRdr);
                patronsCheckedOutBooks.Add(newbook);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return patronsCheckedOutBooks;

        }

        public static int FindLastAdded()
        {
            int lastAddedId = 0;

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM books ORDER BY ID DESC LIMIT 1";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                lastAddedId = rdr.GetInt32(0);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return lastAddedId;
        }

        public static Book Find(int bookId)
        {
            string foundBookName = "";


            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM books WHERE id = @BookId";

            cmd.Parameters.AddWithValue("@BookId", bookId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                foundBookName = rdr.GetString(1);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            Book foundBook = new Book(foundBookName, bookId); 
            return foundBook;
        }

        public static void Update(string newName, int bookId)
        {

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE books SET title = @NewName WHERE id = @BookId";

            cmd.Parameters.AddWithValue("@NewName", newName);
            cmd.Parameters.AddWithValue("@BookId", bookId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
