using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfMovieDal : EfEntityRepositoryBase<Movie, MovieRentalContext>, IMovieDal
    {
        public List<MovieDetailDto> GetMoviesDetails(Expression<Func<MovieDetailDto, bool>> filter = null)
        {
            using (MovieRentalContext context = new MovieRentalContext())
            {
                var result = from m in context.Movies
                             join d in context.Directors
                             on m.DirectorId equals d.Id
                             join g in context.Genres
                             on m.GenreId equals g.Id
                             select new MovieDetailDto
                             {
                                 MovieId = m.Id,
                                 DirectorId = d.Id,
                                 GenreId = g.Id,
                                 MovieName = m.Name,
                                 DirectorName = d.FirstName + " " + d.LastName,
                                 GenreName = g.Name,
                                 Title = m.Title,
                                 ReleaseYear = m.ReleaseYear,
                                 Rating = m.Rating,
                                 MovieLength = m.MovieLength,
                                 DailyPrice = m.dailyPrice
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
