using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.DAL;

//UPDATED to reference Student Repository

namespace Repository.Controllers
{
    public class StudentsController : Controller
    {
        
        private IStudentRepository studentRepository;

        public StudentsController()
        {
            this.studentRepository = new StudentRepository(new RepositoryContext());
            //Reference Student Repository
        }

        // GET: Students
        public async Task<ActionResult> Index()
        {
            return View(await studentRepository.GetStudents());
            //Reference Student Repository


        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = await studentRepository.GetStudentByID(id);
            //Reference Student Repository
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentID,Name,Year")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.InsertStudent(student);
                //Reference Student Repository
                await studentRepository.Save();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = await studentRepository.GetStudentByID(id);
            //Reference Student Repository

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentID,Name,Year")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.UpdateStudent(student);
                //Reference Student Repository
                await studentRepository.Save();

                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = await studentRepository.GetStudentByID(id);
            //Reference Student Repository

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {            
            Student student = await studentRepository.GetStudentByID(id);
            //Reference Student Repository
            studentRepository.DeleteStudent(id);
            await studentRepository.Save();
            //Reference Student Repository

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                studentRepository.Dispose();
                //Reference Student Repository
            }
            base.Dispose(disposing);
        }
    }
}
