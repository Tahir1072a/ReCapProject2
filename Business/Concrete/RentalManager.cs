using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental entity)
        {
            var result = _rentalDal.GetAll(p => p.CarId == entity.CarId).Where(p => p.ReturnDate == null).ToList();
            if (result.Count == 0)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Adedd);
            }
            return new ErrorResult(Messages.Invalid);
        }

        public IResult Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Updated(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
