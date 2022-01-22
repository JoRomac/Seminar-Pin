using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Data;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCart(int? id)
        {
            Book obj = new Book();
            IEnumerable<Book> objList = _db.Books;
            foreach(var o in objList)
            {
                if (o.Id.Equals(id))
                    return View(o);
            }
            
            return View();
        }
    }
}
