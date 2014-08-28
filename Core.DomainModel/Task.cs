using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DomainModel
{
    public class Task : IIdentifier, ICreatedOn
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        //public DateTime CompletedOn { get; set; }

        public string Headline { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
