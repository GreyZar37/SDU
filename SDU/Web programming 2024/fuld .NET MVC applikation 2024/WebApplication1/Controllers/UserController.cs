﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;
using BCrypt.Net;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Hash the password securely
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.CreatedOn = DateTime.UtcNow;
                user.LastLogin = null;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Redirect to a confirmation or home page
                return RedirectToAction("Index", "Information");
            }
            return View(user); // Return form with validation errors if any
        }

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Find the user by username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                // Example: Store user ID in session
                HttpContext.Session.SetString("UserId", user.UserId.ToString());

                // Update last login timestamp
                user.LastLogin = DateTime.UtcNow;
                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Information");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View("Login"); // Ensure a corresponding Login.cshtml view is present
        }
    }
}