using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICrudService<TEntity>
    {
        IResult Add(TEntity entity);
        IResult Delete(TEntity entity);
        IResult Updated(TEntity entity);
    }
}
