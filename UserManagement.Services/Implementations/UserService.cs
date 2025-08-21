using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    public IEnumerable<User> GetAll()
    {
        return _dataAccess.GetAll<User>(); // returns all users if route id is equal to all users.
    }

    public IEnumerable<User> GetActive()
    {
        return _dataAccess.GetAll<User>().Where(user => user.IsActive == true); // returns all active users if route id is equal to active users.
    }
    public IEnumerable<User> GetNonactive()
    {
        return _dataAccess.GetAll<User>().Where(user => user.IsActive != true);
    }

    public IEnumerable<User> GetByUserID(long userID)
    {
        return _dataAccess.GetAll<User>().Where(user => user.Id == userID);
    }

    public IEnumerable<User> DeleteUser(long userID)
    {
        var list = GetAll();
        foreach (var item in list)
        {
            // if the id matches
            if (item.Id == userID)
            {
                //delete the specified user 
                _dataAccess.Delete<User>(item);
            }
        }
        return list;
    }

    public IEnumerable<User> AddUser(User user)
    {
        //create a new user
        _dataAccess.Create<User>(user);
        // return the list with the new user added to it
        return _dataAccess.GetAll<User>();
    }

    public IEnumerable<User> EditUser(User user)
    {
        //create a new user
        _dataAccess.Update<User>(user);
        // return the list with the new user added to it
        return _dataAccess.GetAll<User>();
    }
}
