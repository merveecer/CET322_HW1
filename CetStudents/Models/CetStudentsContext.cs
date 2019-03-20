using CetStudents.Domain.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CetStudents.Models
{
    public class CetStudentsContext:DbContext
    {
        public CetStudentsContext(DbContextOptions<CetStudentsContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
