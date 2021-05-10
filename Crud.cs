using System;
using System.Linq;
using Assignment13.Context;
using Assignment13.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment13
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
        public void AddUser()
        {
            Console.WriteLine("Enter user name: ");
            var uName = Console.ReadLine();

            Console.WriteLine("Enter user age: ");
            var uAge = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter user gender: ");
            var uGender = Console.ReadLine();

            Console.WriteLine("\nEnter user zipcode: ");
            var uZipCode = Console.ReadLine();

            Console.WriteLine("\nEnter user occupation: ");
            var uOccupation = Console.ReadLine();

            using(var db = new MovieContext())
            {
                var foundOccupation = db.Occupations.Where(occ => occ.Name.Contains(uOccupation))
                .FirstOrDefault();
                if(foundOccupation == null)
                {
                    foundOccupation = db.Occupations.Where(occ => occ.Name == ("Other")).FirstOrDefault();
                }

                var user = new User()
                {
                    //Name = uName,
                    Age = uAge,
                    Gender = uGender,
                    ZipCode = uZipCode,
                    Occupation = foundOccupation
                };    

                Console.WriteLine($"User added: Age - {user.Age} | Gender - {user.Gender} | ZipCode - {user.ZipCode}");            

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void SearchUser()
        {
          using (var db = new MovieContext()) 
            {
               var selectedUser = db.Users.Where(x=> x.Id == 1);
                var users = selectedUser.Include(x=>x.UserMovies).ThenInclude(x=>x.Movie).ToList();

                foreach (var user in users)
                {
                    System.Console.WriteLine($"Added user: ({user.Id}) {user.Gender} {user.Occupation.Name}");

                    foreach (var movie in user.UserMovies.OrderBy(x=>x.Rating)) 
                    {
                        System.Console.WriteLine($"\t\t\t{movie.Rating} {movie.Movie.Title}");
                    }
                }  
            }
        }

        public void AddOccupation()
        {
            System.Console.WriteLine("Enter NEW Occupation Name: ");
            var occ2 = Console.ReadLine();

            using (var db = new MovieContext())
            {
                var occupation = new Occupation();
                db.Occupations.Add(occupation);
                db.SaveChanges();

            var newOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ2);
            System.Console.WriteLine($"({newOccupation.Id}) {newOccupation.Name}");
            }
        }

        public void ViewOccupation()
        {
            System.Console.WriteLine("Enter Occupation Name: ");
             var occ = Console.ReadLine();

             using (var db = new MovieContext())
             {
                 var occupation = db.Occupations.FirstOrDefault(x => x.Name == occ);
                 System.Console.WriteLine($"({occupation.Id}) {occupation.Name}");
             }
        }

        public void UpdateOccupation()
        {
            System.Console.WriteLine("Enter Occupation Name to Update: ");
            var occ3 = Console.ReadLine();

            System.Console.WriteLine("Enter Updated Occupation Name: ");
            var occUpdate = Console.ReadLine();

            using (var db = new MovieContext())
            {
                var updateOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ3);
                System.Console.WriteLine($"({updateOccupation.Id}) {updateOccupation.Name}");

                updateOccupation.Name = occUpdate;

                db.Occupations.Update(updateOccupation);
                db.SaveChanges();

            } 
        }

        public void DeleteOccupation()
        {
            System.Console.WriteLine("Enter Occupation Name to Delete: ");
            var occ4 = Console.ReadLine();

            using (var db = new MovieContext())
            {
                 var deleteOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ4);
                 System.Console.WriteLine($"({deleteOccupation.Id}) {deleteOccupation.Name}");

            
                 db.Occupations.Remove(deleteOccupation);
                 db.SaveChanges();
            }
        }
        public void AddRatings()
        {

        }
        public void SearchRating()
        {

        }
        public void UpdateRating()
        {

        }
        public void DeleteRating()
        {
            
        }


    }
}