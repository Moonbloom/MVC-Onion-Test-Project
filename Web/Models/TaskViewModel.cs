using Core.DomainModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class TaskViewModel : ICreatedOn
    {
        #region Variables
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        //public DateTime CompletedOn { get; set; }

        public string Headline { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        #endregion

        public override string ToString()
        {
            return Id + " - " + Headline + " - " + CreatedOn + " - " + Completed + " - " + Description;
        }
    }
}