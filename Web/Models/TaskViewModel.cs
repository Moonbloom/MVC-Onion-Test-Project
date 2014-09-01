using Core.DomainModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class TaskViewModel : ICreatedOn
    {
        #region Variables
        public int TaskID { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public string Headline { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int HoursToComplete { get; set; }

        public ProjectViewModel Project { get; set; }
        public int ProjectID { get; set; }
        #endregion

        public override string ToString()
        {
            return TaskID + " - " + Headline + " - " + CreatedOn + " - " + Completed + " - " + Description;
        }
    }
}