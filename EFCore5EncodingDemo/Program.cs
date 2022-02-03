using System;
using System.Runtime.InteropServices;

namespace EFCoreEncodingDemo
{
    internal class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleOutputCP(uint wCodePageID);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCP(uint wCodePageID);


        private static void Main(string[] args)
        {

            using (var context = new PeopleContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }


            Console.Clear();
            FixConsoleEncoding();
            InsertPerson();
            RevertEncoding();
        }

        private static void FixConsoleEncoding()
        {
            SetConsoleOutputCP(1256);
            SetConsoleCP(1256);
        }
        private static void RevertEncoding()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
        }

        private static void InsertPerson()
        {
            var context = new PeopleContext();
            var p = new Person();
            p.FirstName = "Julie";
            p.LastName = "تصميم مواقع ويب";
            context.People.Add(p);
            context.SaveChanges();

        }


    }
}