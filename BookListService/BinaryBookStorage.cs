using System;
using System.Collections.Generic;
using System.IO;

namespace BookListService
{
    public class BinaryBookStorage : IBookDataStorage
    {
        public string FileName { get; set; }
        public BinaryBookStorage(string fileName)
        {
            FileName = fileName;
        }

        public void SaveToStorage(List<Book> books)
        {
            if (string.IsNullOrEmpty(FileName))
                throw new InvalidOperationException("StorageLocation can't be null or empty");
            if (books == null)
                throw new ArgumentNullException();
            using (var fs = new FileStream(FileName, FileMode.Create))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    foreach (var book in books)
                    {
                        bw.Write(book.Author);
                        bw.Write(book.Title);
                        bw.Write(book.PageCount);
                        bw.Write(book.Year);
                    }
                }
            }
        }

        public List<Book> ReadListFromStorage()
        {
            if (string.IsNullOrEmpty(FileName))
                throw new InvalidOperationException("StorageLocation can't be null or empty");
            if (!File.Exists(FileName))
                throw new FileNotFoundException();
            var result = new List<Book>();
            using (var fs = new FileStream(FileName, FileMode.Open))
            {
                using (var br = new BinaryReader(fs))
                {
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        string author = br.ReadString();
                        string title = br.ReadString();
                        int pageCount = br.ReadInt32();
                        int year = br.ReadInt32();
                        result.Add(new Book(author, title, year, pageCount));
                    }
                }
            }
            return result;
        }
    }
}
