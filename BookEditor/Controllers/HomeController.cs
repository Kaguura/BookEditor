using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookEditor.Models;

namespace BookEditor.Controllers
{
    public class HomeController : Controller
    {
        private IParseBookModel pbm = new ParseBookModel();
        
        public ActionResult Index(int page = 1, string search = "")
        {
            ViewBag.Page = page;
            ViewBag.PageCount = pbm.GetPageCnt();
            ViewBag.Books = pbm.GetBooks(page);
            if (search != "")
            {
                ViewBag.Search = 1;
                ViewBag.FoundBooks = pbm.Search(search);
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit([Bind(Prefix = "old")]Book oldBook, [Bind]Book newBook, string submit)
        {
            int page = 1;
            System.Diagnostics.Debug.WriteLine("nfk" + oldBook.Title + " " + oldBook.Author + " " + oldBook.Genre);
            switch (submit)
            {
                case "Add":
                    page = pbm.Add(newBook);
                    break;
                case "Edit":
                    page = pbm.Edit(oldBook, newBook);
                    break;
                default:
                    throw new Exception();
            }

            return RedirectToAction("Index", new { page = page });
        }

        [HttpPost]
        public ActionResult Delete([Bind]Book book)
        {
            int page = pbm.Delete(book);
            return RedirectToAction("Index", new { page = page });
        }

        [HttpPost]
        public ActionResult Search(string text, int page)
        {
            return RedirectToAction("Index", new { page = page, search = text });
        }

    }
}