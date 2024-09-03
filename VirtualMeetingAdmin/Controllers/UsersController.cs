using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualMeetingAdmin.Common;
using VirtualMeetingAdmin.Data;
using VirtualMeetingAdmin.Entities;

namespace VirtualMeetingAdmin.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string sortOrder, string filterUser, string filterEmail, int? pageNumber)
        {
            ViewData["NameSortParm"] = sortOrder == "UserName_DESC" ? "UserName_ASC" : "UserName_DESC";
            ViewData["DateSortParm"] = sortOrder == "CreatedDate_ASC" ? "CreatedDate_DESC" : "CreatedDate_ASC";

            ViewData["filterUser"] = filterUser;

            int pageSize = 5;

            var users = from u in _context.Users select u;

            if (string.IsNullOrEmpty(filterUser))
                users = users.Where(u => (u.Status == 0 || u.Status == 1));
            else
            {
                users = users.Where(u =>
                   (u.Status == 0 || u.Status == 1) &&
                    u.UserName.Contains(filterUser)
                   );
            }

            switch (sortOrder)
            {
                case "UserName_ASC":
                    users = users.OrderBy(u => u.UserName);
                    break;
                case "UserName_DESC":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                case "CreatedDate_ASC":
                    users = users.OrderBy(u => u.CreatedDate);
                    break;
                case "CreatedDate_DESC":
                    users = users.OrderByDescending(u => u.CreatedDate);
                    break;
            }           

            return View(await PaginatedList<Users>.CreateAsync(users.AsNoTracking(), pageNumber ?? 1, pageSize));
        }       

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password,Email,Address")] Users users)
        {
            if (ModelState.IsValid)
            {
                users.Status = (int)RecordStatus.Inserted;
                users.IsActive = true;
                users.CreatedDate = DateTime.UtcNow;
                users.CreatedBy = "Web";

                _context.Add(users);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserName,Password,Email,Address,Id")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    users.Status = (int)RecordStatus.Updated;
                    users.IsActive = true;
                    users.CreatedDate = DateTime.UtcNow;
                    users.CreatedBy = "Web";

                    _context.Update(users);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
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
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                users.Status = (int)RecordStatus.Deleted;
                _context.Update(users);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
