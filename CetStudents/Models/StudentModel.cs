using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CetStudents.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Display(Name="Name: ")]
        public string Name { get; set; }

        [Display(Name = "Surname: ")]
        public string Surname { get; set; }

        [Display(Name = "School Number: ")]
        public string SchoolNumber { get; set; }

        [Display(Name = "Email: ")]
        public string Email { get; set; }
        


    }
}
