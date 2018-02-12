﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL
{
    public static class RepoFactory
    {
        public static IRepo GetRepo() => new FileRepo(); //Get FileRepo
    }
}
