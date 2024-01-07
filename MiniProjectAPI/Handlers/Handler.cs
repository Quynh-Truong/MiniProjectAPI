using MiniProjectAPI.Data;
using MiniProjectAPI.Models;
using MiniProjectAPI.Models.DTO;
using MiniProjectAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mime;

namespace MiniProjectAPI.Handlers
{
    public class Handler
    {
        //All methods used for API are stored here
        public static IResult ListUsers(ApplicationContext context)
        {
            UserViewModel[] result = context.Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                }).ToArray();

            return Results.Json(result);
        }
        public static IResult ListUserInterests(ApplicationContext context, int userId)
        {
            User? user = context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Interests)
                .SingleOrDefault();

            if (user == null)
            {
                return Results.NotFound();
            }

            if (user.Interests == null)
            {
                return Results.NotFound();
            }

            InterestViewModel[] result = user.Interests
                .Select(i => new InterestViewModel()
                {
                    Title = i.Title,
                    Description = i.Description,
                }).ToArray();

            return Results.Json(result);
        }

        public static IResult ListUserInterestLinks(ApplicationContext context, int userId)
        {
            User? user = context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.InterestLinks)
                .SingleOrDefault();

            if (user == null)
            {
                return Results.NotFound();
            }

            InterestLinkViewModel[] result = user.InterestLinks
                .Select(i => new InterestLinkViewModel()
                {
                    Link = i.Link,
                }).ToArray();

            return Results.Json(result);
        }

        public static IResult CreateNewInterest(ApplicationContext context, InterestDto interest)
        {
            context.Interests.Add(new Interest()
            {
                Title = interest.Title,
                Description = interest.Description,
            });

            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }


        public static IResult ConnectInterestToUser(ApplicationContext context, int userId, int interestId)
        {
            User? user = context.Users
                .Include(u => u.Interests)
                .SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return Results.NotFound();
            }

            Interest? interest = context.Interests
                .SingleOrDefault(i => i.Id == interestId);

            if (interest == null)
            {
                return Results.NotFound();
            }

            user.Interests.Add(interest);
            context.SaveChanges();
            return Results.StatusCode((int)(HttpStatusCode.Created));

        }


        public static IResult ConnectInterestLinkToUserAndInterest(ApplicationContext context, int userId, int interestId, InterestLinkDto link)
        {
            User? user = context.Users
                .Include(u => u.InterestLinks)
                .SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return Results.NotFound();
            }

            Interest? interest = context.Interests
                .Include(i => i.InterestLinks)
                .SingleOrDefault(i => i.Id == interestId);

            if (interest == null)
            {
                return Results.NotFound();
            }

            var newInterestLink = new InterestLink
            {
                Link = link.Link
            };

            user.InterestLinks.Add(newInterestLink);
            interest.InterestLinks.Add(newInterestLink);
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);


        }
    }
}
