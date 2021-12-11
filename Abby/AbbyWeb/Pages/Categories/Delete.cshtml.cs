using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Category = _context.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {

            var categoryDb = _context.Categories.Find(Category.Id);
            if(categoryDb != null)
            {
                _context.Categories.Remove(categoryDb);
                await _context.SaveChangesAsync();

                TempData["success"] = "Category Deleted Successfully!";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
