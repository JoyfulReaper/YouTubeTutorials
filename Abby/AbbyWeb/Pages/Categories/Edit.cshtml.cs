using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Category = _context.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.TryAddModelError("Category.Name", "The DisplayOrder cannot exactly match the name!");
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Update(Category);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
