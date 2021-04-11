using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.Repositories
{
    // Kodumuzu professionalleştiriyoruz.
    // Burada generic constraint yapacağız
    // Yani T sadece entity türünde olacak ve bu bir class olacak.
    public interface IEntityRepository<T> where T :class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity); 
    }
}
