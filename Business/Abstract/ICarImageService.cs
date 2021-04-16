﻿using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService 
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(int id);
        IDataResult<List<CarImage>> GetByCarId(int id);
    }
}
