using System;

namespace Aventude.Demo.eShop.Core
{
    public abstract class Entity
    {        
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public bool Deleted { get; set; }
    }
}
