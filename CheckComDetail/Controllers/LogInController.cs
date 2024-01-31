using CheckComDetail.Data;
using CheckComDetail.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CheckComDetail.Controllers
{
    public class SearchViewModel
    {
        // Define properties based on your requirements
        public List<ComputerInfo> ComputerInfoResults { get; set; }
        public List<Customer> CustomerResults { get; set; }
        public List<Product> ProductResults { get; set; }
        public List<Staff> StaffResults { get; set; }
        public string SearchTerm { get; set; }
    }
    public class LogInController : Controller
    {
        private readonly ApplicationDBContext _db;
        public LogInController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable <ComputerInfo> allCom = _db.ComputerInfos;
            return View(allCom);
        }

        // Define a list to hold valid users
        private static List<UserCredentials> validUsers = new List<UserCredentials>
        {
        new UserCredentials { Username = "pat2", Password = "1234" },
        // Add more users as needed
        };
        
        [HttpPost]
        public IActionResult AuthenticateUser(string username, string password)
        {
            // Implement your server-side authentication logic here
            var isValidUser = IsUserValid(username, password);

            return Json(new { isValid = isValidUser });
        }

        private bool IsUserValid(string enteredUsername, string enteredPassword)
        {
            // Check if the entered credentials match any valid user
            return validUsers.Any(user => user.Username == enteredUsername && user.Password == enteredPassword);
        }

        // Define a class to hold user credentials
        public class UserCredentials
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }


        [HttpPost]
        public IActionResult Logout()
        {
            // Log out the user
            HttpContext.SignOutAsync();

            // Redirect to the login page
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Hardcoded user credentials for demo purposes
            string validUsername = "pat2";
            string validPassword = "1234";
            // Check if provided credentials are valid
            if (username == validUsername && password == validPassword)
            {
                // Successful login, redirect to CustomerSearch or any other page
                var viewModel = new SearchViewModel
                {
                    SearchTerm = "" // You can set an initial value here if needed
                };

                return View("CustomerSearch", viewModel);

            }
            else
            {
                // Failed login, return to the login page with an error message
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View("Index");
            }
        }

        [HttpGet]
        public IActionResult CustomerSearch()
        {
            // Add your logic for displaying the CustomerSearch view
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            // Search in ComputerInfo table
            var computerInfoResults = _db.ComputerInfos
                .Where(c => EF.Functions.Like(c.ComputerModel, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.UserID, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.UserName, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.UserEmail, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.UserBuilding, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.UserFloor, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.UserZone, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.ComputerID, $"%{searchTerm}%"))
                .ToList();

            // Search in Customer table
            var customerResults = _db.Customers
                .Where(c => EF.Functions.Like(c.FirstName, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.LastName, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.Email, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.Device, $"%{searchTerm}%") ||
                            EF.Functions.Like(c.Agent, $"%{searchTerm}%"))
                .ToList();

            // Search in Product table (Assuming you have a Product entity)
            var productResults = _db.Products
                .Where(p => EF.Functions.Like(p.ProductBrand, $"%{searchTerm}%") ||
                            EF.Functions.Like(p.ProductModel, $"%{searchTerm}%") ||
                            EF.Functions.Like(p.ProductPrice.ToString(), $"%{searchTerm}%"))
                .ToList();

            // Search in Staff table (Assuming you have a Staff entity)
            var staffResults = _db.Staffs
                .Where(s => EF.Functions.Like(s.FirstName, $"%{searchTerm}%") ||
                            EF.Functions.Like(s.LastName, $"%{searchTerm}%") ||
                            EF.Functions.Like(s.City, $"%{searchTerm}%"))
                .ToList();


            var viewModel = new SearchViewModel
            {
                ComputerInfoResults = computerInfoResults,
                CustomerResults = customerResults,
                ProductResults = productResults,
                StaffResults = staffResults,
                SearchTerm = searchTerm
            };

            return View("CustomerSearch", viewModel);
           
        }
    }
}
