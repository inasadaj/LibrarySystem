using System;
using System.Runtime.ConstrainedExecution;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.VM;

namespace LibrarySystem.Services
{
    public interface IBookService
    {
        public string CreateBook(BookVM Book);
        public string UpdateBook(BookVM Book);
        public string DeleteBook(string title);
        public Book GetBookByTitle(string title);
        public List<Book> Books();
    }
}

