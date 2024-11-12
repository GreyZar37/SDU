using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create(Users user)
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
                return RedirectToAction("Information", "Home");
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

                DateTime endDate = new DateTime(2024, 11, 14);
                int deliveryDays = CalculateBusinessDays(user.CreatedOn, endDate);
                TempData["DeliveryDays"] = deliveryDays;
                

                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Delivery", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View("Index"); // Ensure a corresponding Login.cshtml view is present
        }

        private int CalculateBusinessDays(DateTime start, DateTime end)
        {
            int businessDays = 0;

            // Loop through each day
            while (start <= end)
            {
                // Check if it's a weekday (Mon=1 to Fri=5)
                if (start.DayOfWeek >= DayOfWeek.Monday && start.DayOfWeek <= DayOfWeek.Friday)
                {
                    businessDays++;
                }
                start = start.AddDays(1);
            }

            return businessDays;
        }
    }
}
