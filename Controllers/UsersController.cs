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
    [Authorize(Roles = "Administrator")]
    public IActionResult AdminsEndpoint()
    {
      ApplicationUser currentUser = GetCurrentUser();
      return Ok($"Hi {currentUser.GivenName}, you are a(n) {currentUser.Role}");
    }

    [HttpGet("Sellers")]
    [ Authorize(Roles = "Seller")]
    public IActionResult SellersEndpoint()
    {
      ApplicationUser currentUser = GetCurrentUser();
      return Ok($"Hi {currentUser.GivenName}, you are a(n) {currentUser.Role}");
    }

    [HttpGet("AdminsAndSellers")]
    [ Authorize(Roles = "Administrator, Seller")]
    public IActionResult AdminsAndSellersEndpoint()
    {
      ApplicationUser currentUser = GetCurrentUser();
      return Ok($"Hi {currentUser.GivenName}, you are a(n) {currentUser.Role}");
    }

    private ApplicationUser GetCurrentUser()
    {
      var identity = HttpContext.User.Identity as ClaimsIdentity;

      if (identity != null)
      {
        var userClaims = identity.Claims;

        return new ApplicationUser
        {
          UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
          Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
          GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
          Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
          Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
        };
      }
      return null;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationUser>>> Get()
    {
        return await _db.ApplicationUsers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationUser>> GetUser(int id)
    {
        ApplicationUser user = await _db.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<ApplicationUser>> Post(ApplicationUser user)
    {
        _db.ApplicationUsers.Add(user);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new {id = user.UserId}, user);
    }

  }

}
