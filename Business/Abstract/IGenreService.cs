using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGenreService
    {
        IDataResult<List<Genre>> GetAll();
        IResult Add(Genre genre);
        IResult Delete(Genre genre);
        IResult Update(Genre genre);
        IDataResult<Genre> GetByName(string genreName);
    }
}
