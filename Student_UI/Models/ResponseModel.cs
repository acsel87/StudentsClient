using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_UI.Models
{
    public class ResponseModel<T>
    {
        public T Model { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorAction { get; set; }
        public string ErrorLog { get; set; }
    }
}

