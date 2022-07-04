using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster.Entity
{
    public class Movie
    {
        private int id;
        private string name;
        private string director;

        public Movie(int id, string name, string director)
        {
            this.id = id;
            this.name = name;
            this.director = director;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Director { get => director; set => director = value; }

        public override string ToString()
        {
            return $"ID: {id} - Name: {name} - Director: {director}";
        }
    }
}
