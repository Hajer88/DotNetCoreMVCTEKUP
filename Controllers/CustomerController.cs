using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.FirstMVC._2024.Models;
using Project.FirstMVC._2024.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.FirstMVC._2024.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;
        public CustomerController(AppDbContext _db)
        {
            this._db = _db;
        }

        public IActionResult Index2()
        {
            var c = _db.Customers.Include(c => c.Membershiptype)
                .ToList();

            return View(c);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            Movie m = new Movie() { Id = 1, Name = "Movie 1" };
            MoviecustomersVM cs = new MoviecustomersVM()
            {
                customers = GetAll(),
                movie=m

                };
            return View(cs);
        }
        public IActionResult Details(int? id)
        {
            var c = GetAll()
                .FirstOrDefault(c => c.Id == id);
            return View(c);
        }
        public IActionResult Index3()
        {
            var c = _db.Customers.Include(x=>x.Membershiptype)
                
        
                
                .ToList();
            return View(c);
        }

        private List<Customer> GetAll()
        {
            List<Customer> customers
                = new List<Customer>()
                {
                    new Customer(){Id=1, Name="Customer 1"},
                    new Customer(){Id=2, Name="Customer 2"}
                };

            return customers;
        }

        public IActionResult Create()
        {

            var members = _db.Membershiptypes.ToList();

            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = "Memberships " + members.Id.ToString(),
                Value = members.Id.ToString()
            });




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer c)
        {

            if (!ModelState.IsValid)
            {
                var members = _db.Membershiptypes.ToList();
                ViewBag.member = members.Select(members => new SelectListItem()
                {
                    Text = "Memberships " + members.Id.ToString(),

                    Value = members.Id.ToString()

                });
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }

            _db.Customers.Add(c);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index2));

        }
    }
}

