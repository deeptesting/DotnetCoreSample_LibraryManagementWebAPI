using LibraryBusinessComponents;
using LibraryManagementAPI.Model;
using LibraryManagementAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

        private IBookBusinessComponent bookBusinessComponent;

        public LibraryController(IBookBusinessComponent _bookBusinessComponent)
        {
            bookBusinessComponent = _bookBusinessComponent;
        }

        [Route("library/books")]
        [HttpGet("books")]
        public async Task<IActionResult> Books()
        {
            //var result = new string[] { "The Practice of Programming", "Fundamentals of Computer Algorithms" };
            var ListBooks = await bookBusinessComponent.GetBooks();

            #region :: If It is needed to exclude or rename some property from the response
            var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.IgnoreProperty(typeof(LibraryBusinessEntities.Book), "id");
            jsonResolver.IgnoreProperty(typeof(LibraryBusinessEntities.Book), "BookId");
            jsonResolver.RenameProperty(typeof(LibraryBusinessEntities.LibraryAssets), "BookDetails", "BookInfo");
            var serializerSettings = new JsonSerializerSettings() { ContractResolver = jsonResolver };
            var json = JsonConvert.SerializeObject(ListBooks, serializerSettings);
            #endregion

            return Ok(json);
        }



        [Route("library/addedit")]
        [HttpPost("addedit")]
        [Authorize]
        public async Task<IActionResult> AddEdit( BookFormModel bookmodel)//[Bind("BookId,BookName,Author,Quantity")]
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string BookId = string.Empty;
                    if (!string.IsNullOrEmpty(bookmodel.BookId))
                    {
                        BookId = bookmodel.BookId;
                        var BookDetails = await bookBusinessComponent.GetBookDetails(BookId);
                        if (BookDetails == null)
                        {
                           throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Please check BookId, BookId doesn't exists");
                        }
                        //Update
                        await bookBusinessComponent.UpdateBook(bookmodel.BookId, bookmodel.BookName, bookmodel.Author, bookmodel.Quantity);
                        return Ok(ResponsePattern.GetSuccessErrorMsg("Successfully updated", new { bookId = BookId }));
                    }
                    else
                    {
                        BookId = await bookBusinessComponent.InsertBook(bookmodel.BookName, bookmodel.Author, bookmodel.Quantity);
                        return Ok(ResponsePattern.GetSuccessErrorMsg("Successfully inserted", new { bookId = BookId }));
                    }
                }
                catch (Exception ex)
                {
                    throw(ex);
                }
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Model not valid");
                //return BadRequest(ResponsePattern.GetSuccessErrorMsg("Model not valid", new { bookId = "" }));
            }

        }


        //[Route("library/books/addedit")]
        //[HttpPost]
        //public async Task<IActionResult> AddEdit([Bind("BookId,BookName,Author,Quantity")] BookFormModel bookmodel)
        //{
        //    string BookId = string.Empty;

        //    if (ModelState.IsValid)
        //    {
        //        if (!string.IsNullOrEmpty(bookmodel.BookId))
        //        {
        //            //Update
        //            BookId = bookmodel.BookId;
        //            bool r = await bookBusinessComponent.UpdateBook(bookmodel.BookId, bookmodel.BookName, bookmodel.Author, bookmodel.Quantity);
        //            if (r)
        //            {
        //                return OK(ResponsePattern.GetSuccessErrorMsg(1, "Successfully updated", new { bookId = BookId }));
        //            }
        //            else
        //            {
        //                return OK(ResponsePattern.GetSuccessErrorMsg(-1, "Update is not successfull", new { bookId = BookId }));
        //            }
        //        }
        //        else
        //        {
        //            BookId = await bookBusinessComponent.InsertBook(bookmodel.BookName, bookmodel.Author, bookmodel.Quantity);
        //            return OK(GetSuccessErrorMsg(1, "Successfully inserted", new { bookId = BookId }));
        //        }
        //    }
        //    else
        //    {
        //        return OK(ResponsePattern.GetSuccessErrorMsg(-1, "Model not valid", new { bookId = "" }));
        //    }
        //    //return View("Index",bookmodel);
        //}






    }
}
