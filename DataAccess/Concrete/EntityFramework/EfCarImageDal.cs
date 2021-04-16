﻿using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage,ReCapProject2Context>,ICarImageDal
    {
    }
}
