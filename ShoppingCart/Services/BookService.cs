using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Services
{
    public class BookService : IDisposable
    {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public List<Book> GetByCategoryId(int categoryId)
        {
            return
                _db.Books.Include("Author")
                    .Where(x => x.CategoryId == categoryId)
                    .OrderByDescending(x => x.Featured)
                    .ToList();
        }

        public List<Book> GetFeatured()
        {
            return _db.Books.Include("Author").Where(b => b.Featured).ToList();
        }

        public Book GetById(int id)
        {
            var book = _db.Books.Include("Author").SingleOrDefault(x => x.Id == id);

            if(null == book)
                throw new System.Data.Entity.Core.ObjectNotFoundException($"Unable to find book with id {id}");
            return book;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}