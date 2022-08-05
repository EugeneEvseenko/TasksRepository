using EFCoreExample.Entity;
using EFCoreExample.Interfaces;

namespace EFCoreExample.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Core.AppContext context) : base(context) { }

        /// <summary>
        /// Вернет количество книг на руках у пользователя.
        /// </summary>
        public int GetBooksCountFromUser(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId).UserBooks.Count();
        }

        /// <summary>
        /// Вернет количество книг на руках у пользователя.
        /// </summary>
        public int GetBooksCountFromUser(User user) => GetBooksCountFromUser(user.Id);

        /// <summary>
        /// Вернет булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        public bool DoesUserHaveABook(int bookId)
        {
            return _context.Users.Any(x => x.UserBooks.Any(b => b.Id == bookId));
        }

        /// <summary>
        /// Вернет булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        public bool DoesUserHaveABook(Book book) => DoesUserHaveABook(book.Id);
    }
}
