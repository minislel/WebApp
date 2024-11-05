using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactEntity
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string Email { get; set; }
 
        public string PhoneNumber { get; set; }

        public DateOnly BirthDate { get; set; }
        public DateTime Created { get; set; }
    }
}
