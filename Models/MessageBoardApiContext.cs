using Microsoft.EntityFrameworkCore;
namespace MessageBoard.Models;

public class MessageBoardApiContext : DbContext
{
  public DbSet<Group> Groups {get;set;}
  public DbSet<Post> Posts {get;set;}
  public DbSet<User> Users {get;set;}

  public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options) : base(options) 
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Group>()
        .HasData(
          new Group { GroupId = 1, GroupName = "Gossip"}
        );
    }
}
