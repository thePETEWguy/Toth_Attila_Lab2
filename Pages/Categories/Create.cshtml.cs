using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Toth_Attila_Lab2.Data;
using Toth_Attila_Lab2.Models;

namespace Toth_Attila_Lab2.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Toth_Attila_Lab2.Data.Toth_Attila_Lab2Context _context;

        public CreateModel(Toth_Attila_Lab2.Data.Toth_Attila_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
