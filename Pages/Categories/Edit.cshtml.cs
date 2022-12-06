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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // neu de dong nay thi OnPostAsync(Category category) -> OnPostAsync() va AddAsync(category)->AddAsync(Category)
        // [BindProperty]

        public Category Category { get; set; }
        public EditModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}