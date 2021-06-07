using System.Data.Entity;
using Travel.Models;

public class MyDbContext : DbContext
{
    
    public DbSet<UserInfo> users { get; set; }
    public DbSet<TripPosts> tripPosts { get; set; }
    public DbSet<PostsRequests>  postsRequests { get; set; }




    public MyDbContext()
        :base("Travle")
    {
    }
}