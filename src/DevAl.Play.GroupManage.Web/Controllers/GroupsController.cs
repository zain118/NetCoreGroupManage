using DevAl.Play.GroupManage.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAl.Play.GroupManage.Web.Controllers
{
    [Route("Groups")]
    public class GroupsController : Controller
    {
       static List<GroupViewModel> groups = new List<GroupViewModel> { new GroupViewModel { Id = 1, Name = "Man UTD" } };
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(groups);
        }

        [HttpGet]
        [Route("/Details")]
        public IActionResult Details(int id)
        {
            GroupViewModel group = groups.SingleOrDefault(r => r.Id == id);
            return View(group);
        }

        [Route("/Add")]
        //[Route("/Edit/{id?}")]
        [HttpGet]
        public IActionResult Add(int id)
        {
            GroupViewModel group = groups.SingleOrDefault(r => r.Id == id);
            if(group != null)
            {
                ViewBag.Title = "Edit";
                return View(group);
            }
            else
            {
                ViewBag.Title = "Add";
                return View(new GroupViewModel());
            }
        }

        [HttpPost]
        [Route("/Add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add(GroupViewModel group)
        {
            GroupViewModel g = groups.Skip(groups.Count - 1).LastOrDefault();
            group.Id = g == null ? 1 : g.Id + 1;
            groups.Add(group);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Edit")]
        public IActionResult Edit(GroupViewModel group)
        {
            groups.FirstOrDefault(r => r.Id == group.Id).Name = group.Name;
            return RedirectToAction("Index");
        }

        // [HttpPost]
        [Route("/Remove")]
        public IActionResult Remove(int id)
        {
            groups.Remove(groups.FirstOrDefault(r => r.Id == id));
            return RedirectToAction("Index");
        }
    }
}
