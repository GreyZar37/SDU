using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;
using BCrypt.Net;
using System;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {

        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context; 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Users user)
        {
            if (ModelState.IsValid)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.CreatedOn = DateTime.UtcNow;
                user.LastLogin = null;
                user.TrackingNumber = MakeRandomLabel(10);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                user.LastLogin = DateTime.UtcNow;

                DateTime endDate = user.CreatedOn.AddDays(3);
                int deliveryDays = CalculateBusinessDays(user.CreatedOn, endDate);
              
                return RedirectToAction("Information", "Home");
            }
            return View(user); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                HttpContext.Session.SetString("UserId", user.UserId.ToString());

                user.LastLogin = DateTime.UtcNow;


                DateTime endDate = user.CreatedOn.AddDays(3);
                int deliveryDays = CalculateBusinessDays(user.CreatedOn, endDate);
               

                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Delivery", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View("Index"); 
        }

        private int CalculateBusinessDays(DateTime start, DateTime end)
        {
            int businessDays = 0;

            while (start <= end)
            {
                if (start.DayOfWeek >= DayOfWeek.Monday && start.DayOfWeek <= DayOfWeek.Friday)
                {
                    businessDays++;
                }
                start = start.AddDays(1);
            }

            return businessDays;
        }

        private string MakeRandomLabel(int trackingLabelLenght)
        {
            string randomLabel = "";
            for (int i = 0; i < trackingLabelLenght; i++)
            {
                string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
                Random rand = new Random();
                int num = rand.Next(0, chars.Length);
                randomLabel += chars[num];
            }
            return randomLabel.ToUpper();
        }

        [HttpGet]
        public async Task<IActionResult> GetDeliveryInfo()
        {

            if (!HttpContext.Session.TryGetValue("UserId", out var userIdBytes))
            {
                return Unauthorized();
            }
            var userId = int.Parse(System.Text.Encoding.UTF8.GetString(userIdBytes));
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            DateTime endDate = user.CreatedOn.AddDays(3);
            int deliveryDays = CalculateBusinessDays(user.CreatedOn, endDate);

            return Json(new
            {
                DeliveryDays = deliveryDays,
                TrackingLabel = user.TrackingNumber
            });
        }
    }
}
