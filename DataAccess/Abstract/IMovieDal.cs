using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IMovieDal : IEntityRepository<Movie>
    {
        List<MovieDetailDto> GetMoviesDetails(Expression<Func<MovieDetailDto, bool>> filter = null);
    }
}
