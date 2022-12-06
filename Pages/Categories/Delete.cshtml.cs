using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetRazorPage.Data;
using ASPNetRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ASPNetRazorPage.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // neu de dong nay thi OnPostAsync(Category category) -> OnPostAsync() va AddAsync(category)->AddAsync(Category)
        // [BindProperty]

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Category = _context.Categories.Find(id);
            // Category = _context.Categories.FirstOrDefault(x => x.Id == id);
            // Category = _context.Categories.SingleOrDefault(x => x.Id == id);
            // Category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {   
            var categoryDb = _context.Categories.Find(id);
            if (categoryDb != null)
            {
                _context.Categories.Remove(categoryDb);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}