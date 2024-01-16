using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Library
    {
        private int _id;
        private string _name;
        private string _location;

        public Library() 
        {
            _id= 0;
            _name = string.Empty;
            _location = string.Empty;
        }

        public Library(int id, string name, string location)
        {
            _id = id;
            _name = name;
            _location = location;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
