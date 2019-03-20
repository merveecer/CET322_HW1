using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CetStudents.Domain.Students;
using CetStudents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CetStudents.Controllers
{
    public class StudentsController : Controller
    {

        CetStudentsContext _context;

        #region Ctor
        public StudentsController(CetStudentsContext context)
        {
            _context = context;
        }
        #endregion

        #region List
        public IActionResult StudentList()
        {
            var students = _context.Students.ToList();
            var studentsmodel = new List<StudentModel>();
            foreach (var item in students)
            {
                var model = new StudentModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    SchoolNumber = item.SchoolNumber,
                    Surname = item.Surname
                };
               
                studentsmodel.Add(model);
            }

            return View(studentsmodel);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            StudentModel student = new StudentModel();
            return View(student);
        }
        [HttpPost]
        public IActionResult Create(StudentModel model)
        {
            var existingStudent = _context.Students.Where(x => x.SchoolNumber == model.SchoolNumber).FirstOrDefault();
            if (existingStudent == null)
            {
                Student newstudent = new Student
                {
                    Email = model.Email,
                    Name = model.Name,
                    SchoolNumber = model.SchoolNumber,
                    Surname = model.Surname
                };
                _context.Students.Add(newstudent);
                _context.SaveChanges();

            }
            return RedirectToAction("StudentList");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            var model = new StudentModel
            {
                Id = student.Id,
                Email = student.Email,
                Name = student.Name,
                SchoolNumber = student.SchoolNumber,
                Surname = student.Surname
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(StudentModel model)
        {
            var student = _context.Students.Where(x => x.Id == model.Id).FirstOrDefault();
            if (ModelState.IsValid && student != null)
            {
                student.Name = model.Name;
                student.Surname = model.Surname;
                student.SchoolNumber = model.SchoolNumber;
                student.Email = model.Email;
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(student);


        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();

                return RedirectToAction("StudentList");
            }
            return NotFound();
        }

        #endregion
    }
}