using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService 
{

    IEnumerable<User> GetAll();
    IEnumerable<User> GetActive();
    IEnumerable<User> GetNonactive();
    IEnumerable<User> GetByUserID(long userID);
    IEnumerable<User> DeleteUser(long userID);
    IEnumerable<User> AddUser(User user);
    IEnumerable<User> EditUser(User user);
}
