using EFCoreExample.Enums;

namespace EFCoreExample.Entity
{
    /// <summary>
    /// Модель книги
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Год выпуска
        /// </summary>
        public short Year { get; set; }

        /// <summary>
        /// Идентификатор автора книги
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Автор книги
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Жанр
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Список пользователей у которых есть эта книга
        /// </summary>
        public List<User> Users { get; set; } = new List<User>();
    }
}
