using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            db.Database.EnsureCreated();
        }
    }
}
