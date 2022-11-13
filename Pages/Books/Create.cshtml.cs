using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Toth_Attila_Lab2.Data;
using Toth_Attila_Lab2.Models;

namespace Toth_Attila_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Toth_Attila_Lab2Context _context;

        public CreateModel(Toth_Attila_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
                "PublisherName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            newBook.Title = Book.Title;
            newBook.Price = Book.Price;
            newBook.AuthorID = Book.AuthorID;
            newBook.PublishingDate = Book.PublishingDate;
            newBook.PublisherID = Book.PublisherID;

            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();
            PopulateAssignedCategoryData(_context, newBook);
            return RedirectToPage("./Index");

            //if (await TryUpdateModelAsync(
            //newBook,
            //"Book",
            //i => i.Title,
            //i => i.Price,
            //i => i.AuthorID,
            //i => i.PublishingDate,
            //i => i.PublisherID))
            //{
            //    _context.Book.Add(newBook);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}

            //else
            //{
            //    var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
            //    .SelectMany(E => E.Errors)
            //    .Select(E => E.ErrorMessage)
            //    .ToList();
            //}

            //PopulateAssignedCategoryData(_context, newBook);
            //return Page();
        }
    }
}
