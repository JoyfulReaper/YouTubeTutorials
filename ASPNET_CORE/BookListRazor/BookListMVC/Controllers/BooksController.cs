using BookListMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext db;
        [BindProperty]
        public Book Book { get; set; }

        public BooksController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Book = new Book();

            if(id == null)
            {
                // Create
                return View(Book);
            }

            //Update
            Book = db.Book.FirstOrDefault(u => u.Id == id);

            if(Book == null)
            {
                return NotFound();
            }


            return View(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    //create
                    db.Book.Add(Book);
                }
                else
                {
                    db.Book.Update(Book);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Book);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await db.Book.FirstOrDefaultAsync(u => u.Id == id);

            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }

            db.Book.Remove(bookFromDb);
            await db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
