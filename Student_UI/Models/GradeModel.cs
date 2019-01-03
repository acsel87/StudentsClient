﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_UI.Models
{
    public class GradeModel
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public string Grade { get; set; }
        public DateTime GradeDate { get; set; }
        public string GradeNotes { get; set; }
    }
}
