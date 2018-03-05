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
            var img = _context.AgentProfiles.ToList();
           
            return View();
        }
        
        [HttpPost]
        public ActionResult Save(AgentProfile AgentProfile, HttpPostedFileBase picture)
        {
            if (AgentProfile.ID ==0)
            {
                AgentProfile.ImageName = Path.GetFileNameWithoutExtension(picture.FileName);
                String extension = Path.GetExtension(picture.FileName);
                var newExtenion = Guid.NewGuid();
                AgentProfile.ImageName = AgentProfile.ImageName + newExtenion+extension;
                AgentProfile.ImagePath = Path.Combine(Server.MapPath("~/Images_Agent/"), AgentProfile.ImageName);
                //AgentProfile.ImagePath = Path.Combine(Server.MapPath("D:/Images/"), AgentProfile.ImageName);
                picture.SaveAs(AgentProfile.ImagePath);
                // _context.Images.Add(AgentProfile);

                _context.AgentProfiles.Add(AgentProfile);
                _context.SaveChanges();
               // AgentProfile.Image.ID = Images.ID;

            }
            else
            {
                var agentInDb = _context.AgentProfiles.Single(a => a.ID == AgentProfile.ID);
                agentInDb.ImageName = Path.GetFileNameWithoutExtension(picture.FileName);
                String extension = Path.GetExtension(picture.FileName);
                var newExtenion = Guid.NewGuid();
                agentInDb.ImageName = agentInDb.ImageName + newExtenion + extension;
                agentInDb.ImagePath = Path.Combine(Server.MapPath("~/Images_Agent/"), agentInDb.ImageName);
                picture.SaveAs(agentInDb.ImagePath);
                _context.AgentProfiles.Add(AgentProfile);
               // _context.SaveChanges();

                agentInDb.Name = AgentProfile.Name;
                agentInDb.DateOfBirth = AgentProfile.DateOfBirth;
                agentInDb.PhoneNo = AgentProfile.PhoneNo;
                agentInDb.LicenseNo = AgentProfile.LicenseNo;
                agentInDb.Email = AgentProfile.Email;
                agentInDb.Password = AgentProfile.Password;

            }
            _context.SaveChanges();
            return RedirectToAction("Details", "Agent");
        }
        public ActionResult Details(int id)
        {
            
            var agent = _context.AgentProfiles.SingleOrDefault(c => c.ID == id);
            if (agent == null)
            {
               
                return HttpNotFound();
            }
            return View(agent);
        }
        public ActionResult Edit(int id)
        {
            var agent = _context.AgentProfiles.SingleOrDefault(c => c.ID == id);
            if (agent == null)
                return HttpNotFound();
            return View("Edit", agent);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var agent = _context.AgentProfiles.Find(id);
            _context.AgentProfiles.Remove(agent);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}