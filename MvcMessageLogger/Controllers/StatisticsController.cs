using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMessageLogger.DataAccess;
using MvcMessageLogger.Models;


namespace MvcMessageLogger.Controllers
{

    public class StatisticsController : Controller
    {
        private readonly MvcMessageLoggerContext _context;

        public StatisticsController(MvcMessageLoggerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Users message number and Order by most messages to least
            var usersOrderedByMessageCount = _context.Users
                .Include(u => u.Messages)
                .Select(u => new
                {
                    UserName = u.Name,
                    MessageCount = u.Messages.Count
                })
                .OrderByDescending(vm => vm.MessageCount)
                .ToList();

            ViewBag.UsersOrderedByMessageCount = usersOrderedByMessageCount;



            // Most common message overall
            var mostCommonMessage = _context.Messages
             .GroupBy(m => m.Content)
             .OrderByDescending(g => g.Count())
             .Select(g => g.Key)
             .First();

            ViewBag.MostCommonMessage = mostCommonMessage;



            //Most common word overall
            var messages = _context.Messages.Select(m => m.Content).AsEnumerable();

            var mostCommonWord = messages
                .SelectMany(m => m.Split(new[] { ' ', '.', ',', '!', '?' }))
                .GroupBy(word => word.ToLower())
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefault();

            ViewBag.MostCommonWord = mostCommonWord;



            // Hour with the most messages
            var hourWithMostMessages = _context.Messages
                .GroupBy(m => m.CreatedAt.Hour)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .First();

            // Format the hour and assign it to ViewBag
            ViewBag.HourWithMostMessages = new DateTime(1, 1, 1, hourWithMostMessages, 0, 0)
                .ToString("h:mm tt");



            // Busiest day of the week
            var busiestDayOfWeek = _context.Messages
                .GroupBy(m => m.CreatedAt.DayOfWeek)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .First();

            ViewBag.BusiestDayOfWeek = busiestDayOfWeek;




            // Most common word by user
            var mostCommonWordByUser = _context.Users
    .Select(u => new
    {
        UserName = u.Name,
        Messages = u.Messages.Select(m => m.Content)
    })
    .ToList() // Execute the query to retrieve user data
    .Select(u => new
    {
        UserName = u.UserName,
        MostCommonWord = u.Messages
            .SelectMany(content => content.Split(new[] { ' ', '.', ',', '!', '?' }))
            .GroupBy(word => word.ToLower())
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key)
            .FirstOrDefault()
    })
    .ToList();

            ViewBag.MostCommonWordByUser = mostCommonWordByUser;

            return View();



        }


    }
}
