using LibraryBusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessComponents
{
    public interface IBookBusinessComponent
    {
        Task<List<LibraryAssets>> GetBooks(string Author = "");
        Task<LibraryAssets> GetBookDetails(string BookId);
        Task<string> InsertBook(string BookName,string Author,int Quantity);
        Task<bool> UpdateBook(string BookId,string BookName,string Author,int Quantity);
    }
}
