using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Models;
using LibraryProject.Data;
using Microsoft.AspNetCore.Authorization;

namespace LibraryProject.Controllers
{
    //[Authorize]
    public class BookPurchaseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookPurchaseController(ApplicationDbContext db)
        {
            _db = db;
        }
        //[Authorize(Roles = "User")]
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _db.Books;
            return View(objList);
        }
    }
}
