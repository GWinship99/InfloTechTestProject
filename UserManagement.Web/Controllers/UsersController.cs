using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;
    public ViewResult UserListToView(IEnumerable<User> users)
    {
        var items = users.Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View("List", model);
    }


    [Route("List")]
    public ViewResult List()
    {
        return UserListToView(_userService.GetAll());
    }


    [Route("ListActive")]
    public ViewResult ListActive()
    {
        return UserListToView(_userService.GetActive());
    }

    [Route("ListNonActive")]
    public ViewResult ListNonActive()
    {
        return UserListToView(_userService.GetNonactive());
    }

    [Route("ListByUserID")]
    public ViewResult ListByUserID(long userID)
    {
        return UserListToView(_userService.GetByUserID(userID));
    }

    [Route("Delete")]
    public ViewResult Delete(long userID)
    {
        return UserListToView(_userService.DeleteUser(userID));
    }

    [HttpPost]
    [HttpPut]
    [Route("Add")]
    public ViewResult Add(User user)
    {
        return UserListToView(_userService.AddUser(user));
    }

    [Route("Add")]
    public ViewResult OpenAddView()
    {

        return View("Add");
    }

    [HttpPost]
    [HttpPut]
    [Route("Edit")]
    public ViewResult Edit(User user)
    {
        return UserListToView(_userService.EditUser(user));
    }

    [Route("Edit")]
    public ViewResult OpenEditView(long userID, string forename, string surname, string email, bool isActive, string dateOfBirth)
    {
        var model = new UserListItemViewModel
        {
            Id = userID,
            Forename = forename,
            Surname=surname,
            Email = email,
            IsActive = isActive,
            DateOfBirth = dateOfBirth
        };

        return View("Edit", model);
    }

}
