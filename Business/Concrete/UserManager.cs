using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager  : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IResult Updated(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
