using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public UsersController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet("Admins")]
    [Authorize]
    public IActionResult AdminsEndpoint()
    {
      User currentUser = GetCurrentUser();
      return Ok($"Hi {currentUser.GivenName}, you are a(n) {currentUser.Role}");
    }

    private User GetCurrentUser()
    {
      var identity = HttpContext.User.Identity as ClaimsIdentity;

      if (identity != null)
      {
        var userClaims = identity.Claims;

        return new User
        {
          UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
          EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
          GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
          Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
          Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
        };
      }
      return null;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return await _db.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        User user = await _db.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new {id = user.UserId}, user);
    }

  }

}
