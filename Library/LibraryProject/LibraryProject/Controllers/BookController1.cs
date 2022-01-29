using LibraryProject.Data;
using LibraryProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Controllers
{
    //[Authorize]
    public class BookController1 : Controller
    {
        private readonly ApplicationDbContext _db;
         public BookController1(ApplicationDbContext db)
        {
            _db = db;
        }

        // [Authorize(Roles = "Admin")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _db.Books;
            return View(objList);
        }
        public IActionResult BookList()
        {
            IEnumerable<Book> objList = _db.Books;
            return View(objList);
        }
        //for user
        public IActionResult AllBooks()
        {
            IEnumerable<Book> objList = _db.Books;
            return View(objList);
        }
        //GET create
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

     
        //POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book obj)
        {
            _db.Books.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book obj = _db.Books.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
 
        public IActionResult Update(Book obj)
        {
            _db.Books.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


      
        [HttpGet]
        public IActionResult Delete(int? id)
        {
           
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book obj = _db.Books.Find(id);
            return View(obj);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            Book obj = _db.Books.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Books.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
