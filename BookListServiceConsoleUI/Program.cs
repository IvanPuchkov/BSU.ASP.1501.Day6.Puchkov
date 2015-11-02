using System;
using BookListService;
using NLog;

namespace BookListServiceConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            BookListService.BookListService bookListService = new BookListService.BookListService();
            Book[] books = new Book[5];
            books[0] = new Book("Albahari", "C# in a nutshell", 2012, 1043);
            books[1] = new Book("Richter", "CLR via C#", 2013, 896);
            books[2] = new Book("Eckel", "Thinking in Java", 2009, 637);
            books[3] = new Book("Lorem", "Ipsum", 2005, 1024);
            books[4] = new Book("Dolor", "Sit Amet", 2015, 512);
            for (int i = 0; i < books.Length; i++)
            {
                bookListService.AddBook(books[i]);
                logger.Info($"Book '{books[i].Title}' has been successfully added to the collection");
            }
            try
            {
                bookListService.AddBook(books[0]);
            }
            catch (ArgumentException exception)
            {
                logger.Error(exception.Message);
            }
            BinaryBookStorage binaryBookStorage = new BinaryBookStorage("books.dat");
            bookListService.SaveCollectionToStorage(binaryBookStorage);
            logger.Info("Collection has been successfully saved in the storage");
            var anotherBookListService = new BookListService.BookListService();
            anotherBookListService.ReadCollectionFromStorage(binaryBookStorage);
            logger.Info("Collection has been successfully loaded from the storage");

            foreach (BookListService.BookListService.BookTag tag in Enum.GetValues(typeof(BookListService.BookListService.BookTag)))
            {
                logger.Info($"Sorting by tag {tag}");
                anotherBookListService.SortByTag(tag);
                foreach (Book book in anotherBookListService.ToList())
                {
                    logger.Info(book);
                }
             }
            Book bookToRemove = anotherBookListService.FindBookByTag("Ipsum",
                BookListService.BookListService.BookTag.Title);
            anotherBookListService.RemoveBook(bookToRemove);
            try
            {
                anotherBookListService.RemoveBook(bookToRemove);
            }
            catch (ArgumentException exception)
            {
                logger.Error(exception.Message);
            }
            Console.ReadKey();
        }
    }
}
