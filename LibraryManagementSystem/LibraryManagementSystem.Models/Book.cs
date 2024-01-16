using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        private int _id;
        private string _title;
        private string _author;
        private string _description;

        public Book() 
        { 
            _id = 0;
            _title = string.Empty;
            _author= string.Empty;
            _description = string.Empty;
        }

        public Book(int id, string title, string author, string description)
        {
            _id = id;
            _title = title;
            _author = author;
            _description = description;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
