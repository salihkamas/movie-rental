using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<List<Movie>> GetAll();
        IDataResult<List<Movie>> GetByGenreId(int genreId);
        IResult Add(Movie movie);
        IResult Delete(Movie movie);
        IResult Update(Movie movie);
        IDataResult<List<MovieDetailDto>> GetMoviesDetails();
        IDataResult<Movie> GetByName(string movieName);
    }
}
