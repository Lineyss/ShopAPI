using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ShopAPI2.Models.DataBaseModels
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Login { get; set; }

        [PasswordPropertyText]
        [Required]
        public string Password { get; set; }

        [MaxLength(30)]
        [Required]
        public string SecondName { get; set; }

        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Required]
        public string MidleName { get; set; }

        [MaxLength(11)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(30)]
        [Required]
        public string Email { get; set; }

        public int RoleID { get; set; }

        [ForeignKey(nameof(RoleID))]
        public Role Role { get; set; }
    }
}
