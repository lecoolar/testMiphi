using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using testMiphi.Models;

namespace testMiphi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private ListBooks listBooks;

        public LibraryController(ListBooks books)
        {
            listBooks = books;
        }
        [HttpGet]
        public ActionResult<List<Book>> GetItems(string author = null, string section = null, bool? isAvailability = null)
        {
            List<Book> returnBooks;
            if (author != null)
            {
                returnBooks = listBooks.books.Where(b => b.Author == author).ToList();
            }
            else if (section != null)
            {
                returnBooks = listBooks.books.Where(b => b.Section == section).ToList();
            }
            else if (isAvailability != null)
            {
                returnBooks = listBooks.books.Where(b => b.IsAvailability == isAvailability.Value).ToList();
            }
            else
            {
                returnBooks = listBooks.books;
            }
            return returnBooks;
        }

        [HttpPut]
        public ActionResult<List<Book>> ReplaceItem(long id, Book book)
        {
            var oldbook = listBooks.books.FirstOrDefault(b => b.Id == id);
            var index = listBooks.books.IndexOf(oldbook);
            listBooks.books[index] = book;
            return listBooks.books;
        }

        [HttpPost]
        public ActionResult<List<Book>> AddItem(Book book)
        {
            listBooks.books.Add(book);
            return listBooks.books;
        }

        [HttpDelete]
        public ActionResult<List<Book>> DeleteItem(long id)
        {
            var deleteBook = listBooks.books.FirstOrDefault(b => b.Id == id);
            listBooks.books.Remove(deleteBook);
            return listBooks.books;
        }

        [HttpGet("files")]
        public async Task<ActionResult> DownloadFileAsync()
        {
            var filePath = $"BooksInfo.txt";
            PropertyInfo[] Props = typeof(Book).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var item in listBooks.books)
                {

                    for (int i = 0; i < Props.Length; i++)
                    {
                        await writer.WriteLineAsync(Props[i].Name + ": " + Props[i].GetValue(item, null).ToString());
                    }
                    await writer.WriteLineAsync();
                }
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, "text/plain", Path.GetFileName(filePath));
        }
    }
}
