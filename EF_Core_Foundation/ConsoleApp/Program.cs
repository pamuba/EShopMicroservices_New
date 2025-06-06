//using System.Linq;
//using EFCore_DataAccess.Data;
//using EFCore_Model.Models;
//using Microsoft.EntityFrameworkCore;

Console.WriteLine();

//using (ApplicationDbContext context = new()) {
//    //context.Database.EnsureCreated();

//    //if (context.Database.GetPendingMigrations().Count() > 0) { 
//    //    context.Database.Migrate();
//    //}

//    GetAllBooks(context);
//    //AddBook(context);
//    //GetBook(context);
//    //GetBookById(context);
//}

//void GetAllBooks(ApplicationDbContext context){
//    var books = context.Books.ToList();
//    foreach (var book in books) {
//        Console.WriteLine(book.Title+"   "+ book.ISBN);
//    }
//}

//void AddBook(ApplicationDbContext context) {
//    Book book = new Book() {Title=".NET Core Book", ISBN="12345",Price=123m, Publisher_Id=1};
//    context.Books.Add(book);
//    context.SaveChanges();
//}

//void GetBook(ApplicationDbContext context) {
////    Fluent_Book book = null;
////    Fluent_Book defaultBook = new Fluent_Book() { Title = ".NET Core Book", ISBN = "12345", Price = 123m, Publisher_Id = 1 };
////    try {
////        book = context.Fluent_Books.FirstOrDefault(defaultBook);
////        //if (book != null)
////        {
////            //Console.WriteLine(book);
////            //Console.WriteLine(book.Book_Id + "  " + book.Title + "   " + book.ISBN);
////        }
////    }
////    catch (Exception ex)
////    {
////        Console.WriteLine(ex.Message);
////    }

//}

//void GetBookById(ApplicationDbContext context)
//{
//    try
//    {
//        //var book = context.Books.Where(u=>u.Book_Id==1).FirstOrDefault();
//        //var book = context.Books.Find(100);
//        //var book = context.Books.SingleOrDefault(u => u.ISBN == "123456");

//        //if (book != null) {
//        //    Console.WriteLine(book.Book_Id + "  " + book.Title + "   " + book.ISBN);
//        //}
//        //else{
//        //    Console.WriteLine("No Books Found");
//        //}

//        //var books = context.Books.Where(u => EF.Functions.Like(u.ISBN,"12%")).Max(u=>u.Price);
//        var books = context.Books.Where(u => EF.Functions.Like(u.ISBN, "12%")).Count();
//        //foreach (var book in books) {
//        //    Console.WriteLine(book.Book_Id + "  " + book.Title + "   " + book.ISBN);
//        //}
//        Console.WriteLine(books);

//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }

//}