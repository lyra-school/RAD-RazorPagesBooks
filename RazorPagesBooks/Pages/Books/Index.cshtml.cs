using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesBooks.Data;
using RazorPagesBooks.Models;

namespace RazorPagesBooks.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBooks.Data.RazorPagesBooksContext _context;

        public IndexModel(RazorPagesBooks.Data.RazorPagesBooksContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? AuthorIDs { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? BookAuthorID { get; set; }


        public async Task OnGetAsync()
        {
            // Use LINQ to get list of authors.
            IQueryable<int> authorQuery = from b in _context.Book
                                            orderby b.AuthorID
                                            select b.AuthorID;

            var books = from b in _context.Book
                         select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }
            if (!(BookAuthorID == null))
            {
                books = books.Where(x => x.AuthorID == BookAuthorID);
            }
            AuthorIDs = new SelectList(await authorQuery.Distinct().ToListAsync());
            Book = await _context.Book.ToListAsync();
        }
    }
}
