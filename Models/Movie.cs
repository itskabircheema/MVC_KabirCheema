using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDEMO2.Models
{
    public class Movie
    {
        private string title;
        private string director;
        private int id;
        public bool IsEditable { get; set; }

        public Movie() { }
        public Movie(int id, string title, string director)
        {
            Id = id;
            Title = title;
            Director = director;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
    }
}