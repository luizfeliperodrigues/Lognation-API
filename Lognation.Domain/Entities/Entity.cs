using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lognation.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            CreatedAt = DateTime.Now;
        }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; private set; }

        public DateTime? LastUpdateAt { get; private set; }

        public void ModifiedEntity()
        {
            this.LastUpdateAt = DateTime.Now;
        }
    }
}
