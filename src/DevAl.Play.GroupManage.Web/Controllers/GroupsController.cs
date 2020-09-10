using DevAl.Play.GroupManage.Business.Services;
using DevAl.Play.GroupManage.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAl.Play.GroupManage.Web.Mappings;

namespace DevAl.Play.GroupManage.Web.Controllers
{
    [Route("Groups")]
    public class GroupsController : Controller
    {
        private readonly IGroupServices _groupService;

        public GroupsController(IGroupServices groupService)
        {
            _groupService = groupService;
        }
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(_groupService.GetAllGroups().ToViewModelCollection());
        }

        [HttpGet]
        [Route("/Details")]
        public IActionResult Details(int id)
        {
            GroupViewModel group = _groupService.GetGroupById(id).ToViewModel();
            return View(group);
        }

        [Route("/Add")]
        //[Route("/Edit/{id?}")]
        [HttpGet]
        public IActionResult Add(int id)
        {
            GroupViewModel group = _groupService.GetGroupById(id).ToViewModel();
            if (group != null)
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
            _groupService.AddGroup(group.ToGroup());
            //GroupViewModel g = groups.Skip(groups.Count - 1).LastOrDefault();
            //group.Id = g == null ? 1 : g.Id + 1;
            //groups.Add(group);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Edit")]
        public IActionResult Edit(GroupViewModel group)
        {
            _groupService.EditGroup(group.ToGroup());
            return RedirectToAction("Index");
        }

        // [HttpPost]
        [Route("/Remove")]
        public IActionResult Remove(int id)
        {
            _groupService.DelGroup(id);
            return RedirectToAction("Index");
        }
    }
}
