using EFCoreExample.Entity;
using EFCoreExample.Enums;
using EFCoreExample.Interfaces;
using EFCoreExample.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using (var db = new Core.AppContext())
            {
                #region Repositories
                IBookRepository bookRepository = new BookRepository(db);
                IUserRepository userRepository = new UserRepository(db);
                var authorRepository = new AuthorRepository(db); // не имеет специальных методов
                #endregion

                #region Creating Authors
                var author1 = new Author { Name = "Сергей Лукьяненко", Birth = DateTime.Now.AddYears(-54) };
                var author2 = new Author { Name = "Борис Акунин", Birth = DateTime.Now.AddYears(-66) };

                authorRepository.Add(author1); authorRepository.Add(author2); db.SaveChanges();
                #endregion

                #region Creating Books
                var book1 = new Book { Name = "Лето волонтёра", Year = 2022, Genre = Genre.Adventure, AuthorId = author1.Id };
                var book2 = new Book { Name = "Не прощаюсь", Year = 2018, Genre = Genre.Thriller, AuthorId = author2.Id };
                var book3 = new Book { Name = "КВАЗИ", Year = 2016, Genre = Genre.Thriller, AuthorId = author1.Id };

                bookRepository.Add(book1); bookRepository.Add(book2); bookRepository.Add(book3); db.SaveChanges();
                #endregion

                #region Creating Users
                var user1 = new User { Name = "Arthur", Role = "Admin", Email = "lol@mail.ru", UserBooks = new List<Book>() { book1, book2 } };
                var user2 = new User { Name = "Klim", Role = "User", Email = "lol@mail.ru", UserBooks = new List<Book>() { book2, book3 } };

                userRepository.Add(user1); userRepository.Add(user2); db.SaveChanges();
                #endregion

                #region Tests
                Console.WriteLine("1. Получать список книг определенного жанра и вышедших между определенными годами.");

                foreach (var book in bookRepository.GetBookByGenreAndYear(Genre.Thriller, 2000, 2022))
                    Console.WriteLine($"[{book.Id}] {book.Name} - {book.Author.Name} | {book.Genre} ({book.Year})");

                Console.WriteLine();

                Console.WriteLine("2. Получать количество книг определенного автора в библиотеке.");
                Console.WriteLine($"{author2.Name} - {bookRepository.GetCountBookByAuthor(author2)} книг");

                Console.WriteLine();

                Console.WriteLine("3. Получать количество книг определенного жанра в библиотеке.");
                Console.WriteLine($"{Genre.Adventure} - {bookRepository.GetCountBooksByGenre(Genre.Adventure)} книг");

                Console.WriteLine();

                Console.WriteLine("4. Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.");
                Console.WriteLine($"{author1.Name} (Участковый) - {(bookRepository.HasBookByAuthorAndName(author1, "Участковый") ? "Есть" : "Отсутствует")}");

                Console.WriteLine();

                Console.WriteLine("5. Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.");
                Console.WriteLine($"{user1.Name} ({book2.Name}) - {(userRepository.DoesUserHaveABook(book2) ? "Есть" : "Отсутствует")}");

                Console.WriteLine();

                Console.WriteLine("6. Получать количество книг на руках у пользователя.");
                Console.WriteLine($"{user2.Name} - {userRepository.GetBooksCountFromUser(user2)} книга");

                Console.WriteLine();

                Console.WriteLine("7. Получение последней вышедшей книги.");
                Console.WriteLine($"Книга {bookRepository.GetLastBook()?.Name} ");

                Console.WriteLine();

                Console.WriteLine("8. Получение списка всех книг, отсортированного в алфавитном порядке по названию.");
                foreach (var book in bookRepository.GetAllBooksOrderByName())
                    Console.WriteLine($"[{book.Id}] {book.Name} - {book.Author.Name} | {book.Genre} ({book.Year})");

                Console.WriteLine();

                Console.WriteLine("9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.");
                foreach (var book in bookRepository.GetAllBooksOrderByYear())
                    Console.WriteLine($"[{book.Id}] {book.Name} - {book.Author.Name} | {book.Genre} ({book.Year})");
                #endregion
            };
            Console.ReadKey();
        }
    }
}