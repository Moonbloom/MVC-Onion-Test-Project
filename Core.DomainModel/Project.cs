using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModel
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int ProjectID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
