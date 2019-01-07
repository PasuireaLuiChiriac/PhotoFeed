using a_PhotoFeed.POCO;
using d_PhotoFeed.DTO;

namespace e_PhotoFeed.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO ReturnUserInfo(int userId);
        bool AddNewUser(UserDTO newUser);
        UserDTO LoginUser(LoginInfo userLoginInfo);
    }
}
