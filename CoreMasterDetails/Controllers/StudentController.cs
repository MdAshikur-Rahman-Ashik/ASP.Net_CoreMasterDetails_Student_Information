using CoreMasterDetails.Models;
using CoreMasterDetails.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreMasterDetails.Controllers
{
    public class StudentController : Controller
    {
        private readonly SheCoreDbContext _db;
        private readonly IWebHostEnvironment _webHost;

        public StudentController(SheCoreDbContext db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            var applicants = _db.Students.Include(i => i.Modules).ToList();
            applicants = _db.Students.Include(a => a.Course).ToList();
            return View(applicants);
        }
        public JsonResult GetCourses()
        {
            List<SelectListItem> cors = (from cor in _db.Courses
                                         select new SelectListItem
                                         {
                                             Value = cor.CourseId.ToString(),
                                             Text = cor.CourseName
                                         }).ToList();
            return Json(cors);
        }
        public IActionResult Create()
        {
            StudentViewModel student = new StudentViewModel();
            student.Courses = _db.Courses.ToList();
            student.Modules.Add(new Module() { ModuleId = 1 });

            return View(student);
        }
        [HttpPost]

        public IActionResult Create(StudentViewModel student)
        {
            string uniqueFileName = GetUploadedFileName(student);
            student.ImageUrl = uniqueFileName;
            Student obj = new Student();
            obj.StudentName = student.StudentName;
            obj.CourseId = student.CourseId;
            obj.Mobile = student.MobileNo;
            obj.Enroll = student.IsEnrolled;
            obj.Dob = student.Dob;
            obj.ImageUrl = student.ImageUrl;
            _db.Add(obj);
            _db.SaveChanges();
            var user = _db.Students.FirstOrDefault(x => x.Mobile == student.MobileNo);
            if (user != null)
            {
                if (student.Modules.Count > 0)
                {
                    foreach (var item in student.Modules)
                    {
                        Module objM = new Module();
                        objM.StudentId = user.StudentId;
                        objM.Duration = item.Duration;
                        objM.ModuleName = item.ModuleName;
                        _db.Add(objM);
                    }
                }
            }
            _db.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult Delete(int? id)
        {
            var app = _db.Students.Find(id);
            var existsModules = _db.Modules.Where(e => e.StudentId == id).ToList();
            foreach (var exp in existsModules)
            {
                _db.Modules.Remove(exp);
            }
            _db.Entry(app).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        private string GetUploadedFileName(StudentViewModel student)
        {
            string uniqueFileName = null;

            if (student.ProfileFile != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + student.ProfileFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    student.ProfileFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Student app = _db.Students.Include(a => a.Modules).FirstOrDefault(x => x.StudentId == id);

            if (app != null)
            {
                StudentViewModel aps = new StudentViewModel()
                {
                    StudentId = app.StudentId,
                    StudentName = app.StudentName,
                    MobileNo = app.Mobile,
                    Dob = app.Dob,
                    ImageUrl = app.ImageUrl,
                    CourseId = app.CourseId,
                    IsEnrolled = app.Enroll,
                    Courses = _db.Courses.ToList(),
                    Modules = app.Modules.ToList()
                };

                return View("Edit", aps);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            try
            {
                Student existingStudent = _db.Students
                    .Include(a => a.Modules)
                    .FirstOrDefault(x => x.StudentId == student.StudentId);

                if (existingStudent != null)
                {
                    existingStudent.StudentName = student.StudentName;
                    existingStudent.CourseId = student.CourseId;
                    existingStudent.Mobile = student.MobileNo;
                    existingStudent.Enroll = student.IsEnrolled;
                    existingStudent.Dob = student.Dob;

                    if (student.ProfileFile != null)
                    {
                        string uniqueFileName = GetUploadedFileName(student);
                        existingStudent.ImageUrl = uniqueFileName;
                    }


                    var existingModuleIds = existingStudent.Modules.Select(m => m.ModuleId).ToList();
                    var newModuleIds = student.Modules.Select(m => m.ModuleId).ToList();


                    foreach (var module in existingStudent.Modules.ToList())
                    {
                        if (!newModuleIds.Contains(module.ModuleId))
                        {
                            _db.Modules.RemoveRange(module);
                        }
                    }


                    foreach (var moduleViewModel in student.Modules)
                    {

                        Module module = new Module()
                        {
                            Duration = moduleViewModel.Duration,
                            StudentId = student.StudentId,
                            ModuleName = moduleViewModel.ModuleName,
                        };
                        _db.Modules.Add(module);


                        //var module = existingStudent.Modules
                        //    .FirstOrDefault(m => m.ModuleId == moduleViewModel.ModuleId);

                        //if (module == null)
                        //{
                        //    module = new Module
                        //    {
                        //        StudentId = existingStudent.StudentId,
                        //        ModuleName = moduleViewModel.ModuleName,
                        //        Duration = moduleViewModel.Duration
                        //    };
                        //    existingStudent.Modules.Add(module);
                        //}
                        //else
                        //{
                        //    module.ModuleName = moduleViewModel.ModuleName;
                        //    module.Duration = moduleViewModel.Duration;
                        //}
                    }

                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return NotFound();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.FirstOrDefault();
                if (entry != null)
                {
                    var databaseValues = entry.GetDatabaseValues();
                    if (databaseValues != null)
                    {
                        var databaseStudent = (Student)databaseValues.ToObject();

                        ModelState.AddModelError("", "The entity you are trying to edit has been modified by another user. Please refresh the page and try again.");

                        entry.OriginalValues.SetValues(databaseValues);

                        student.Courses = _db.Courses.ToList();
                        student.Modules = databaseStudent.Modules.ToList();

                        return View("Edit", student);
                    }
                }

                ModelState.AddModelError("", "The entity you are trying to edit has been deleted by another user.");
            }

            return RedirectToAction("Index");
        }

    }
}
