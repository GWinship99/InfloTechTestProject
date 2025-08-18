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

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public IEnumerable<User> Get(string id)
    {
        switch (id)
        {
            case null:
            case "all":
                return _dataAccess.GetAll<User>(); 
            case "active":
                return _dataAccess.GetAll<User>().Where(user => user.IsActive == true);
            case "nonActive":
                return _dataAccess.GetAll<User>().Where(user => user.IsActive == false);

        }
        throw new ArgumentException();
    }
}
