using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProjeOT.Data;
using WebProjeOT.Models;

namespace WebProjeOT.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blogs
       
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Blogs.Include(b => b.Categories).Include(b => b.Writer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Blogs/Details/5
        //[Authorize]

        [Authorize(Roles = "User, Admin")]
      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .Include(b => b.Categories)
                .Include(b => b.Writer)
                .FirstOrDefaultAsync(m => m.BlogID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blogs/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoriesID"] = new SelectList(_context.CategorieS, "CategoriesID", "CategoriesID");
            ViewData["WriterID"] = new SelectList(_context.Writers, "WriterID", "WriterID");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("BlogID,BlogHeader,BlogDetail,BlogDate,BlogImage,CategoriesID,WriterID")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesID"] = new SelectList(_context.CategorieS, "CategoriesID", "CategoriesID", blog.CategoriesID);
            ViewData["WriterID"] = new SelectList(_context.Writers, "WriterID", "WriterID", blog.WriterID);
            return View(blog);
        }

        // GET: Blogs/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewData["CategoriesID"] = new SelectList(_context.CategorieS, "CategoriesID", "CategoriesID", blog.CategoriesID);
            ViewData["WriterID"] = new SelectList(_context.Writers, "WriterID", "WriterID", blog.WriterID);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("BlogID,BlogHeader,BlogDetail,BlogDate,BlogImage,CategoriesID,WriterID")] Blog blog)
        {
            if (id != blog.BlogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.BlogID))
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
            ViewData["CategoriesID"] = new SelectList(_context.CategorieS, "CategoriesID", "CategoriesID", blog.CategoriesID);
            ViewData["WriterID"] = new SelectList(_context.Writers, "WriterID", "WriterID", blog.WriterID);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .Include(b => b.Categories)
                .Include(b => b.Writer)
                .FirstOrDefaultAsync(m => m.BlogID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogID == id);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminBlogList()
        {
            var context = _context.Blogs.Include(b => b.Categories).Include(b => b.Writer);
            return View(context);
        }



        // coklu dil
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
