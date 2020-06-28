using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch9_Delegates
{
    class MovieList
    {
        class Film
        {
            public string Name { get; set; }
            public int Year { get; set; }
        }

        public static void Example_Film()
        {
            var films = new List<Film>
            {
                new Film {Name = "Jaws", Year = 1975 },
                new Film {Name = "Singing in the Rain", Year = 1952 },
                new Film {Name = "Some like it hot", Year = 1959 },
                new Film {Name = "The wizard of oz", Year = 1939 },

                new Film {Name = "It is a wonderful life", Year = 1946 },
                new Film {Name = "American beauty", Year = 1999 },
                new Film {Name = "High Fidelity", Year = 2000 },
                new Film {Name = "The Usual Suspects", Year = 1995 },
            };
            Action<Film> print = film => Console.WriteLine("Name = {0}, Year = {1}", film.Name, film.Year);

            Console.WriteLine("---- Raw sort print: ----");
            films.ForEach(print);

            Console.WriteLine("---- Year sort print: ----");
            films.FindAll(film => film.Year > 1960).ForEach(print);

            Console.WriteLine("---- Name sort print: ----");
            films.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
            films.ForEach(print);
        }
    }
}
