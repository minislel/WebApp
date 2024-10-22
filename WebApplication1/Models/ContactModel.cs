using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Imie nie moze byc puste")]
        [MinLength(3, ErrorMessage = "Imie musi miec przynajmniej 3 znaki")]
        [MaxLength(50, ErrorMessage = "Imie moze miec maksymalnie 50 znakow")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko nie moze byc puste")]
        [MinLength(3, ErrorMessage = "Nazwisko musi miec przynajmniej 3 znaki")]
        [MaxLength(50, ErrorMessage = "Nazwisko moze miec maksymalnie 50 znakow")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email nie moze byc pusty")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Numer telefonu nie moze byc pusty")]
        [Phone(ErrorMessage = "Numer telefonu jest niepoprawny")]
        [RegularExpression("\\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "Numer telefonu musi byc w formacie xxx xxx xxx ")]
        
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Data urodzenia nie moze byc pusta")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
    }
}
