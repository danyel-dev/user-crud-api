using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using user_crud_api.Domain;
using user_crud_api.Domain.Dto;
using user_crud_api.Domain.Model;
using user_crud_api.Domain.Profiles;

namespace User_crud_api.Controllers;


[ApiController]
[Route("/users")]
public class UserController : ControllerBase
{
    private UserCrudContext _context;
    private IMapper _mapper;

    public UserController(UserCrudContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _context.Users
            .Where(user => user.isActive)
            .Select(user => _mapper.Map<UserProfileDto>(user))
            .ToList();

        if(users.Count == 0) 
            return NotFound();

        return Ok(users);
    }

    [HttpGet]
    [Route("/{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);

        if(user == null) return NotFound(new
        {
            Moment = DateTime.Now,
            Message = $"Cannot find user with id = {id}." 
        });

        var userProfile = _mapper.Map<UserProfileDto>(User);

        return Ok(userProfile);
    }

    [HttpPost]
    public IActionResult RegisterUser([FromBody] UserRegisterDto userRegisterDto)
    {
        var userToRegister = _mapper.Map<User>(userRegisterDto);

        _context.Users.Add(userToRegister);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUserById), new { id = User.Id }, UserProfileTdo);
    }
}





