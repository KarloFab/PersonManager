using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
     public class Person
    {
        private const char DELIMITER = '|'; 

        public string OIB { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public override string ToString() => $"{OIB} {Name} {Surname} {Phone} {Email}";

        //Format for file (When saving persons)
        public string FormatForFile() => $"{OIB}{DELIMITER}{Name}{DELIMITER}{Surname}{DELIMITER}{Phone}{DELIMITER}{Email}";

        //Parse from file using DELIMITER
        public static Person ParseFromFile(string line)
        {
            string[] details = line.Split(DELIMITER);

            return new Person
            {
                OIB=details[0],
                Name=details[1],
                Surname=details[2],
                Phone=details[3],
                Email=details[4]
            };
        }

        public bool HasValidOIB() => OIB.Length == 11 && OIB.All(char.IsDigit);
    }
}
