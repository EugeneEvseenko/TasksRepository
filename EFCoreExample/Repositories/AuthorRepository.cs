using EFCoreExample.Entity;

namespace EFCoreExample.Repositories
{
    public class AuthorRepository : GenericRepository<Author>
    {
        public AuthorRepository(Core.AppContext context) : base(context) { }
    }
}
