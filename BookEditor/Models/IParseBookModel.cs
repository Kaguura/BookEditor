using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEditor.Models
{
    interface IParseBookModel
    {
        int GetPageCnt();
        List<Book> GetBooks(int page);
        int Add(Book book);
        int Edit(Book oldBook, Book newBook);
        int Delete(Book book);
        List<Book> Search(string text);
    }
}
