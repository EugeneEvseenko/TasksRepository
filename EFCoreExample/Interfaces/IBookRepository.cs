using EFCoreExample.Entity;
using EFCoreExample.Enums;

namespace EFCoreExample.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        List<Book> GetAllBooksOrderByName();
        List<Book> GetAllBooksOrderByYear();
        List<Book> GetBookByGenreAndYear(Genre genre, short yearStart, short yearEnd);
        int GetCountBookByAuthor(Author author);
        int GetCountBookByAuthor(int authorId);
        int GetCountBooksByGenre(Genre genre);
        Book? GetLastBook();
        bool HasBookByAuthorAndName(Author author, string name);
        bool HasBookByAuthorAndName(int authorId, string name);
    }
}