using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : ICrudService<Car>
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int Id);
    }
}
