using BlockBuster.Entity;
using BlockBuster.Util;

namespace BlockBuster
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Movie> movies = new List<Movie>();
            Menu menu = new Menu();
            
            string menuRead = "0";

            while (menuRead != "9")
            {
               menuRead = menu.Show();

                switch (menuRead)
                {
                    case "1":
                        menu.AddMovie(movies);
                        break;

                    case "2":
                        menu.ListAllMovies(movies);
                        break;

                    case "3":
                        menu.UpdateMovie(movies);
                        break;

                    case "4":
                        menu.DeleteMovie(movies);
                        break;

                    case "5":
                        menu.SearchMovie(movies);
                        break;

                    default:
                        break;

                }
             }
        }
    }
}