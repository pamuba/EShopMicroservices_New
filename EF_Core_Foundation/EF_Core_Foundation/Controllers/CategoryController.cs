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
    }
}
