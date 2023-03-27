using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{

[Route("api/[controller]")]
  [ApiController]
  public class GroupsController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public GroupsController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Group>>> Get()
    {
        return await _db.Groups.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> GetGroup(int id)
    {
        Group group = await _db.Groups.FindAsync(id);
        if (group == null)
        {
          return NotFound();
        }
        return group;
    }

    [HttpPost]
    public async Task<ActionResult<Group>> Post([FromBody]Group group)
    {
        _db.Groups.Add(group);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetGroup), new {id = group.GroupId}, group);
    }
  }
}
