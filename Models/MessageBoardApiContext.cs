using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MessageBoard.Models;

public class MessageBoardApiContext : IdentityDbContext<ApplicationUser>
{
  public DbSet<Group> Groups {get;set;}
  public DbSet<Post> Posts {get;set;}
  public DbSet<ApplicationUser> ApplicationUsers {get;set;}

  public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options) : base(options) 
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Group>()
        .HasData(
          new Group { GroupId = 1, GroupName = "Gossip"}
        );
      builder.Entity<ApplicationUser>()
        .HasData(
          new ApplicationUser {UserId = 2, UserName = "jason_admin", Email = "jason.admin@email.com", Password = "MyPass_w0rd", GivenName = "Jason", Surname = "Bryant", Role = "Administrator" },
          new ApplicationUser() {UserId = 3, UserName = "elyse_seller", Email = "elyse.seller@email.com", Password = "MyPass_w0rd", GivenName = "Elyse", Surname = "Lambert", Role = "Seller" }
        );
    }
}
