using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission
{
    public class User : BaseEntity
    {
        //----------User ID
        public int Id {get; set;}

        //----------First Name
        [Required(ErrorMessage = "First name must be entered!")]
        [MinLength(4, ErrorMessage = "First name must be at least 4 characters in length!")]
        public string FirstName {get; set;}

        //----------Last Name
        [Required(ErrorMessage = "Last name must be entered!")]
        [MinLength(4, ErrorMessage = "Last name must be at least 2 characters in length!")]
        public string LastName {get; set;}

        //-----------Age
        [Required(ErrorMessage = "Age must be entered!")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be greater than 0!")]
        public int? Age {get; set;}

        //------------Email
        [Required(ErrorMessage = "Email must be entered!")]
        [EmailAddress(ErrorMessage = "Invalid email address; please try again!")]
        public string Email {get; set;}

        //------------Password
        [Required(ErrorMessage = "Password must be entered!")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters in length!")]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}