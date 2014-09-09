using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using Core.DomainModel;
using Core.DomainServices;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class ProjectAPIController : ApiController
    {
        private readonly IGenericRepository<Project> _repo;

        public ProjectAPIController(IGenericRepository<Project> repo)
        {
            _repo = repo;
        }

        // GET: api/Project
        public IEnumerable<string> Get()
        {
            var projectNames = _repo.Get().Select(item => item.Name);

            return projectNames;
        }

        // GET: api/Project/5
        public ProjectViewModel Get(int id)
        {
            var project = _repo.GetByKey(id);

            return AutoMapper.Mapper.Map<ProjectViewModel>(project);
        }
    }
}