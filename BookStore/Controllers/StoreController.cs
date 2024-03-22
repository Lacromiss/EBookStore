using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using Core.Entities.Basket;
using Newtonsoft.Json;
using DAL.Concrete;
using NuGet.ContentModel;


namespace BookStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IBookService _bookService;
        private readonly EBookStoreDbContext _context;

        public StoreController(IBookService bookService, EBookStoreDbContext context)
        {
            _bookService = bookService;
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {


            List<Book> books = await _bookService.GetAllAsync();
            return View(books);
        }
        public async Task<IActionResult> AddBasket(int Id)
        {
            if (Id == null)
            {
                return BadRequest();

            }
            Book buyProduct1 = _context.books.Find(Id);
            if (buyProduct1 == null)
            {
                return NotFound();

            }

            List<BookBasket> buyProducts;
            string siu = Request.Cookies["masket"];
            if (siu == null)
            {
                buyProducts = new List<BookBasket>();

            }
            else
            {
                buyProducts = JsonConvert.DeserializeObject<List<BookBasket>>(Request.Cookies["masket"]);
            }
            BookBasket buyProductCount = buyProducts.FirstOrDefault(X => X.Id == buyProduct1.Id);
            if (buyProductCount == null)
            {
                BookBasket buyProductCount1 = new BookBasket();
                buyProductCount1.Id = buyProduct1.Id;
                buyProductCount1.Name = buyProduct1.Name;
                buyProductCount1.Description = buyProduct1.Description;
                buyProductCount1.ImgUrl = buyProduct1.ImgUrl;
                buyProductCount1.UpdatedDate = buyProduct1.UpdatedDate;
                buyProductCount1.CreatedDate = buyProduct1.CreatedDate;
                buyProductCount1.Count = 1;
                buyProductCount1.isDeleted = buyProduct1.isDeleted;
                buyProductCount1.Price = buyProduct1.Price;


                buyProductCount1.Count = 1;
                buyProducts.Add(buyProductCount1);

            }
            else
            {
                buyProductCount.Count++;
            }
            Response.Cookies.Append("masket", JsonConvert.SerializeObject(buyProducts), new CookieOptions { MaxAge = TimeSpan.FromMinutes(30) });
            return RedirectToAction(nameof(Index));

        }
        public async  Task<IActionResult> ShowBasktet()
        {
            List<BookBasket> buyProduct = JsonConvert.DeserializeObject<List<BookBasket>>(Request.Cookies["masket"]);
            List<BookBasket> updatedProducts = new List<BookBasket>();

            foreach (var item in buyProduct)
            {
                Book dbProduct = _context.books.FirstOrDefault(p => p.Id == item.Id);
                BookBasket basketProduct = new BookBasket()
                {
                    Id = dbProduct.Id,
                    Price = dbProduct.Price,


                    Name = dbProduct.Name,
                    Count = item.Count

                };

                basketProduct.Price = basketProduct.Price * basketProduct.Count;


                updatedProducts.Add(basketProduct);

            }

            return View(updatedProducts);
        }




        public async Task<IActionResult> InvokeAsync()
        {
            List<BookBasket> products = JsonConvert.DeserializeObject<List<BookBasket>>(Request.Cookies["masket"]);
            int cem = 0;
            foreach (var item in products)
            {
                cem += cem;

            }
            ViewBag.kount = cem;

            return View(await Task.FromResult(products));
        }
        public IActionResult RemoveItem(int? id)
        {
            if (id == null) return NotFound();

            string basket = Request.Cookies["masket"];

            List<BookBasket> products = JsonConvert.DeserializeObject<List<BookBasket>>(basket);

            BookBasket existProduct = products.FirstOrDefault(p => p.Id == id);

            if (existProduct == null) return NotFound();

            products.Remove(existProduct);

            Response.Cookies.Append(
                "masket",
                JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) }
            );

            return RedirectToAction(nameof(ShowBasktet));
        }

        public IActionResult Topla(int? id)
        {
            if (id == null) return NotFound();

            string basket = Request.Cookies["masket"];

            List<BookBasket> products = JsonConvert.DeserializeObject<List<BookBasket>>(basket);

            BookBasket existProduct = products.FirstOrDefault(p => p.Id == id);

            if (existProduct == null) return NotFound();

            Book dbProdut = _context.books.FirstOrDefault(p => p.Id == id);

            if (dbProdut.Count > existProduct.Count)
            {
                existProduct.Count++;
            }
            else
            {
                TempData["Fail"] = "not enough count";
                return RedirectToAction("Masket", "Masket");
            }

            Response.Cookies.Append(
                "masket",
                JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) }
                );

            return RedirectToAction(nameof(ShowBasktet));
        }

        public IActionResult Cix(int? id)
        {
            if (id == null) return NotFound();

            string basket = Request.Cookies["masket"];

            List<BookBasket> products = JsonConvert.DeserializeObject<List<BookBasket>>(basket);

            BookBasket existProduct = products.FirstOrDefault(p => p.Id == id);

            if (existProduct == null) return NotFound();

            if (existProduct.Count > 1)
            {
                existProduct.Count--;
            }
            else
            {
                RemoveItem(existProduct.Id);

                return RedirectToAction(nameof(ShowBasktet));
            }


            Response.Cookies.Append(
                "masket",
                JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(30) }
                );

            return RedirectToAction(nameof(ShowBasktet));
        }

    }
}
