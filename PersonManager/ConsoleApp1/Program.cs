using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PERSON MANAGER APP //

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager manager = new PersonManager();
            manager.OnException += Manager_OnException;//subscribing on OnException event
            manager.OnLoaded += Manager_OnLoaded;
            LoadPersons(manager);

            manager.GetPersonsDitcionary();
        }

        private static void Manager_OnLoaded(object sender, Events.OnLoadedEventArgs args)
        {
            //If loaded person has missing data, report it
           if(args.MissingData.Count > 0) 
            {
                string report ="This person is missing: "+ string.Join(",", args.MissingData);
                ShowMessage(report, ConsoleColor.Magenta);
            }
            else
            {
                ShowMessage(args.LoadedPerson.ToString(),ConsoleColor.Green);
            }
        }

        private static void LoadPersons(PersonManager manager)
        {
            IList<Person> persons = new List<Person>
            {
                new Person
                {
                    OIB="01234567901",
                    Name="Karlo",
                    Surname="Fabijanic",
                    Phone="012",
                    Email="db@gmail.com"
                },

                new Person
                {
                    OIB="01234567911",
                    Name="Karlo",
                    Surname="Fabijanic",
                    Phone="0123",
                    Email="kf@gmail.com"
                },

                  new Person
                {
                    OIB="0123567921",
                    Name="Newbie",
                    Surname="Bie",
                    Phone="01234",
                    Email="nb@gmail.com"
                },
                     new Person
                {
                    OIB="01234567931",
                    Name="Getti",
                    Surname="",
                    Phone="1012",
                    Email="gg@gmail.com"
                },

                new Person
                {
                    OIB="012345678902",
                    Name="Daniel",
                    Surname="",
                    Phone="",
                    Email=""
                }
            };
            manager.SavePersons(persons);
        }

        private static void Manager_OnException(object sender, Events.OnExceptionEventArgs args)
        {
            ShowMessage(args.Exception.Message, ConsoleColor.Red);
        }

        private static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
