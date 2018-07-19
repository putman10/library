using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

namespace Library.Models
{
    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }

        public Author(string authorName, int authorId = 0)
        {
            id = authorId;
            name = authorName;
        }


        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO authors (name) VALUES ( @AuthorName);";

            cmd.Parameters.AddWithValue("@AuthorName", name);

            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static int[] SaveListOfAuthors(string[] authorsList)
        {

            MySqlConnection conn = DB.Connection();
            conn.Open();
            List<int> authorIds = new List<int>();

            for (int i = 0; i < authorsList.Count(); i++)
            {
  
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO authors (name) VALUES ( @AuthorName);SELECT id FROM authors ORDER BY id DESC LIMIT 1";

                cmd.Parameters.AddWithValue("@AuthorName", authorsList[i]);
                  cmd.ExecuteNonQuery();

                MySqlCommand cmdTwo = conn.CreateCommand() as MySqlCommand;
                cmdTwo.CommandText = @"SELECT id FROM authors ORDER BY id DESC LIMIT 1";
                MySqlDataReader rdr = cmdTwo.ExecuteReader() as MySqlDataReader;
                while (rdr.Read())
                {
                int authorId = rdr.GetInt32(0);
                authorIds.Add(authorId);

                }
                rdr.Dispose();
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
  
            return authorIds.ToArray();
        }

        public static void CreateBookAuthorPairing(int bookId, int[] selectedAuthors)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            for (int i = 0; i < selectedAuthors.Count(); i++)
            {
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO books_authors (books_Id, author_id) VALUES ( @BookId, @AuthorId);";

                cmd.Parameters.AddWithValue("@BookId", bookId);
                cmd.Parameters.AddWithValue("@AuthorId", selectedAuthors[i]);

                cmd.ExecuteNonQuery();
                //id = (int)cmd.LastInsertedId;
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Author> GetAll()
        {
            List<Author> allAuthors = new List<Author> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM authors;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int idRdr = rdr.GetInt32(0);
                string nameRdr = rdr.GetString(1);
                Author newAuthor = new Author(nameRdr, idRdr);
                allAuthors.Add(newAuthor);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allAuthors;
        }
    }
}
