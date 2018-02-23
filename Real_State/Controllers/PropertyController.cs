using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State.Models;
using Real_State.ViewModel;
using System.Data.Entity;

namespace Real_State.Controllers
{
    public class PropertyController : Controller
    {
        private ApplicationDbContext _context;
        public PropertyController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Property
        public ActionResult Details(int id)
        {
            var property = _context.PropertyProfiles.Include(t => t.TypesOfProperty).SingleOrDefault(p => p.ID == id);
           // var property = _context.PropertyProfiles.Include(c => c.TypesOfProperty).ToList();
            return View(property);
        }
        public ActionResult PropertyForm()
                {
            var PropertyTypes = _context.PropertyTypess.ToList();
            var viewModel = new PropertyFormViewModel
            {
                Property = new PropertyProfile(),
                KindsOfProperty = PropertyTypes
            };
            return View("PropertyForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(PropertyProfile property)
        {
            if (property.ID == 0)
                _context.PropertyProfiles.Add(property);
            else
            {
                var customerInDb = _context.PropertyProfiles.Single(c => c.ID == property.ID);
                customerInDb.PropertyTypesID = property.PropertyTypesID;
                customerInDb.BedroomNumber = property.BedroomNumber;
                customerInDb.BathroomNumber = property.BathroomNumber;
                customerInDb.Area = property.Area;
                customerInDb.Location = property.Location;
                customerInDb.Price = property.Price;
                customerInDb.Description = property.Description;
               
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Property");
        }
        public ViewResult Index()
        {
            var property = _context.PropertyProfiles.Include(c => c.TypesOfProperty).ToList();
           // var proprty = _context.PropertyProfiles.Include(t => t.TypesOfProperty).SingleOrDefault(p => p.ID == id);
            return View(property);
        }
        public ActionResult Edit(int id)
        {
            var property = _context.PropertyProfiles.SingleOrDefault(c => c.ID== id);

            if (property == null)
                return HttpNotFound();

            var viewModel = new PropertyFormViewModel
            {
                Property = property,
                KindsOfProperty = _context.PropertyTypess.ToList()
            };

            return View("PropertyForm", viewModel);
        }

    }
}