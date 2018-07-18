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

    }
}