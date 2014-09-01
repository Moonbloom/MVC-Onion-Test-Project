using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.DomainModel;

namespace Web.Models
{
    public class ProjectViewModel
    {
        #region Variables
        public int ProjectID { get; set; }

        public string Name { get; set; }

        public List<TaskViewModel> Tasks { get; set; }
        #endregion
    }
}