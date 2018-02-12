using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;

namespace ConsoleApp1.DAL
{
    public interface IRepo
    {
        void SavePersons(IList<Person> persons);
        IList<Person> LoadPerons();
    }
}
