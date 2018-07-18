using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Library.Models
{
    public class Patron
    {
        public int id { get; set; }
        public string name { get; set; }

        public Patron(string patronName, int patronId = 0)
        {
           id = patronId;
            name = patronName;
        }

        public void Save()
        {

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO patrons (name) VALUES (@PatronName);";

            cmd.Parameters.AddWithValue("@PatronName", name);

            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Patron> GetAll()
        {
            List<Patron> allPatrons = new List<Patron> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM patrons;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int idRdr = rdr.GetInt32(0);
                string nameRdr = rdr.GetString(1);
                Patron newPatron = new Patron(nameRdr, idRdr);
                allPatrons.Add(newPatron);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allPatrons;

        }
    }
}
