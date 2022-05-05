using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public User GetByID(int id)
        {
            return _userdal.Get(x => x.UserID == id);
        }

        public List<User> GetList()
        {
            return _userdal.List();
        }

        public void UserAdd(User user)
        {
            _userdal.Insert(user);
        }

        public void UserDelete(User user)
        {
            _userdal.Delete(user); 
        }

        public void UserUptade(User user)
        {
            _userdal.Update(user);
        }
    }
}
