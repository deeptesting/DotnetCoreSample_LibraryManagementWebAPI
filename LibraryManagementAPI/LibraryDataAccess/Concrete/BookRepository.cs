using System;
using System.Collections.Generic;
using System.Text;
using LibraryDataAccess.DataEntityModel;
using LibraryDataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace LibraryDataAccess.Concrete
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDBContext _context;
        public BookRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(string BookId, string BookName, string Author,int Quantity)
        {
            Book bookmodel = new Book() { BookId = BookId, BookName = BookName, Author = Author };
            _context.Book.Add(bookmodel);

            LibraryAssets libraryAssetsModel = new LibraryAssets() { BookId = BookId, IsActive = true, Quantity = Quantity };
            _context.LibraryAssets.Add(libraryAssetsModel);
            await _context.SaveChangesAsync();
            return bookmodel;
        }

        public async Task<Book> Delete(string BookId)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetBookById(string BookId)
        {
            var datas = (from bk in _context.Book
                         join lib in _context.LibraryAssets
                         on bk.BookId equals lib.BookId
                         where bk.BookId == BookId
                         select new
                         {
                             Id = bk.Id,
                             BookId = bk.BookId,
                             Author = bk.Author,
                             BookName = bk.BookName,
                             Quantity = lib.Quantity
                         }).ToList().FirstOrDefault();
            return datas;

        }

        public async Task<IEnumerable<dynamic>> GetBooks()
        {
            var datas = (from bk in _context.Book
                         join lib in _context.LibraryAssets
                         on bk.BookId equals lib.BookId
                         //where bk.BookId == "BK01234"
                         select new 
                        {
                             Id =  bk.Id,
                             BookId = bk.BookId,
                             Author = bk.Author,
                             BookName = bk.BookName,
                             Quantity = lib.Quantity
                         }).ToList();
            return datas;
             
        }

        public async Task<bool> Update(string BookId, string BookName, string Author, int Quantity)
        {
            bool IsUpdated = false;
            var entity = _context.Book.FirstOrDefault(item => item.BookId == BookId);
            var entity2 = _context.LibraryAssets.FirstOrDefault(item => item.BookId == BookId);

            // Validate entity is not null
            if (entity != null && entity2 !=null)
            {
                // Make changes on entity
                entity.BookName = BookName;
                entity.Author = Author;
                entity2.Quantity = Quantity;

                /* If the entry is being tracked, then invoking update API is not needed. 
                  The API only needs to be invoked if the entry was not tracked. 
                  https://www.learnentityframeworkcore.com/dbcontext/modifying-data */
                // _context.Book.Update(entity);  _context.LibraryAssets.Update(entity2); 

                // Save changes in database
                _context.SaveChanges();
                IsUpdated = true;
            }

            return IsUpdated;
        }
    }
}
