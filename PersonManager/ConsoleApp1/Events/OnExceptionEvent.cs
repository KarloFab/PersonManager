using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Events
{
   public delegate void OnExceptionDelegate(object sender, OnExceptionEventArgs args);

   public class OnExceptionEventArgs : EventArgs
    {
        public Exception Exception { get; set; }
    }
}
