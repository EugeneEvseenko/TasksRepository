using EFCoreExample.Entity;

namespace EFCoreExample.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        int GetBooksCountFromUser(int userId);
        int GetBooksCountFromUser(User user);
        bool DoesUserHaveABook(int bookId);
        bool DoesUserHaveABook(Book book);
    }
}
