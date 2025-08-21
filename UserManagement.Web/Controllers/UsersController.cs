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

    [HttpGet]
    public ViewResult List(string id, long userID, User user)
    {
        var items = _userService.Get(id, userID, user).Select(p => new UserListItemViewModel
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
    [HttpPost]
    [HttpPut]
    public ViewResult Add(User user)
    {
        return List("add",0,user);
    }

    //[HttpPost]
    //public ViewResult Edit(long userID)
    //{

    //}
    [Route("Add")]
    public ViewResult OpenAddView()
    {

        return View("Add");
    }

}
