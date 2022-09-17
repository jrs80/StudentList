using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
    public interface IStudent
    {
        string StudentType { get; set; }
        string Name { get; set; } 
        int Age { get; set; } 
        bool IsInState { get; set; }
        bool IsGraded { get; set; } 
        int StudentIDNumber { get; set; }

        void SetStudentInfo();
    }

    public enum StudentTypes
    {
        Graduate,
        Undergraduate,
        NonDegreeSeeking
    }
    public static class StudentFactory
    {
        public static IStudent CreateStudent(StudentTypes studentType)
        {
            if(studentType == StudentTypes.Graduate) return new Graduate();
            else if(studentType == StudentTypes.Undergraduate) return new Undergraduate();
            else if(studentType == StudentTypes.NonDegreeSeeking) return new NonDegreeSeeking();
            else return null;
        }
    }

    public abstract class Student:IStudent
    {

        public string StudentType { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsInState { get; set; }
        public bool IsGraded { get; set; }
        public int StudentIDNumber { get; set; }

        public abstract void SetStudentInfo();

        //Need to add error handling if e.g. user enters a letter instead of numbers for age:
        public virtual void RequestStudentInfo() {
            Console.WriteLine("\nPlease enter student information in order to create a new student.  All fields are required.");
            Console.WriteLine("\tName: ");
            Name = Console.ReadLine();
            Console.WriteLine("\tAge: ");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tDoes student qualify for in-state tuition?  [Enter 1 for yes or 0 for no.]");
            char tmp = Console.ReadKey(true).KeyChar;
            if(tmp == '1') IsInState = true;
            else if(tmp == '0') IsInState = false;
            else {
                Console.WriteLine("Invalid input.  Student marked as out-of-state for now.");
                IsInState = false;
                Console.ReadKey(true);
            }         
        }

        //Need to add error handling in case the generated id is already in the student list.  Just generate a new one.
        public int GenerateNewID()
        {
            Random r = new Random();
            int id = r.Next(1, 100000);
            return id;
        }
    }

    

    public class Graduate : Student
    {
        public Graduate()
        {
            SetStudentInfo();
        }
        public override void SetStudentInfo()
        {
            IsGraded = true;
            StudentType = "Graduate";
            RequestStudentInfo();
            StudentIDNumber = GenerateNewID();
        }
    }

    public class Undergraduate: Student
    {
        public Undergraduate()
        {
            SetStudentInfo();
        }
        
        public override void SetStudentInfo()
        {
            IsGraded = true;
            StudentType = "Undergraduate";
            RequestStudentInfo();
            StudentIDNumber = GenerateNewID();
        }
    }

    public class NonDegreeSeeking : Student
    {
        public NonDegreeSeeking()
        {
            SetStudentInfo();
        }
        public override void SetStudentInfo()
        {
            IsGraded = false;
            StudentType = "Non-degree-seeking";
            RequestStudentInfo();
            StudentIDNumber = GenerateNewID();
        }
    }

}
