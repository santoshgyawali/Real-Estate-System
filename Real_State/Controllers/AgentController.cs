using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State.Models;
using Real_State.ViewModel;
using System.IO;
using System.Data.Entity;


namespace Real_State.Controllers
{
    public class AgentController : Controller
    {
        private ApplicationDbContext _context;
        public AgentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Agent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var img = _context.Images.ToList();
            var viewModel = new AgentFormViewModel
            {
                AgentProfile = new AgentProfile(),
                Images = img
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        public ActionResult Save(AgentProfile AgentProfile, Image Images, HttpPostedFileBase picture)
        {
            if (AgentProfile.ID ==0)
            {
                Images.ImageName = Path.GetFileNameWithoutExtension(picture.FileName);
                String extension = Path.GetExtension(picture.FileName);
                var newExtenion = Guid.NewGuid();
                Images.ImageName = Images.ImageName + newExtenion;
                Images.ImagePath = Path.Combine(Url.Content("D:/Images/"), Images.ImageName);
                picture.SaveAs(Images.ImagePath);
                _context.Images.Add(Images);
                _context.AgentProfiles.Add(AgentProfile);
                _context.SaveChanges();
                AgentProfile.Image.ID = Images.ID;

            }
            else
            {
                var agentInDb = _context.AgentProfiles.Single(a => a.ID == AgentProfile.ID);
                agentInDb.Name = AgentProfile.Name;
                agentInDb.DateOfBirth = AgentProfile.DateOfBirth;
                agentInDb.PhoneNo = AgentProfile.PhoneNo;
                agentInDb.LicenseNo = AgentProfile.LicenseNo;
                agentInDb.Email = AgentProfile.Email;
                agentInDb.Password = AgentProfile.Password;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Agent");
        }
    }
}