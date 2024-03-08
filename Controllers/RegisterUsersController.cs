using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.Models;

namespace RegistrationForm.Controllers
{
    public class RegisterUsersController : Controller
    {
        private readonly RegistrationFormContext _context;

        public RegisterUsersController(RegistrationFormContext context)
        {
            _context = context;
        }

        // GET: RegisterUser
        public async Task<IActionResult> Index()
        {
              return _context.RegisterUser != null ? 
                          View(await _context.RegisterUser.ToListAsync()) :
                          Problem("Entity set 'RegistrationFormContext.RegisterUser'  is null.");
        }

        // GET: RegisterUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegisterUser == null)
            {
                return NotFound();
            }

            var registerUser = await _context.RegisterUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerUser == null)
            {
                return NotFound();
            }

            return View(registerUser);
        }

        // GET: RegisterUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegisterUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Gender,Email,Course")] RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerUser);
        }

        // GET: RegisterUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegisterUser == null)
            {
                return NotFound();
            }

            var registerUser = await _context.RegisterUser.FindAsync(id);
            if (registerUser == null)
            {
                return NotFound();
            }
            return View(registerUser);
        }

        // POST: RegisterUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Gender,Email,Course")] RegisterUser registerUser)
        {
            if (id != registerUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterUserExists(registerUser.Id))
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
            return View(registerUser);
        }

        // GET: RegisterUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegisterUser == null)
            {
                return NotFound();
            }

            var registerUser = await _context.RegisterUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerUser == null)
            {
                return NotFound();
            }

            return View(registerUser);
        }

        // POST: RegisterUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegisterUser == null)
            {
                return Problem("Entity set 'RegistrationFormContext.RegisterUser'  is null.");
            }
            var registerUser = await _context.RegisterUser.FindAsync(id);
            if (registerUser != null)
            {
                _context.RegisterUser.Remove(registerUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterUserExists(int id)
        {
          return (_context.RegisterUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
