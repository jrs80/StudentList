
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            bool userFinished = false;

            var studentList = new Dictionary<int, string>();

            while(!userFinished) {
                Console.Clear();
                Console.WriteLine("\n\nWelcome to the University Student database.  Select an option: ");
                Console.WriteLine("\t1. Enter a new student.\n\t2. Show student list.\n\t3. Exit");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch(key.KeyChar) {
                    case '3':
                        userFinished = true;
                        break;
                    case '2':
                        if(studentList == null) {
                            Console.WriteLine("\nStudent List is empty.");
                            break;
                        }
                        Console.WriteLine("\n\n------------------------------------------");
                        Console.WriteLine("----Student Name----------Student ID-----");
                        Console.WriteLine("------------------------------------------");
                        foreach(var v in studentList) Console.WriteLine($"\t{v.Key}\t\t{v.Value}");
                        Console.WriteLine("\n\nPress any key to return to main menu.");
                        Console.ReadKey(true);
                        break;
                    case '1':
                        Console.WriteLine("\n\nEnter type of student to create:\n\t1. Graduate\n\t2. Undergraduate\n\t3. Non-degree-seeking");
                        char k = Console.ReadKey(true).KeyChar;
                        StudentTypes st = k == '1' ? StudentTypes.Graduate : (k == '2' ? StudentTypes.Undergraduate : StudentTypes.NonDegreeSeeking);
                        IStudent newStudent = StudentFactory.CreateStudent(st);
                        if(newStudent == null) {
                            Console.WriteLine("Error creating student.");
                            Console.ReadKey(true);
                        }
                        else {
                            Console.WriteLine($"\n{newStudent.StudentType} student created.");
                            studentList.Add(newStudent.StudentIDNumber, newStudent.Name);
                            Console.ReadKey(true);
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid input.");
                        Console.ReadKey(true);
                        break;
                }
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey(true);

        }
    }
}
