namespace EFCoreExample.Entity
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес эклектронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Список книг пользователя
        /// </summary>
        public List<Book> UserBooks { get; set; } = new List<Book>();
    }
}
