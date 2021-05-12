using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolsForHire.Models;
using ToolsForHire.ViewModels;

namespace ToolsForHire.Controllers
{
    public class ToolsController : Controller
    {
        private ApplicationDbContext _context;

        public ToolsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageTools))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageTools)]
        public ActionResult NewTool()
        {
            var categoryTypes = _context.CategoryTypes.ToList();
            var viewModel = new ToolFormViewModel
            {
                CategoryTypes  = categoryTypes
            };
            return View("ToolForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageTools)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Tool tool)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ToolFormViewModel(tool)
                {
                    CategoryTypes = _context.CategoryTypes.ToList()
                };

                return View("ToolForm", viewModel);
            }

            if (tool.Id == 0)
                _context.Tools.Add(tool);
            else
            {
                var toolInDb = _context.Tools.Single(t => t.Id == tool.Id);
                toolInDb.Name = tool.Name;
                toolInDb.NoInStock = tool.NoInStock;
                toolInDb.CategoryTypeId = tool.CategoryTypeId;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Tools");
        }

        [Authorize(Roles = RoleName.CanManageTools)]
        public ActionResult Edit(int id)
        {
            var tool = _context.Tools.SingleOrDefault(t => t.Id == id);
            if (tool == null)
                return HttpNotFound();

            var viewModel = new ToolFormViewModel(tool)
            {
                CategoryTypes = _context.CategoryTypes.ToList()
            };
            return View("ToolForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var tool = _context.Tools.Include(t => t.CategoryType).SingleOrDefault(t => t.Id == id);

            if (tool == null)
                return HttpNotFound();

            return View(tool);
        }
    }
}