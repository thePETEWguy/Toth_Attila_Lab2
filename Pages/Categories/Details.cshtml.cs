using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Toth_Attila_Lab2.Data;
using Toth_Attila_Lab2.Models;

namespace Toth_Attila_Lab2.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Toth_Attila_Lab2.Data.Toth_Attila_Lab2Context _context;

        public DetailsModel(Toth_Attila_Lab2.Data.Toth_Attila_Lab2Context context)
        {
            _context = context;
        }

      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
