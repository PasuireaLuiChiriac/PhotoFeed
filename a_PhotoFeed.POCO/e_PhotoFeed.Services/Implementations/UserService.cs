using System;
using System.Linq;
using a_PhotoFeed.POCO;
using AutoMapper;
using c_PhotoFeed.Repository.Interfaces;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Exceptions;
using e_PhotoFeed.Services.Interfaces;

namespace e_PhotoFeed.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserDTO ReturnUserInfo(int userId)
        {
            return Mapper.Map<User,UserDTO>(_uow.Users.Find(x => x.IdUser == userId).FirstOrDefault());
        }

        public bool AddNewUser(UserDTO newUser)
        {
            //check unique email
            if (!_uow.Users.Exists(x => x.Email == newUser.Email))
            {
                _uow.Users.Add(Mapper.Map<UserDTO, User>(newUser));
                _uow.Users.Save();
                return true;
               // return _uow.Users.Find(x => x.Email == newUser.Email).First(); //for User return type
            }
            else
                throw new AccountExistsException("there already is an account using this email");
        }

        public UserDTO LoginUser(LoginInfo userLoginInfo)
        {
            if (_uow.Users.Exists(x => (x.Email == userLoginInfo.Email) && (x.Password == userLoginInfo.Password)))
                return Mapper.Map<User, UserDTO>(_uow.Users.Find(x => (x.Email == userLoginInfo.Email) && (x.Password == userLoginInfo.Password)).FirstOrDefault());
            else
                throw new BadLoginCredentialsException("No user with the specified credentials");
        }

    }
}
