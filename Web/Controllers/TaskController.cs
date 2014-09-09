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

        #region Create
        public ActionResult CreateTask(int? ProjectID)
        {
            if (ProjectID == null)
            {
                return RedirectToAction("Index", "Project");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTask([Bind(Include = "TaskID, CreatedOn, Headline, HoursToComplete, Description, Completed, ProjectID")] TaskViewModel taskvm, int ProjectID)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Now;
                taskvm.CreatedOn = date;

                var taskModel = Mapper.Map<Task>(taskvm);
                taskModel.ProjectID = ProjectID;

                _repo.Insert(taskModel);
                _uow.Save();

                return RedirectToAction("TaskIndex", "Project", new { ID = ProjectID });
            }

            return View(taskvm);
        }
        #endregion

        #region Edit
        public ActionResult EditTask(int? ProjectID, int? TaskID)
        {
            if (ProjectID == null)
            {
                return RedirectToAction("Index", "Project");
            }
            if (TaskID == null)
            {
                return RedirectToAction("TaskIndex", "Project", new { ID = ProjectID });
            }

            ViewBag.Message = "Edit task";

            var taskModel = _repo.GetByKey(ProjectID);
            if (taskModel == null)
            {
                return HttpNotFound();
            }

            var tvm = Mapper.Map<TaskViewModel>(taskModel);

            return View(tvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTask([Bind(Include = "TaskID, CreatedOn, Headline, Description, HoursToComplete, Completed, ProjectID")] TaskViewModel task)
        {
            Debug.WriteLine("Project ID: " + task.ProjectID + " - TaskID: " + task.TaskID);

            if (ModelState.IsValid)
            {
                var model = Mapper.Map<Task>(task);

                _repo.Update(model);

                _uow.Save();

                return RedirectToAction("TaskIndex", "Project", new { ID = task.ProjectID });
            }

            return View(task);
        }
        #endregion

        #region Delete
        public ActionResult DeleteTask(int? ProjectID, int? TaskID)
        {
            if (ProjectID == null)
            {
                return RedirectToAction("Index", "Project");
            }
            if (TaskID == null)
            {
                return RedirectToAction("TaskIndex", "Project", new { ID = ProjectID });
            }

            ViewBag.Message = "Delete task";

            var taskModel = _repo.GetByKey(TaskID);
            if (taskModel == null)
            {
                return HttpNotFound();
            }
 
            var tvm = Mapper.Map<TaskViewModel>(taskModel);

            return View(tvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTask(int ProjectID, int TaskID)
        {
            _repo.DeleteByKey(TaskID);

            _uow.Save();

            return RedirectToAction("TaskIndex", "Project", new { ID = ProjectID });
        }
        #endregion
    }
}