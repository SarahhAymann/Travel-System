using System.Data.Entity;
using Travel.Models;

public class MyDbContext : DbContext
{
    public DbSet<Traveller> traveller { get; set; }
    public DbSet<Agencies> agencies { get; set; }
    public DbSet<Admin> admin { get; set; }
    public DbSet<UserInfo> users { get; set; }
    public DbSet<TripPosts> tripPosts { get; set; }
    public DbSet<PostsRequests>  postsRequests { get; set; }




    public MyDbContext()
        :base("Travle")
    {
    }
}