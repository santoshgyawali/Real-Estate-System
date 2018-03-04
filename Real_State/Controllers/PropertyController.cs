using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State.Models;
using Real_State.ViewModel;
using System.Data.Entity;
using System.IO;

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
        public ActionResult Create()
        {
            var PropertyTypes = _context.PropertyTypess.ToList();
            var image = _context.Images.ToList();
            var viewModel = new PropertyFormViewModel
            {
                Property = new PropertyProfile(),
                KindsOfProperty = PropertyTypes,
                image=image
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        public ActionResult Save(PropertyProfile Property,Image image, IEnumerable<HttpPostedFileBase> picture)
        {
            foreach (var pic in picture)
            {
                if (pic != null)
                {

                    image.ImageName = Path.GetFileNameWithoutExtension(pic.FileName);
                    string extension = Path.GetExtension(pic.FileName);
                    var newExtension = Guid.NewGuid();
                    image.ImageName = image.ImageName + newExtension;
                    image.ImagePath = Path.Combine(Url.Content("C:/Users/santo/source/repos/Real_State/Property_Images/"), image.ImageName);
                    pic.SaveAs(image.ImagePath);
                    // _context.Images.Add(AgentProfile);
                    //Property.ID = image.ID;
                   // image.PropertyProfileID = Property.ID;
                   // _context.Images.Add(image);

                    _context.SaveChanges();

                }
            }
            if (Property.ID == 0)
                _context.PropertyProfiles.Add(Property);
            else
            {
                var customerInDb = _context.PropertyProfiles.Single(c => c.ID == Property.ID);
                customerInDb.PropertyTypesID = Property.PropertyTypesID;
                customerInDb.BedroomNumber = Property.BedroomNumber;
                customerInDb.BathroomNumber = Property.BathroomNumber;
                customerInDb.Area = Property.Area;
                customerInDb.Location = Property.Location;
                customerInDb.Price = Property.Price;
                customerInDb.Description = Property.Description;
               
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

            return View("Create", viewModel);
        }

    }
}