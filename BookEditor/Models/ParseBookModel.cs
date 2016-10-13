using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace BookEditor.Models
{
    public class ParseBookModel : IParseBookModel
    {
        private string file = "C:/Users/Asel/Desktop/books.txt";
        private List<Book> books;
        private const int cntBooksPerPage = 5;
        
        public ParseBookModel() {
            books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(file));
        }

        private void SaveBooks()
        {
            string json = JsonConvert.SerializeObject(books);
            System.IO.File.WriteAllText(file, json);
        }

        public int GetPageCnt()
        {
            return (int)Math.Ceiling((double)books.Count / cntBooksPerPage);
        }

        public List<Book> GetBooks(int page)
        {
            int startBookIndex = cntBooksPerPage * (page - 1);
            return books.GetRange(startBookIndex, Math.Min(cntBooksPerPage, books.Count - startBookIndex));
        }

        public int Add(Book book)
        {
            books.Add(book);
            SaveBooks();
            return GetPageCnt();
        }

        public int Edit(Book oldBook, Book newBook)
        {
            int indexOfBook = books.FindIndex(x => x.Title == oldBook.Title && x.Author == oldBook.Author && x.Genre == oldBook.Genre);
            if (indexOfBook != -1)
                books[indexOfBook] = newBook;
            SaveBooks();
            return (int)Math.Ceiling((double)(indexOfBook+1) / cntBooksPerPage);
        }

        public int Delete(Book book)
        {
            int indexOfBook = books.FindIndex(x => x.Title == book.Title && x.Author == book.Author && x.Genre == book.Genre);
            if (indexOfBook != -1) books.RemoveAt(indexOfBook);
            SaveBooks();
            return (int)Math.Ceiling((double)(indexOfBook + 1) / cntBooksPerPage);
        }

        public List<Book> Search(string text)
        {
            List<Book> foundBooks = books;
            string[] words = text.Split();
            foreach (string word in words)
            {
                foundBooks = FindBookWithWord(word, foundBooks);
            }
            return foundBooks;
        }

        private List<Book> FindBookWithWord(string word, List<Book> booksToSearch)
        {
            List<Book> foundBooks = new List<Book>();
            foreach (Book book in booksToSearch)
            {
                if (book.Author.Contains(word) || book.Title.Contains(word) || book.Genre.Contains(word))
                    foundBooks.Add(book);
            }
            return foundBooks;
        }
    }
}