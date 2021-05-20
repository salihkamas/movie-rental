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
    public class DirectorManager : IDirectorService
    {
        IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public IResult Add(Director director)
        {
            _directorDal.Add(director);
            return new SuccessResult("Successfuly Added");
        }

        public IResult Delete(Director director)
        {
            _directorDal.Delete(director);
            return new SuccessResult("Successfuly Deleted");
        }

        public IDataResult<List<Director>> GetAll()
        {
            return new SuccessDataResult<List<Director>>(_directorDal.GetAll());
        }

        public IDataResult<Director> GetByName(string directorName)
        {
            return new SuccessDataResult<Director>(_directorDal.Get(x => x.FirstName + " " + x.LastName == directorName));
        }

        public IResult Update(Director director)
        {
            _directorDal.Update(director);
            return new SuccessResult("Successfuly Updated");
        }
    }
}
