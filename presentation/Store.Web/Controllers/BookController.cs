using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public IActionResult Index(int id)
        {
            Book book = _bookRepository.GetById(id);
            return View(book);
        }
    }
}
