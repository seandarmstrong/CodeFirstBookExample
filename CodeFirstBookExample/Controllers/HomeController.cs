using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeFirstBookExample.Models;
using CodeFirstBookExample.DAL;

namespace CodeFirstBookExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookContext _context = new BookContext();
        private readonly BookContext _contextInject;

        public HomeController(BookContext context)
        {
            _contextInject = context;
        }
        public IActionResult Index()
        {
            using(var context = new BookContext())
            {
                var book = new Book();
                context.Books.Add(book);
                context.SaveChanges();
            }

            _context.SaveChanges();
            
            return View();
        }

        public IActionResult Privacy()
        {
            using (var context = new BookContext())
            {

            }

                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _context.SaveChanges();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
