using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; } 

        public async Task OnGet(int id)
        {
            Book = await db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var bookFromDb = await db.Book.FindAsync(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.Author = Book.Author;
                bookFromDb.ISBN = Book.ISBN;

                await db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
