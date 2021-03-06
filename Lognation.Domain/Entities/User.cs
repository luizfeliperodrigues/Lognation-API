﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lognation.Domain.Entities
{
    [Table("user")]
    public class User : Entity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("first_name")]
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [Column("last_name")]
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [Column("email")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [Column("nickname")]
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }

        [Column("password")]
        [StringLength(255)]
        [Required]
        public string Password { get; set; }

        public Login Login { get; set; }
    }
}
