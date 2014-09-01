using AutoMapper;
using Core.DomainModel;
using Core.DomainServices;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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

        //#region Create
        //public ActionResult CreateProject()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreateProject(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //#endregion

        //#region Edit
        //public ActionResult EditProject(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult EditProject(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //#endregion

        //#region Delete
        //public ActionResult DeleteProject(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult DeleteProject(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //#endregion
    }
}