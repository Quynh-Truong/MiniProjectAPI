using Microsoft.EntityFrameworkCore;
using MiniProjectAPI.Data;
using MiniProjectAPI.Handlers;

namespace MiniProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

          
            app.MapGet("/user", Handler.ListUsers);
            app.MapGet("/interest/{userId}", Handler.ListUserInterests);
            app.MapGet("/interest-link/{userId}", Handler.ListUserInterestLinks);

            app.MapPost("/interest/create", Handler.CreateNewInterest);
            app.MapPost("/user/{userId}/interest/{interestId}", Handler.ConnectInterestToUser);
            app.MapPost("/user/{userId}/interest/{interestId}/interest-link", Handler.ConnectInterestLinkToUserAndInterest);


            app.Run();
        }
    }
}