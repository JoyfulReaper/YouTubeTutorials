using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.TryAddModelError("Category.Name", "The DisplayOrder cannot exactly match the name!");
            }

            if (ModelState.IsValid)
            {
                await _context.Categories.AddAsync(Category);
                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
