using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions
    {
        public static Movie GetMovieByID(int id)
        {
            using (var db = new Se407BlockBusterContext())
            {
                return db.Movies.Find(id);
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using (var db = new Se407BlockBusterContext())
            {
                return db.Movies.ToList();
            }
        }

        public static List<Movie> GetAllCheckedOutMovies()
        {
            using (var db = new Se407BlockBusterContext())
            {
                return db.Movies
                .Join(db.Transactions,
                    m => m.MovieId,
                    t => t.Movie.MovieId,
                    (m, t) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId,
                        CheckedIn = t.CheckedIn
                    }).Where(w => w.CheckedIn == "N")
                .Select(n => new Movie
                {
                    MovieId = n.MovieId,
                    Title = n.Title,
                    ReleaseYear = n.ReleaseYear,
                    GenreId = n.GenreId,
                    DirectorId = n.DirectorId
                })
                .ToList();
            }
        }

        public static List<FullMovieListGenre> GetAllMoviesByGenreDescription(string genreDescr)
        {
            using (var db = new Se407BlockBusterContext())
            {
                if (string.IsNullOrWhiteSpace(genreDescr))
                    return new List<FullMovieListGenre>(); // Return an empty list if input is invalid.

                return db.FullMovieListGenres
                    .Where(m => m.GenreDescr.ToLower() == genreDescr.ToLower())
                    .ToList();
            }
        }

        public static List<FullMovieListGenre> GetAllMoviesByDirectorLastName(string lastName)
        {
            using (var db = new Se407BlockBusterContext())
            {
                if (string.IsNullOrWhiteSpace(lastName))
                    return new List<FullMovieListGenre>(); // Return an empty list if input is invalid.
                return db.FullMovieListGenres
                    .Where(m => m.LastName.ToLower() == lastName.ToLower())
                    .ToList();
            }
        }



    }

}
