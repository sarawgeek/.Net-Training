using JWTDemo.Models;

namespace JWTDemo.Repos
{
    public class BookRepository : IBookRepository
    {

        ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> AllBooks()
        {
            return _context.Book.ToList();
        }

        public Book BookById(int id)
        {
            return _context.Book.FirstOrDefault(book => book.Id == id);
        }

        public void CreateBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Book.FirstOrDefault(n => n.Id == bookId);
            _context.Book.Remove(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var oldBook = _context.Book.FirstOrDefault(n => n.Id == book.Id);
            if (oldBook != null)
            {
                oldBook.Title = book.Title;
                oldBook.Details = book.Details;
                oldBook.Author = book.Author;
                oldBook.Cost = book.Cost;
                
            }
            _context.SaveChanges();
        }
    }
}
