using EFCoreExample.Entity;
using EFCoreExample.Enums;
using EFCoreExample.Interfaces;

namespace EFCoreExample.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(Core.AppContext context) : base(context) { }

        /// <summary>
        /// Вернет список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        public List<Book> GetBookByGenreAndYear(Genre genre, short yearStart, short yearEnd)
        {
            return _context.Books
                .Where(b => b.Genre == genre && b.Year >= yearStart && b.Year <= yearEnd)
                .ToList();
        }

        /// <summary>
        /// Вернет количество книг определенного автора в библиотеке.
        /// </summary>
        public int GetCountBookByAuthor(int authorId)
        {
            return _context.Books.Where(b => b.AuthorId == authorId).Count();
        }

        /// <summary>
        /// Вернет количество книг определенного автора в библиотеке.
        /// </summary>
        public int GetCountBookByAuthor(Author author) => GetCountBookByAuthor(author.Id);

        /// <summary>
        /// Вернет количество книг определенного жанра в библиотеке.
        /// </summary>
        public int GetCountBooksByGenre(Genre genre)
        {
            return _context.Books.Where(b => b.Genre == genre).Count();
        }

        /// <summary>
        /// Вернет булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        public bool HasBookByAuthorAndName(int authorId, string name)
        {
            return _context.Books.Any(b => b.AuthorId == authorId && b.Name == name);
        }

        /// <summary>
        /// Вернет булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        public bool HasBookByAuthorAndName(Author author, string name) => HasBookByAuthorAndName(author.Id, name);

        /// <summary>
        /// Получение последней вышедшей книги.
        /// </summary>
        public Book? GetLastBook()
        {
            return _context.Books
                .OrderByDescending(b => b.Year)
                .ThenByDescending(b => b.Id)
                .First();
        }

        /// <summary>
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        public List<Book> GetAllBooksOrderByName()
        {
            return _context.Books
                .OrderBy(b => b.Name)
                .ToList();
        }

        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        public List<Book> GetAllBooksOrderByYear()
        {
            return _context.Books
                .OrderByDescending(b => b.Year)
                .ToList();
        }
    }
}
