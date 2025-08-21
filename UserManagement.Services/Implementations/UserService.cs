using System;
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

    public IEnumerable<User> Get(string id, long userID, User user)
    {
        switch (id)
        {
            case null: //default case
            case "all":
                return _dataAccess.GetAll<User>(); // returns all users if route id is equal to all users.
            case "active":
                return _dataAccess.GetAll<User>().Where(user => user.IsActive == true); // returns all active users if route id is equal to active users.
            case "nonActive":
                return _dataAccess.GetAll<User>().Where(user => user.IsActive == false); // returns all nonactive users if route id is equal to nonactive users.
            case "userID":
                return _dataAccess.GetAll<User>().Where(user => user.Id == userID); // returns the user that matches the user id for the user whose link was clicked.
            case "delete":
                var list = Get("all", userID, user);
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
            case "add":
                //create a new user
                _dataAccess.Create<User>(user);
                // return the list with the new user added to it
                return _dataAccess.GetAll<User>();
            case "edit":
                var users = Get("all", userID, user);
                foreach (var item in users)
                {
                    if (user.Id == userID)
                    {
                        _dataAccess.Update<User>(item);
                    }
                }
                return users;

        }
        throw new ArgumentException(); //if the id doesn't match any of these cases, this function shouldn't do anything
    }
}
