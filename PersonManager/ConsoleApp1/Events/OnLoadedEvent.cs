using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Events
{
   public class OnLoadedEventArgs
    {
        public Person LoadedPerson { get; set; }
        public IList<string> MissingData { get; set; }
    }

    public delegate void OnLoadedDelegate(object sender, OnLoadedEventArgs args);
}
