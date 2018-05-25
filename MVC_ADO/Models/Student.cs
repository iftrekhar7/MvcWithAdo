using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ADO.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }

        public string Roll { get; set; }

        public int DeptId { get; set; }

        public virtual Dept Dept { get; set; }
    }
}