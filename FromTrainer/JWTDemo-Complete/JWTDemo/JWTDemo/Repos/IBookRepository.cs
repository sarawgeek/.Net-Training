using JWTDemo.Models;

namespace JWTDemo.Repos
{
    public interface IBookRepository
    {
        List<Book> AllBooks();

        Book BookById(int id);

        void CreateBook(Book book);

        void DeleteBook(int bookId);

        void UpdateBook(Book book);

        
    }
}
