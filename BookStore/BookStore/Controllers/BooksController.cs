using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BookStore.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {      

        private readonly BookContext _context;
        // private readonly IHtmlLocalizer<BooksController> _localizer;

        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        //private readonly IStringLocalizer _sharedlocalizer2;
        //private readonly IStringLocalizer _sharedlocalizer4;
        //private readonly IStringLocalizer<SharedResource> _sharedlocalizer3;

        private readonly IWebHostEnvironment _hostenvironment;

        public BooksController(BookContext context, IWebHostEnvironment hostenvironment,
             IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _context = context;
            this._hostenvironment = hostenvironment;
            //   _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;


                var type = typeof(SharedResource);
                var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                //_sharedLocalizer = factory.Create(type);
                //_sharedlocalizer2 = factory.Create("SharedResource", assemblyName.Name);
                //_sharedlocalizer3 = localizer3;
               
           
            //_sharedlocalizer4 = factory.Create("SharedResource", assemblyName.Name);
            //_sharedlocalizer3 = localizer3;
           // _hostenvironment = hostenvironment;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            books.ForEach(book => book.Price = CurrencyConversion(book.Price));
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,title,author,writtenyear,edition,price,CreatedDate")] Book book)
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/images
                string wwwRootPath = _hostenvironment.WebRootPath;
                string fileName = book.imagefile?.FileName != null ? Path.GetFileNameWithoutExtension(book.imagefile.FileName) : string.Empty;
                string extension = book.imagefile?.FileName != null ? Path.GetExtension(book.imagefile.FileName) : string.Empty;
                if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(extension))
                {
                    book.imagepath = fileName = fileName + DateTime.Now.ToString("yymmss") + extension;

                    string path = Path.Combine(wwwRootPath + "/images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await book.imagefile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,title,author,writtenyear,edition,price,CreatedDate")] Book book)
        public async Task<IActionResult> Edit(int id,  Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        //private decimal CurrencyConversion(decimal price)
        //{
        //    string fromCurrency = "USD";
        //    string toCurrency = "EURO";
        //    string url2 = url: "https://query.yahooapis.com/v1/public/yql?q=select%20rate%2Cname%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes%3Fs%3D" + from_currency + to_currency + "%253DX%26f%3Dl1n'%20and%20columns%3D'rate%2Cname'&format=json",
   
        //    string url = string.Format("https://www.google.com/finance/converter?fromCurrency={0}&toCurrency={1}", fromCurrency.ToUpper(), toCurrency.ToUpper(), price);
        //    var client = new HttpClient();
        //    var response = client.GetAsync(url).Result;
        //    var content = response.Content.ReadAsStringAsync().Result;
        //    return decimal.Parse(content);
        //}

        private decimal CurrencyConversion(decimal price)
        {
            var locale = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var BrowserCulture = locale.RequestCulture.UICulture.ToString();
            if(BrowserCulture == "en-US")
            {
                return price;
            }
            else if (BrowserCulture == "hi-IN" || BrowserCulture == "te-IN")
            {
                return price * 70;
            }
            else
            {

                return price * Convert.ToDecimal(0.91);
            }
            
        }
    }
}
