using BooksData.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BooksData.Repositories
{
    public class BookRepository : IDisposable
    {
        private BookContext _context = new BookContext();
        private bool _disposed;

        public int Save(Book book) {
            if (book.BookId.Equals(0)) {
                _context.Books.Add(book);
            }
            else {
                _context.Entry(book).State = EntityState.Modified;
            }
            return _context.SaveChanges();
        }

        public int Delete(int id) {
            var book = new Book { BookId = id };
            _context.Entry(book).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        public Book Find(int id) {
            return _context.Books.First(b => b.BookId.Equals(id));
        }

        public IEnumerable<Book> GetBooks() {
            return _context.Books.ToList();
        }

        public IEnumerable<Book> GetBooksByCategory(int categoryId) {
            return _context.Books.Include("Author").Include("Category").Where(b => b.CategoryId.Equals(categoryId)).ToList();
        }

        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing && _context != null) {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
