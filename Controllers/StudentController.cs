using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        
        public StudentController(AppDbContext context)
        {
            _context = context;
            
        }


        public IActionResult Index()
        {
            var studentdata = _context.Students.Include(x => x.ClassRoom);
            return View(studentdata.ToList());   
        }

        private List<SelectListItem> PopulateDropdown()
        {
            var selectListItems = new List<SelectListItem>();
            var classrooms = _context.Classrooms.ToList();

            foreach (var item in classrooms)
            {
                selectListItems.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }

            return selectListItems;
        }

      

        //GET: AddOrEdit
        public IActionResult AddOrEdit(int? id)
        {
            ViewBag.PageName = id == null ? "Create pupil" : "Edit pupil";
            ViewBag.IsEdit = id == null ? false : true;

            ViewBag.ClassRoomID = new SelectList(PopulateDropdown(), "Value", "Text");


            if (id == null)
            {
  
                return View();
            }
            else
            {
                var payload = _context.Students.Find(id);
                if (payload == null)
                {
                    return NotFound();
                }

                //Map studentVM to Student
                var studentViewModel = new StudentVM();

                studentViewModel.LName = payload.LName;
                studentViewModel.FName = payload.FName;
                studentViewModel.Email = payload.Email;
                studentViewModel.ClassRoom = payload.ClassRoom;
                studentViewModel.Gender = payload.Gender;
                // Map other properties as needed
                ViewBag.Id = payload.Id;  //This was done becasue the StudentVM does not have Id properties and we need this id in the view, so we get this from the student and and store in ViewBag
                
                return View(studentViewModel);
            }
        }

        //POST: AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddOrEdit(int id, [Bind(include: "FName,LName,Gender,Email,ClassRoomID")] StudentVM student)
        {
            bool IsStudentExist = false;

            Student payload = _context.Students.Find(id);
            ViewBag.ClassRoomID = new SelectList(PopulateDropdown(), "Value", "Text");
            var classId = Convert.ToInt32(student.ClassRoomID);

            if (payload != null)
            {
                IsStudentExist = true;
            }
            else
            {
                payload = new Student();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    payload.FName = student.FName;
                    payload.LName = student.LName;
                    payload.Gender = student.Gender;
                    payload.Email = student.Email;
                    payload.ClassRoom = _context.Classrooms.Find(classId); //Here the classroomId is loaded payload so that the appropriate ID (value) will be matched with the class room name passed as "text" above

                    if (IsStudentExist)
                    {
                        _context.Update(payload);
                    }
                    else
                    {
                        _context.Add(payload);
                    }
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));

            }
            
            return View(student);
        }


        //GET: Student/Delete/1
        public IActionResult Delete(int id)
        {
            var studentDetails = _context.Students.Find(id);

            if (studentDetails == null) return View("NotFound");
            return View(studentDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var studentDetails = _context.Students.Find(id);
            if (studentDetails == null) return View("NotFound");

            _context.Students.Remove(studentDetails);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
