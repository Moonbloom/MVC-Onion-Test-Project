using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.DomainModel;

namespace Web.Models
{
    public class ProjectViewModel
    {
        public int ProjectID { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Task> Tasks { get; set; }
    }
}