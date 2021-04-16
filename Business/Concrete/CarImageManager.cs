using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImage;
        public CarImageManager(ICarImageDal imageDal)
        {
            _carImage = imageDal;
        }
        public IResult Add(IFormFile file ,CarImage entity)
        {
            if (!BusinessRules.Run(NumberOfPictures(entity.CarId)))
            {
                return new ErrorResult(Messages.Invalid);
            }
            entity.ImagePath = FileHelper.Add(file);
            entity.Date = DateTime.Now;
            _carImage.Add(entity);
            return new SuccessResult(Messages.Adedd);
        }

        public IResult Delete(int id)
        {
            FileHelper.Delete(_carImage.Get(p => p.Id == id).ImagePath);
            _carImage.Delete(_carImage.Get(p => p.Id == id));
            return new SuccessResult(Messages.Adedd);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImage.GetAll(p=>p.CarId==id));
        }

        public IResult Updated(CarImage entity)
        {
            throw new NotImplementedException();
        }
        private bool NumberOfPictures(int carId)
        {
            var result = _carImage.GetAll(p => p.CarId == carId);
            if (result.Count >= 5)
            {
                return false;
            }
            return true;
        }
    }
}
