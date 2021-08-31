using LibraryDataAccess.DataEntityModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccess.Abstract
{
    public interface IBookRepository
    {
        Task<dynamic> GetBookById(string BookId);
        Task<IEnumerable<dynamic>> GetBooks();
        Task<Book> AddBook(string BookId, string BookName, string Author, int Quantity);
        Task<bool> Update(string BookId, string BookName, string Author, int Quantity);
        Task<Book> Delete(string BookId);
    }
}
