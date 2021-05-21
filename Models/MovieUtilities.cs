using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCDEMO2.Models
{
    public class MovieUtilities
    {
        string conString = "Data Source=bisiisdev;Initial Catalog=dbMovies00;User ID=bisstudent;Password=bobby2013";

        public Movie getMovieByID(int id)
        {

            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Id,Title,Director FROM Movies where Id=@Id";
            cmd.Parameters.AddWithValue("Id", id);

            List<Movie> movies = new List<Movie>();

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movie m = new Movie(
                        Convert.ToInt32(reader["Id"]),
                        reader["Title"].ToString(),
                        reader["Director"].ToString()
                    );
                movies.Add(m);
            }
            return movies[0];

        }
        public Movies getAllMovies()
        {

            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Id,Title,Director FROM Movies";

            List<Movie> ms = new List<Movie>();

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movie m = new Movie(
                        Convert.ToInt32(reader["Id"]),
                        reader["Title"].ToString(),
                        reader["Director"].ToString()

                    );
                ms.Add(m);
            }
            Movies allMovies = new Movies();
            allMovies.Items = ms;





            return allMovies;


        }


        public int setMovieToEditMode(List<Movie> movies, int id)
        {

            int editIndex = 0;
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    m.IsEditable = true;
                    return editIndex;
                }
                editIndex++;
            }
            return -1;
        }

        public void updateMovie(Movie MovieToUpdate)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Movies SET Title=@Title,Director=@Director WHERE Id=@Id";
            cmd.Parameters.AddWithValue("@Title", MovieToUpdate.Title);
            cmd.Parameters.AddWithValue("@Director", MovieToUpdate.Director);
            cmd.Parameters.AddWithValue("@Id", MovieToUpdate.Id);
            con.Open();
            cmd.ExecuteNonQuery();
           
        }

        public void MovieDelete(int id)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "DELETE FROM Movies WHERE Id=@Id";

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            
        }

        public void addMovie(Movie m)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Movies (Title, Director) VALUES (@Title, @Director) ";
            cmd.Parameters.AddWithValue("@Title", m.Title);
            cmd.Parameters.AddWithValue("@Director", m.Director);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}