using EF_ITI_DB_ReverseEngineer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EF_ITI_DB_ReverseEngineer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITIDBContext db = new ITIDBContext();

            //foreach (var item in db.Students)
            //{
            //    Console.WriteLine(item);
            //}


            //var q1 = db.Students.AsNoTracking().Where(s => s.DeptId == 10);   // 5 in DB
            //foreach (var item in q1)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(db.Students.Local.Count()); // 5

            //int id = 3001;
            //var q2 = db.Students.Find(id);
            //Console.WriteLine(q2);

            //var q3 = db.Students.AsQueryable();
            //Console.WriteLine(db.Students.Local.Count());
            //var q3_1 = q3.Where(s => s.DeptId == 10);
            //Console.WriteLine(db.Students.Local.Count());
            //foreach (var item in q3_1)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(db.Students.Local.Count()); 
            //5 as he get only needed data from db.Students.AsEnumerable(); q3.Where(s => s.DeptId == 10); lines execute them together


            //var q4 = db.Students.AsEnumerable();
            //Console.WriteLine(db.Students.Local.Count());
            //var q4_1 = q4.Where(s => s.DeptId == 10);
            //Console.WriteLine(db.Students.Local.Count());
            //foreach (var item in q4_1)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(db.Students.Local.Count()); //3015 as he get all data from db.Students.AsEnumerable(); line as execute each cmd separately

            var q5 = db.Students.FromSqlRaw("EXECUTE proc_st_dept @stud_No", new SqlParameter("@stud_No", 3001)).ToList();
            Console.WriteLine(q5);

        }
    }
}