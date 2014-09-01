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
        public ActionResult CreateTask(int ProjectID)
        {
            ViewBag.ProjectID = ProjectID;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTask([Bind(Include = "TaskID, CreatedOn, Headline, Description, Completed")] TaskViewModel taskvm, int ProjectID)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Today;
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
        public ActionResult EditTask([Bind(Include = "TaskID, CreatedOn, Headline, Description, Completed")] TaskViewModel task, int ProjectID, int TaskID)
        {
            if (ModelState.IsValid)
            {
                task.Project.ProjectID = ProjectID;

                var model = Mapper.Map<Task>(task);

                _repo.Update(model);

                _uow.Save();

                return RedirectToAction("TaskIndex", "Project", new { ID = ProjectID });
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

            var project = _repo.GetByKey(ProjectID);
            if (project == null)
            {
                return HttpNotFound();
            }

            Task taskModel = null;
            //if (project.Tasks.FirstOrDefault(task => task.TaskID == TaskID) != null)
            //{
            //    taskModel = project.Tasks.SingleOrDefault(task => task.TaskID == TaskID);
            //}
            //else
            //{
            //    return RedirectToAction("TaskIndex", "Project", new { ID = ProjectID });
            //}
                
            
            var tvm = Mapper.Map<TaskViewModel>(taskModel);

            return View(tvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTask(int ProjectID, int TaskID)
        {
            //var project = _repo.GetByKey(ProjectID);
            //if (project.Tasks.FirstOrDefault(task => task.TaskID == TaskID) != null)
            //{
            //    var taskModel = project.Tasks.SingleOrDefault(task => task.TaskID == TaskID);
            //    project.Tasks.Remove(taskModel);
            //}
            //_repo.Update(project);

            //_uow.Save();

            return RedirectToAction("TaskIndex", "Project", new { ID = ProjectID });
        }
        #endregion
    }
}