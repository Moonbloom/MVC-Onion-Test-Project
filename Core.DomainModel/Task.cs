using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DomainModel
{
    public class Task : ICreatedOn
    {
        #region Variables
        public int TaskID { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Headline { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int HoursToComplete { get; set; }

        public virtual Project Project { get; set; }
        public int ProjectID { get; set; }
        #endregion
    }
}
