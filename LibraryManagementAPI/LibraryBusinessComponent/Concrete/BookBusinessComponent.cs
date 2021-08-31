using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryBusinessEntities;
using LibraryDataAccess.Abstract;
using System.Linq;
using LibraryBusinessComponents.Utilities;
 
using Microsoft.Extensions.Configuration;

namespace LibraryBusinessComponents.Concrete
{
    public class BookBusinessComponent : IBookBusinessComponent
    {
        IBookRepository _bookRepository;
        IConfiguration _configuration;

        public BookBusinessComponent(IBookRepository bookRepository, IConfiguration configuration)
        {
            _bookRepository = bookRepository;
            _configuration = configuration;
        }

        public async Task<string> InsertBook(string BookName, string Author, int Quantity)
        {
            int r = (new Random()).Next(100, 1000);
            string BookId = "BK" + r.ToString("0000") + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00");
            await _bookRepository.AddBook(BookId, BookName, Author, Quantity);

            return BookId;
            //Insert into Book Table Then Update the Library Assets
        }

        public async Task<LibraryAssets> GetBookDetails(string BookId)
        {
            var row = await _bookRepository.GetBookById(BookId);
            if (row == null) return null;
            var BookDetails = new LibraryAssets();

            BookDetails.BookId = (string)Dynamic_Extension.GetProperty(row, "BookId");
            BookDetails.BookDetails = new Book()
            {
                BookId = (string)Dynamic_Extension.GetProperty(row, "BookId"),
                Author = (string)Dynamic_Extension.GetProperty(row, "Author"),
                BookName = (string)Dynamic_Extension.GetProperty(row, "BookName")
            };
            BookDetails.Quantity = (int)Dynamic_Extension.GetProperty(row, "Quantity");

            return BookDetails;
        }

        public async Task<List<LibraryAssets>> GetBooks(string Author = "")
        {
            var datas = await _bookRepository.GetBooks();

            var ListBooks = datas.ToList().Select(row => new LibraryAssets()
            {
                BookId = (string)Dynamic_Extension.GetProperty(row, "BookId"),
                BookDetails = new Book()
                {
                    BookId = (string)Dynamic_Extension.GetProperty(row, "BookId"),
                    Author = (string)Dynamic_Extension.GetProperty(row, "Author"),
                    BookName = (string)Dynamic_Extension.GetProperty(row, "BookName")
                },
                Quantity = (int)Dynamic_Extension.GetProperty(row, "Quantity")
            }).ToList();

            return ListBooks;
        }

        public async Task<bool> UpdateBook(string BookId, string BookName, string Author, int Quantity)
        {
            bool IsUpdated = await _bookRepository.Update(BookId, BookName, Author, Quantity);
            return IsUpdated;
        }


    }
}
