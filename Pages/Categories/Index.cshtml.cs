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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Categories = _context.Categories;
        }
    }
}