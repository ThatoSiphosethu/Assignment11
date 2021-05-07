using System;
using System.Linq;
using Assignment11.Context;
using Assignment11.DataModels;

namespace Assignment11
{
    public class Crud
    { 
        public void CreateMovie()
        {
            Console.Write("Add movie title: ");
            var createTitle = Console.ReadLine();

            Console.Write("Add release date: ");
            var createReleaseDate = System.Console.ReadLine();
           
            using(var db = new MovieContext())
            {
                var movie = new Movie()
                {
                    Title = createTitle,
                    ReleaseDate = Convert.ToDateTime(createReleaseDate)
                };    

                Console.WriteLine($"Movie created: Title {movie.Title} ; Release Date {movie.ReleaseDate}");            

                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        public void ReadMovie()
        {
            Console.Write("Read movie title: ");
            var readMovie = Console.ReadLine();

            using(var db = new MovieContext())
            {
                var movieFound = db.Movies.Where(x => x.Title.Contains(readMovie));

                foreach (var movie in movieFound)
                {
                    Console.WriteLine($"Movie Title found: {movie.Title}");
                }
            }
        }

        public void UpdateMovie()
        {
            Console.Write("Enter movie title: ");
            var movieTitle = Console.ReadLine();

            Console.Write("Enter new movie title: ");
            var newTitle = Console.ReadLine();

            Console.Write("Enter Update movie release date: ");
            var newReleaseDate = Console.ReadLine();
            
            using(var db = new MovieContext())
            {
                var movieFound = db.Movies.Where(x => x.Title.Contains(movieTitle))
                .FirstOrDefault();

                movieFound.Title = newTitle;
                movieFound.ReleaseDate = Convert.ToDateTime(newReleaseDate);

                Console.WriteLine($"New movie details:  Title {movieFound.Title} ; Release Date {movieFound.ReleaseDate}");

                db.Movies.Update(movieFound);
                db.SaveChanges(); 
            }
        }

        public void DeleteMovie()
        {
            Console.Write("Enter movie title: ");
            var deleteTitle = Console.ReadLine();            

            using (var db = new MovieContext())
            {
                var deleteMovie = db.Movies.FirstOrDefault(x => x.Title == deleteTitle);
                
                Console.WriteLine($"Movie deleted: Title {deleteMovie.Title} ; Release Date {deleteMovie.ReleaseDate}");
               
                db.Movies.Remove(deleteMovie);
                db.SaveChanges();
            }  
        }


    }
}