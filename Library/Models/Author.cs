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
