using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controller
{
    public class ItemController : Microsoft.AspNetCore.Mvc.Controller
    {

        private ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Items.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == Id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
               return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
