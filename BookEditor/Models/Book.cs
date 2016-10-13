using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookEditor.Models
{
    public class Book
    {
        private string author;
        private string title;
        private string genre;

        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Genre
        {
            get { return this.genre; }
            set { this.genre = value; }
        }
    }
}