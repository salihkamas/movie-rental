using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public IResult Add(Movie movie)
        {
            _movieDal.Add(movie);
            return new SuccessResult("Successfuly Added");
        }

        public IResult Delete(Movie movie)
        {
            _movieDal.Delete(movie);
            return new SuccessResult("Successfuly Deleted");
        }

        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(), "Successfuly listed");
        }

        public IDataResult<List<Movie>> GetByGenreId(int genreId)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(m => m.GenreId == genreId));
        }

        public IDataResult<Movie> GetByName(string movieName)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(x => x.Name == movieName));
        }

        public IDataResult<List<MovieDetailDto>> GetMoviesDetails()
        {
            return new SuccessDataResult<List<MovieDetailDto>>(_movieDal.GetMoviesDetails(), "succesfuly listed");
        }

        public IResult Update(Movie movie)
        {
            _movieDal.Update(movie);
            return new SuccessResult("Succesfuly Updated");
        }
    }
}
