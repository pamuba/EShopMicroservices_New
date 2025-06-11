using EFCore_DataAccess.Data;
using EFCore_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_Foundation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> objList = _db.Books.ToList();
            return View(objList);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Book book = new();
            if (id == null || id == 0)
            {
                return View(book);
            }
            book = _db.Books.First(u => u.Book_Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Book_Id == 0)
                {
                    //create
                    await _db.Books.AddAsync(book);
                }
                else
                {
                    //updating
                    _db.Books.Update(book);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else {
                return View(book);
            }
        }
    }
}
