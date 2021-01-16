using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext db;

        public BookController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await db.Book.FirstOrDefaultAsync(u => u.Id == id);

            if(bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }

            db.Book.Remove(bookFromDb);
            await db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
