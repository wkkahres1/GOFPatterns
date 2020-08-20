using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.DAL

    //updated faculty controller to make it use Unit of work
{
    public class UnitOfWork : IDisposable
    {
        // Part 1 -instantiates values for faculty and studdents and all repositories share same context
        private RepositoryContext context = new RepositoryContext();
        private GenericRepository<Faculty> facultyRepository;
        private GenericRepository<Student> studentRepository;

        public GenericRepository<Faculty> FacultyRepository
        {
            get
            {
                if (this.facultyRepository == null)
                {
                    this.facultyRepository = new GenericRepository<Faculty>(context);
                }
                return facultyRepository;
            }
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        // Part 2 - saves changes on the database
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}