using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using JsonPatchSample;

namespace MessageBoard.Controllers
{
[Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private readonly MessageBoardApiContext _db;

    public PostsController(MessageBoardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> Get()
    {
        return await _db.Posts
        // .Include(thingy => thingy.Group)
        // .Include(thingy=> thingy.User)
        // .AsQueryable()
        .ToListAsync();
    }

    /*
    Found the Problem: (putting it here so I remember after lunch)
    
    Your navigation property would have been declared as an ICollection, standard for Entity properties -- the compiler won't be pleased.

    However, you can get an IQueryable with AsQueryable or with another Select() (if that makes sense for your needs) between the navigation collection and the ToListAsync().

    ToList() can operate on IEnumerable (which includes ICollection and IQueryable). ToListAsync() has only been made to work with IQueryable, hence the message from VS. The "why" may lie in the implementation details.
    */

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        Post post = await _db.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();

        }
        return post;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> Post(Post post)
    {
        _db.Posts.Add(post);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPost), new {id = post.PostId}, post);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Post post)
    {
      if (id != post.PostId)
      {
        return BadRequest();
      }

      _db.Posts.Update(post);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PostExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool PostExists(int id)
    {
      return _db.Posts.Any(e => e.PostId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
      Post post = await _db.Posts.FindAsync(id);
      if (post == null)
      {
        return NotFound();
      }

      _db.Posts.Remove(post);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }

}
