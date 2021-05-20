using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class GenreManager : IGenreService
    {
        IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public IResult Add(Genre genre)
        {
            _genreDal.Add(genre);
            return new SuccessResult("Successfuly Added");
        }

        public IResult Delete(Genre genre)
        {
            _genreDal.Delete(genre);
            return new SuccessResult("Successfuly Deleted");
        }

        public IDataResult<List<Genre>> GetAll()
        {
            return new SuccessDataResult<List<Genre>>(_genreDal.GetAll());
        }

        public IDataResult<Genre> GetByName(string genreName)
        {
            return new SuccessDataResult<Genre>(_genreDal.Get(x => x.Name == genreName));
        }

        public IResult Update(Genre genre)
        {
            _genreDal.Update(genre);
            return new SuccessResult("Successfuly Updated");
        }
    }
}
