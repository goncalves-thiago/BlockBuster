using BlockBuster.Entity;
using BlockBuster.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster.Util
{
    public class Menu
    {
        MovieValidation movieValidation = new MovieValidation();
        internal int _menuInt;
        internal string _menuString;
        internal Movie _menuObj;

        public string Show()
        {
            Console.Clear();
            Console.WriteLine("Welcome to BlockBuster Management");
            Console.WriteLine("");
            Console.WriteLine("(1) Add a Movie");
            Console.WriteLine("(2) List all movies");
            Console.WriteLine("(3) Update a movie");
            Console.WriteLine("(4) Delete a movie");
            Console.WriteLine("(5) Search for a movie");
            Console.WriteLine("(9) Quit");
            Console.WriteLine("");
            Console.Write("Choose an option: ");
            return Console.ReadLine();
        }

        public void ErrorInt()
        {
            Console.WriteLine("");
            Console.WriteLine("Error! ID must be an integer number.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public void ErrorIdExists()
        {
            Console.WriteLine("");
            Console.WriteLine("Error! ID already exists.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public void ErrorIdNotFound()
        {
            Console.WriteLine("");
            Console.WriteLine("Error! ID not found on database.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public void ListAllMovies(IList<Movie> _movies)
        {
            Console.Clear();
            Console.WriteLine("Movies List:");
            Console.WriteLine("");

            foreach (var movie in _movies)
            {
                Console.WriteLine(movie);
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        public void UpdateMovie(IList<Movie> _movies)
        {
            Console.Clear();
            Console.WriteLine("Update a movie:");
            Console.WriteLine("");
            Console.Write("Type movie ID to update: ");
            _menuString = Console.ReadLine();
                       
            if (!movieValidation.CheckInt(_menuString))
            {
                ErrorInt();
                return;
            }

            _menuInt = movieValidation.ConvertInt(_menuString);

            var obj = _movies.FirstOrDefault(m => m.Id == _menuInt);

            if (obj != null)
            {
                Console.WriteLine("");
                Console.WriteLine(obj);
                Console.WriteLine("");
                Console.Write("New Name: ");
                obj.Name = Console.ReadLine();
                Console.Write("New Director: ");
                obj.Director = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine($"Movie ID '{obj.Id}' updated successfully!");
                Console.WriteLine("");
                Console.WriteLine("Press any key to return...");
                Console.ReadLine();
            }
            else
            {
                ErrorIdNotFound();
            }
        }

        public void AddMovie(IList<Movie> _movies)
        {
            Console.Clear();
            Console.WriteLine("Add a movie:");
            Console.WriteLine("");
            Console.Write("ID: ");

            _menuString = Console.ReadLine();
            if (!movieValidation.CheckInt(_menuString))
            {
                ErrorInt();
                return;
            }

            _menuInt = movieValidation.ConvertInt(_menuString);

            if (_movies.FirstOrDefault(m => m.Id == _menuInt) != null)
            {
                ErrorIdExists();
                return;
            }

            Console.Write("Name: ");
            string menuAddName = Console.ReadLine();
            Console.Write("Director: ");
            string menuAddDirector = Console.ReadLine();
            _movies.Add(new Movie(_menuInt, menuAddName, menuAddDirector));
        }

        public void DeleteMovie(IList<Movie> _movies)
        {
            Console.Clear();
            Console.WriteLine("Delete a movie:");
            Console.WriteLine("");
            Console.Write("Type movie ID to delete: ");
            _menuString = Console.ReadLine();

            if (!movieValidation.CheckInt(_menuString))
            {
                ErrorInt();
                return;
            }

            _menuInt = movieValidation.ConvertInt(_menuString);
            _menuObj = _movies.FirstOrDefault(m => m.Id == _menuInt);

            if (_menuObj != null)
            {
                _movies.Remove(_menuObj);
                Console.WriteLine("");
                Console.WriteLine(_menuObj);
                Console.WriteLine("");
                Console.WriteLine($"Movie ID '{_menuObj.Id}' deleted successfully!");
                Console.WriteLine("");
                Console.WriteLine("Press any key to return...");
                Console.ReadLine();
                return;
            }
            else
            {
                ErrorIdNotFound();
                return;
            }
        }

         public void SearchMovie(IList<Movie> _movies)
        {
            Console.Clear();
            Console.WriteLine("Search for a movie:");
            Console.WriteLine("");
            Console.Write("Type movie ID to search: ");
            _menuString = Console.ReadLine();

            if (!movieValidation.CheckInt(_menuString))
            {
                ErrorInt();
                return;
            }

            _menuInt = movieValidation.ConvertInt(_menuString);
            _menuObj = _movies.FirstOrDefault(m => m.Id == _menuInt);

            if (_menuObj != null)
            {
                Console.WriteLine("");
                Console.WriteLine(_menuObj);
                Console.WriteLine("");
                Console.WriteLine("Press any key to return...");
                Console.ReadLine();
                return;
            }
            else
            {
                ErrorIdNotFound();
                return;
            }
        }
    }
}
