using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService 
{
    IEnumerable<User> Get(string id, long userID, User user);
    
    //void Add(User user);
}
