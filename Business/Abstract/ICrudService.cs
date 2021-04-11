using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICrudService<TEntity>
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Updated(TEntity entity);
    }
}
