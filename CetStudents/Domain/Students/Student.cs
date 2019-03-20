using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CetStudents.Domain.Students
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SchoolNumber { get; set; }
        public string Email { get; set; }
    }
}
