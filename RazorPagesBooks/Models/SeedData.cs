using Microsoft.EntityFrameworkCore;
using RazorPagesBooks.Data;

namespace RazorPagesBooks.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesBooksContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesBooksContext>>()))
        {
            if (context == null || context.Book == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }

            context.Book.AddRange(
                new Book
                {
                    Title = "Book 1",
                    Summary = "A book about booking",
                    AuthorID = 1,
                    PublisherID = 1,
                    PublicationDate = DateTime.Parse("1989-2-12"),
                    CoverURL = "/images/emoji.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}