using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;
using System.IO;

namespace ConsoleApp1.DAL
{
    class FileRepo : IRepo
    {
        //Path to file
        private readonly string PATH = @"C:\Users\Karlo\Desktop\DataMI2\persons.txt";

        public FileRepo()
        {
            //If path doesn't exists, create it
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public IList<Person> LoadPerons()
        {
            IList<Person> persons = new List<Person>();
            string[] lines = File.ReadAllLines(PATH);
            //foreach (var line in lines)
            //{
            //    Person p = Person.ParseFromFile(line);
            //    persons.Add(p);
            //}

            //LINQ easier way
            lines.ToList().ForEach(line => persons.Add(Person.ParseFromFile(line)));
            return persons;
        }

        public void SavePersons(IList<Person> persons)
        {
            //string[] lines = new string[persons.Count];//kolko je u listi persona tolko ima linija
            //int index = 0;
            ////foreach (var p in persons)
            ////{
            ////    lines[index++] = p.FormatForFile();
            ////}
            //File.WriteAllLines(PATH, lines);

            //LINQ easier way
            File.WriteAllLines(PATH, persons.Select(p => p.FormatForFile())); 
        }
    }
}
