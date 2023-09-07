using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMessageLogger.DataAccess;
using MvcMessageLogger.Models;
using System.Security.Cryptography;
using System.Text;

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

            user.Password = user.GetDigestedPassword(user.Password);

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




        [Route("/users/{id:int}/login")]
        public IActionResult Login(User user)
        {
            

            return View(user);
        }



        [HttpPost]
        [Route("/users/{id:int}/login")]
        public IActionResult LoginAttemp(User user)
        {
            if(_context.Users.Any(e => e.Username == user.Username) && user.VerifyPassword(user.Password))
            {
                var userActual = _context.Users.Where(e => e.Username == user.Username).Single();

                return Redirect("/users/details/" + userActual.Id);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            

            
        }


    }
}
