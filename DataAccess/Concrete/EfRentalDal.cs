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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MovieRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (MovieRentalContext context = new MovieRentalContext())
            {
                var result = from r in context.Rentals
                             join m in context.Movies
                             on r.MovieId equals m.Id
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 MovieId = m.Id,
                                 CustomerId = c.Id,
                                 MovieName = m.Name,
                                 CustomerName = c.FirstName + " " + c.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
