using BooksData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksData.Repositories
{
    public class CategoryRepository : IDisposable
    {
        private BookContext _context = new BookContext();
        private bool _disposed;

        public IEnumerable<Category> GetCategories() {
            return _context.Categories.ToList();
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
