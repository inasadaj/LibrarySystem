using System;
using LibrarySystem.Data;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.VM;

namespace LibrarySystem.Services
{
    public class BookService:IBookService
    {
        readonly AppDbContext _dbContext;
        public BookService(AppDbContext db)
        {
            _dbContext = db;
        }

        public List<Book> Books()
        {
            return _dbContext.Books.ToList();
        }

        public string CreateBook(BookVM Book)
        {
            _dbContext.Books.Add(new Book
            {
                Title = Book.Title,
                Author = Book.Author,
                ReleaseDate = Book.ReleaseDate,
                Price = Book.Price
            });

            _dbContext.SaveChanges();

            return "Book saved successfully";
        }

        public string DeleteBook(string title)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Title == title);

            _dbContext.Books.Remove(book!);

            return "Book deleted successfully";
        }

        public Book GetBookByTitle(string title)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Title == title);

            return book!;
        }

        public string UpdateBook(BookVM Book)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Title == Book.Title);

            book!.Title = Book.Title;
            book!.Author = Book.Author;
            book!.ReleaseDate = Book.ReleaseDate;
            book!.Price = Book.Price;

            _dbContext.Books.Update(book!);

            _dbContext.SaveChanges();

            return "Book updated successfully";
        }
    }
}

