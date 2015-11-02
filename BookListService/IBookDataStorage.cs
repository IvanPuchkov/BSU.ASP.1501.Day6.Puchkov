using System.Collections.Generic;


namespace BookListService
{
    public interface IBookDataStorage
    {
        void SaveToStorage(List<Book> books);
        List<Book> ReadListFromStorage();
    }
}
