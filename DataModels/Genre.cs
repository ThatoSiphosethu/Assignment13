using System;
using System.Collections.Generic;

namespace Assignment13.DataModels
{
    public class Genre
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres {get;set;}
    }
}