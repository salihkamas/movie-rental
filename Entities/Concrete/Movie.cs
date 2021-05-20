using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public double Rating { get; set; }
        public int MovieLength { get; set; }
        public double dailyPrice { get; set; }
    }
}
