using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApp.Pages_Comment
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        public SelectList BookSelectedList { get; set; }= default!;
        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            BookSelectedList = new SelectList(_context.Books, nameof(Book.BookId), nameof(Book.Title));
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; }= default!;

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
