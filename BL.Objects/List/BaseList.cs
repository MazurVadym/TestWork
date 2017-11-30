using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.List
{
    public abstract class BaseList
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string OwnerId { get; set; }

        public string OwnerFullName { get; set; }

        public bool Active { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public long Flags { get; set; }
    }
}
