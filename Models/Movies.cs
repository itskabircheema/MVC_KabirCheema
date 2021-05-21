using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDEMO2.Models
{
    public class Movies
    {
       

            public List<Movie> Items { get; set; }
            public int EditIndex { get; set; }

            public Movies() { }


        
    }
}