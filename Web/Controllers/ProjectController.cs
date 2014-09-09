using System.Diagnostics;
using AutoMapper;
using Core.DomainModel;
using Core.DomainServices;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Web.Models;

namespace Web.Controllers
{
    public class ProjectController : Controller
    {
        #region Variables
        private readonly IGenericRepository<Project> _repo;
        private readonly IUnitOfWork _uow;
        #endregion

        #region Constructor
        public ProjectController(IGenericRepository<Project> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            ViewBag.Message = "Projects";

            var listModel = _repo.Get(includeProperties: "Tasks").ToList();

            var listViewModel = Mapper.Map<IEnumerable<ProjectViewModel>>(listModel);

            return View(listViewModel);
        }
        #endregion

        #region Details
        public ActionResult TaskIndex(int ID)
        {
            ViewBag.Message = "Tasks";

            var projectModel = _repo.GetByKey(ID);

            var projectViewModel = Mapper.Map<ProjectViewModel>(projectModel);

            return View(projectViewModel);
        }
        #endregion

        #region Create
        public ActionResult CreateProject()
        {
            ViewBag.Message = "Create Project";

            return View();
        }

        [HttpPost]
        public ActionResult CreateProject([Bind(Include = "Name")] ProjectViewModel projvm)
        {
            if (ModelState.IsValid)
            {
                var projectModel = Mapper.Map<Project>(projvm);

                _repo.Insert(projectModel);
                _uow.Save();

                return RedirectToAction("Index");
            }

            return View(projvm);
        }
        #endregion

        #region Edit
        public ActionResult EditProject(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Edit Project";

            var projectModel = _repo.GetByKey(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }


            var projvm = Mapper.Map<ProjectViewModel>(projectModel);

            return View(projvm);
        }

        [HttpPost]
        public ActionResult EditProject([Bind(Include = "Name, ProjectID")] ProjectViewModel projvm)
        {
            if (ModelState.IsValid)
            {
                var tasks = _repo.GetByKey(projvm.ProjectID).Tasks;
                var taskvm = Mapper.Map<ICollection<TaskViewModel>>(tasks);

                projvm.Tasks = taskvm;

                var projModel = Mapper.Map<Project>(projvm);

                _repo.Update(projModel);
                _uow.Save();

                return RedirectToAction("Index");
            }

            return View(projvm);
        }
        #endregion

        #region Delete
        public ActionResult DeleteProject(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Delete task";

            var project = _repo.GetByKey(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            var projvm = Mapper.Map<ProjectViewModel>(project);

            return View(projvm);
        }

        [HttpPost]
        public ActionResult DeleteProject(int id)
        {
            _repo.DeleteByKey(id);
            _uow.Save();

            return RedirectToAction("Index");
        }
        #endregion
    }
}