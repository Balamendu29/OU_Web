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

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        // private readonly IHtmlLocalizer<BooksController> _localizer;

        private readonly IStringLocalizer _sharedLocalizer;
        private readonly IStringLocalizer _sharedlocalizer2;
        private readonly IStringLocalizer<SharedResource> _sharedlocalizer3;

        public BooksController(BookContext context, IWebHostEnvironment hostEnvironment,IHtmlLocalizer<BooksController> localizer,
            IStringLocalizerFactory factory, IStringLocalizer<SharedResource> localizer3)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            //   _localizer = localizer;
            _sharedLocalizer = factory.Create(typeof(SharedResource));


            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create(type);
            _sharedlocalizer2 = factory.Create("SharedResource", assemblyName.Name);
            _sharedlocalizer3 = localizer3;           
        }



        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Writtenyear,Edition,Price,CreatedDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                ////save image to wwwroot/images
                //string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                //string extension = Path.GetExtension(book.ImageFile.FileName);
                //book.ImageName = fileName + extension;
                //string path = Path.Combine(wwwRootPath + "/images/", fileName);

                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    await book.ImageFile.CopyToAsync(fileStream);
                //}

                //insert record
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Writtenyear,Edition,Price,CreatedDate")] Book book)
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
    }
}
