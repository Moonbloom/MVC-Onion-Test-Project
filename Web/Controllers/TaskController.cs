using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Core.DomainModel;
using Core.DomainServices;
using Web.Models;

namespace Web.Controllers
{
    public class TaskController : Controller
    {
        #region Variables
        private readonly IGenericRepository<Task> _repo;
        private readonly IUnitOfWork _uow;
        #endregion

        #region Constructor
        public TaskController(IGenericRepository<Task> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            ViewBag.Message = "Rem'It";

            var listModel = _repo.Get().ToList();

            var listViewModel = Mapper.Map<IEnumerable<TaskViewModel>>(listModel);

            return View(listViewModel);
        }
        #endregion

        #region Create
        public ActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTask([Bind(Include = "Id, CreatedOn, Headline, Description, Completed")] TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Today;
                task.CreatedOn = date;

                var model = Mapper.Map<Task>(task);

                _repo.Insert(model);
                _uow.Save();

                return RedirectToAction("Index");
            }

            return View(task);
        }
        #endregion

        #region Edit
        public ActionResult EditTask(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Edit task";

            var model = _repo.GetByKey(id);
            if (model == null)
            {
                return HttpNotFound("");
            }

            var tvm = Mapper.Map<TaskViewModel>(model);

            return View(tvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTask([Bind(Include = "Id, CreatedOn, Headline, Description, Completed")] TaskViewModel task)
        {
            Debug.WriteLine(task.ToString());

            if (ModelState.IsValid)
            {
                var model = Mapper.Map<Task>(task);
                _repo.Update(model);

                _uow.Save();

                return RedirectToAction("Index");
            }

            return View(task);
        }
        #endregion

        #region Delete
        public ActionResult DeleteTask(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Delete task";

            var model = _repo.GetByKey(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            var tvm = Mapper.Map<TaskViewModel>(model);

            return View(tvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTask(int id)
        {
            _repo.DeleteByKey(id);
            _uow.Save();

            return RedirectToAction("Index");
        }
        #endregion
    }
}