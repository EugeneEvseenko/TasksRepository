namespace EFCoreExample.Entity
{
    /// <summary>
    /// Модель автора
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birth { get; set; }

        /// <summary>
        /// Список книг которые написал данных автор
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
