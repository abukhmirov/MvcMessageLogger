using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMessageLogger.DataAccess;
using MvcMessageLogger.Models;

namespace MvcMessageLogger.Controllers
{
    public class UsersController : Controller
    {
        private readonly MvcMessageLoggerContext _context;

        public UsersController(MvcMessageLoggerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.Users;
           
            return View(users);
        }

        public IActionResult New() 
        {
                    return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            

            return RedirectToAction("Index");
        }

        [Route("/users/details/{id:int}")]
        public IActionResult Details(int Id)
        {
            var user = _context.Users.Include(u => u.Messages).FirstOrDefault(u => u.Id == Id);
            
            return View(user);
        }

        
    }
}
