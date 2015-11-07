using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWebAPI.Models
{
    // Employee object definition
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
    }
}