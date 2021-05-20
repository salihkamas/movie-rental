using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MovieDetailDto : IDto
    {
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string GenreName { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public double Rating { get; set; }
        public int MovieLength { get; set; }
        public double DailyPrice { get; set; }
    }
}
