using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDirectorService
    {
        IDataResult<List<Director>> GetAll();
        IResult Add(Director director);
        IResult Delete(Director director);
        IResult Update(Director director);
        IDataResult<Director> GetByName(string directorName);
    }
}
