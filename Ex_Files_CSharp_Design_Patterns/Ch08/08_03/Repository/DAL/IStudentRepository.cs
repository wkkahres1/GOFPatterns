using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


//This code declares typical set of CRUD signatures
//CREATE READ UPDATE DELETE
namespace Repository.DAL
{
        public interface IStudentRepository : IDisposable
        {
            Task<List<Student>> GetStudents();
            Task<Student> GetStudentByID(int? studentId);
            void InsertStudent(Student student);
            void DeleteStudent(int studentID);
            void UpdateStudent(Student student);
            Task<int> Save();
        } 
}