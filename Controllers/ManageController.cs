using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class ManageController : Controller
    {
        private readonly LibrarySystemContext _context;
        public ManageController(LibrarySystemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAuthor()
        {
            var data =  _context.Authors.ToList();
                

            if (data == null)
            {
                return NotFound();
            }
            return Json(data);
        }
        [HttpGet]
        public IActionResult GetPublisher()
        {
            var data = _context.Publishers.ToList();


            if (data == null)
            {
                return NotFound();
            }

            return Json(data);
        }
        [HttpGet]
        public IActionResult GetBook()
        {
            var data = _context.Books.ToList();


            if (data == null)
            {
                return NotFound();
            }

            return Json(data);
        }
    }
}
