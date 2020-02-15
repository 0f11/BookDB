using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Display(Name ="Given Name", Prompt = "First name")]
        [MaxLength(128, ErrorMessage = "Max lenth for {0} is {1}")]
        [MinLength(1, ErrorMessage = "Min lenth for {0} is {1}")]
        public string FirstName { get; set; } = default!;
        [Display(Name ="Family Name", Prompt = "Family name")]
        [MinLength(1, ErrorMessage = "Min lenth for {0} is {1}")]
        [MaxLength(128, ErrorMessage = "Max lenth for {0} is {1}")]
        public string LastName { get; set; } = default!;
        
        [Display(Name="Birthdate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public ICollection<BookAuthor>? AuthorBooks { get; set; }
        [Display(Name="Full Name")]
        public string FirstLastName => FirstName + " " + LastName;
        [Display(Name="Full Name")]
        public string LastFirstName => LastName + " " + FirstName;
    }
}