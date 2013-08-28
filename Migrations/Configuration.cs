namespace BooksData.Migrations
{
    using BooksData.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookContext>
    {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookContext context) {
            var categories = new List<Category>{
                new Category{CategoryName = "ASP.NET"},
                new Category{CategoryName = "JavaScript"},
                new Category{CategoryName = "HTML5"}
            };

            categories.ForEach(category => context.Categories.AddOrUpdate(c => c.CategoryName, category));
            context.SaveChanges();

            var authors = new List<Author>{
                new Author{FirstName = "Mike", LastName = "Brind"},
                new Author{FirstName = "Imar", LastName = "Spaanjaars"}
            };

            authors.ForEach(author => context.Authors.AddOrUpdate(a => a.LastName, author));
            context.SaveChanges();

            var book = new Book {
                Title = "Beginning ASP.NET Web Pages With WebMatrix",
                Description = "Buy this book!",
                ISBN = "978-1118050484",
                DatePublished = new DateTime(2011, 10, 18),
                AuthorId = 1,
                CategoryId = 1
            };

            context.Books.AddOrUpdate(b => b.ISBN, book);
            context.SaveChanges();
        }
    }
}
